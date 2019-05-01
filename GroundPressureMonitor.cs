using MissionPlanner;
using MissionPlanner.Plugin;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SerialPort = MissionPlanner.Comms.SerialPort;

namespace GroundPressureMonitor

{
    public enum PressureUnitEnum
    {
        mbar = 0,
        Pa = 1,
    }

    public class GroundPressureMonitor : Plugin
    {
        public override string Name => "Ground Pressure Monitor";

        public override string Version => "v 1.0";

        public override string Author => "DroneDoktor.eu";

        const string ComPortConfigKey = "GndPressMonComPort";
        const string RefreshConfigKey = "GndPressMonRefresh";
        const string MaxDeltaConfigKey = "GndPressMonMaxDelta";
        const string EnabledConfigKey = "GndPressMonEnabled";

        int mTs = 10;
        public int RefreshTime
        {
            get => mTs;
            set
            {
                if (value < 1) value = 1;
                if (value > 10000) value = 1000;
                mTs = value;
                loopratehz = 1.0f / value;
            }
        }

        int mMaxPressureDelta;
        public int MaxPressureDeltaPa
        {
            get => mMaxPressureDelta;

            set
            {
                if (value < 1) value = 1;
                if (value > 1000) value = 1000;
                mMaxPressureDelta = value;
            }
        }

        public float pressureTrim = 0;                        //Trimming ground baro readout to match disarmed QNH, assuming the difference is linear
        
        string ComPort { get; set; } = "COM3";
        public bool IsEnabled { get; set; }
        public bool IsConnected { get; set; }

        PluginForm mForm;

        public SerialPort p = new SerialPort();

        public override bool Exit()
        {
            return true;
        }

        public override bool Init()
        {
            Console.WriteLine("Ground Absolute Pressure Updater Init");
            loopratehz = 1.0f / mTs;

            RestoreConfig();

            var menuItem = new ToolStripMenuItem("Ground Absolute Pressure Updater Config");
            menuItem.Click += ConfigMenu_Click;
            Host.FDMenuMap.Items.Add(menuItem);

            BuildForm();
            IsConnected = false;        
            return true;
        }

        void RestoreConfig()
        {
            ComPort = RestoreOrCreateConfigKey(ComPortConfigKey, "").ToString();
            if (int.TryParse(RestoreOrCreateConfigKey(RefreshConfigKey, "10"), out int r))
            {
                RefreshTime = r;
            }
            if (int.TryParse(RestoreOrCreateConfigKey(MaxDeltaConfigKey, "50"), out r))
            {
                MaxPressureDeltaPa = r;
            }
            if (bool.TryParse(RestoreOrCreateConfigKey(EnabledConfigKey, "0"), out bool b))
            {
                IsEnabled = b;
            }
        }

        string RestoreOrCreateConfigKey(string key, string defaultValue)
        {
            if (Host.config.ContainsKey(key) == false)
            {
                Host.config[key] = defaultValue;
                Host.config.Save();
                return defaultValue;
            }
            else
            {
                return Host.config[key];
            }
        }

        void ValidateFormUpdateModelAndSaveConfigInDb()
        {
            ComPort = mForm.mComPortTextBox.Text;
            Host.config[ComPortConfigKey] = ComPort;
            //El Ts
            if (int.TryParse(mForm.mUpdatePeriodTextBox.Text, out int r))
            {
                RefreshTime = r;
                Host.config[RefreshConfigKey] = RefreshTime.ToString();
            }
            //El max delta
            if (int.TryParse(mForm.mDeltaPressureMax.Text, out r))
            {
                MaxPressureDeltaPa = r;
                Host.config[MaxDeltaConfigKey] = MaxPressureDeltaPa.ToString();
            }
            Host.config[EnabledConfigKey] = IsEnabled.ToString(); //Changed event sets the IsEnabled according to the checkbox.

            Host.config.Save();
        }

        void BuildForm()
        {
            mForm = new PluginForm();
            UpdateFormParams();

            mForm.mEnabledCheckBox.CheckedChanged += (o, e) =>
            {
                IsEnabled = mForm.mEnabledCheckBox.Checked;
            };

            mForm.mCancelButton.Click += (o, e) =>
            {
                mForm.Hide();
            };

            mForm.mSaveButton.Click += (o, e) =>
              {
                  ValidateFormUpdateModelAndSaveConfigInDb();
                  //RestoreConfigInModel();
                  IsEnabled = mForm.mEnabledCheckBox.Checked;
                  mForm.Hide();
              };
        }

        public void AddMessage(string msg)
        {

            if (mForm.Visible)
            {
                mForm.BeginInvoke((Action)delegate
                {
                    mForm.mMessagesListBox.Items.Insert(0, DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + " " + msg);
                });
            }
        }

        void UpdateFormParams()
        {
            mForm.mComPortTextBox.Text = ComPort;
            mForm.mUpdatePeriodTextBox.Text = RefreshTime.ToString();
            mForm.mDeltaPressureMax.Text = MaxPressureDeltaPa.ToString();
            mForm.mEnabledCheckBox.Checked = IsEnabled;

        }

        private void ConfigMenu_Click(object sender, EventArgs e)
        {
            mForm.Show();
        }

        public void Connect_baro()
        {
            if (!SerialPort.GetPortNames().Contains(ComPort))
            {
                IsConnected = false;
                return;
            }

            try
            {
                p.PortName = ComPort;
                p.BaudRate = 9600;
                p.ReadTimeout = 1000;
                p.WriteTimeout = 1000;
                p.Open();
                IsConnected = true;
            }
            catch (Exception ex)
            {
                AddMessage("Connection Error: " + ex.Message);
                IsConnected = false;

            }
        }


        public override bool Loaded()
        {
//            mForm.Show();
//            mForm.Hide();
            return true;
        }

        public override bool Loop()
        {

            Console.WriteLine("Ground Pressure Monitor update loop");

            if (!IsEnabled)
            {
                return true;
            }

            if (MainV2.comPort.BaseStream.IsOpen == false)
            {
                AddMessage("Mavlink is not connected");
                return true;
            }

            if (!IsConnected)
            {
                AddMessage($"Opening baro sensor at {ComPort}");
                Connect_baro();
                return true;
            }

            if (IsConnected)
            {
                try
                {
                    p.WriteLine("R");
                    var response = p.ReadLine();

                    if (float.TryParse(response, NumberStyles.Float, CultureInfo.InvariantCulture, out float pressure))
                    {
                        AddMessage($"Ground pressure read: {pressure}");
                        var currentQNH = MainV2.comPort.GetParam("GND_ABS_PRESS");
                        var newPressurePa = pressure * 100;

                        //If uav is disarmed and we are below 2 meters, then we calculating trim value to match ground sensor to onboard
                        if ((!Host.cs.armed) && (Host.cs.alt < 2))
                        {
                            pressureTrim = newPressurePa - currentQNH;
                            AddMessage($"Sensor trim:{pressureTrim}");

                        }
                        else
                        {
                            var epsilon = 10;
                            var delta = newPressurePa - currentQNH;
                            var deltaAbs = Math.Abs(delta);
                            if (deltaAbs < epsilon)
                            {
                                AddMessage($"Pressure almost equal (not updated): mavlink={currentQNH.ToString("F0")}, new={newPressurePa.ToString("F0")}");
                            }
                            else
                            {

                                if (deltaAbs > MaxPressureDeltaPa)
                                {
                                    delta = delta > 0 ? MaxPressureDeltaPa : -MaxPressureDeltaPa;
                                }
                                newPressurePa += delta;
                                var smoothUpdateNewPressurePa = 0.7 * currentQNH + 0.3 * newPressurePa;
                                MainV2.comPort.setParam("GND_ABS_PRESS", smoothUpdateNewPressurePa);
                                AddMessage($"Pressure updated: mavlink={currentQNH.ToString("F0")}, new={smoothUpdateNewPressurePa.ToString("F0")}");
                            }
                        }
                    }
                    else
                    {
                        AddMessage($"Invalid baro resp:{response}");
                    }
                }
                catch (Exception ex)
                {
                    AddMessage("Comm Error: " + ex.Message);
                }
            }

            return true;
        }
    }
}
