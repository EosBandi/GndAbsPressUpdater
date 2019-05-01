namespace GroundPressureMonitor
{
    partial class PluginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.mComPortTextBox = new System.Windows.Forms.TextBox();
            this.mSaveButton = new System.Windows.Forms.Button();
            this.mMessagesListBox = new System.Windows.Forms.ListBox();
            this.mUpdatePeriodTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.mDeltaPressureMax = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mCancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "COM port:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mComPortTextBox
            // 
            this.mComPortTextBox.Location = new System.Drawing.Point(205, 34);
            this.mComPortTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.mComPortTextBox.Name = "mComPortTextBox";
            this.mComPortTextBox.Size = new System.Drawing.Size(132, 22);
            this.mComPortTextBox.TabIndex = 1;
            // 
            // mSaveButton
            // 
            this.mSaveButton.Location = new System.Drawing.Point(19, 494);
            this.mSaveButton.Margin = new System.Windows.Forms.Padding(4);
            this.mSaveButton.Name = "mSaveButton";
            this.mSaveButton.Size = new System.Drawing.Size(100, 28);
            this.mSaveButton.TabIndex = 2;
            this.mSaveButton.Text = "Save";
            this.mSaveButton.UseVisualStyleBackColor = true;
            // 
            // mMessagesListBox
            // 
            this.mMessagesListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mMessagesListBox.FormattingEnabled = true;
            this.mMessagesListBox.HorizontalScrollbar = true;
            this.mMessagesListBox.ItemHeight = 15;
            this.mMessagesListBox.Location = new System.Drawing.Point(19, 153);
            this.mMessagesListBox.Margin = new System.Windows.Forms.Padding(4);
            this.mMessagesListBox.Name = "mMessagesListBox";
            this.mMessagesListBox.Size = new System.Drawing.Size(318, 319);
            this.mMessagesListBox.TabIndex = 3;
            // 
            // mUpdatePeriodTextBox
            // 
            this.mUpdatePeriodTextBox.Location = new System.Drawing.Point(205, 64);
            this.mUpdatePeriodTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.mUpdatePeriodTextBox.Name = "mUpdatePeriodTextBox";
            this.mUpdatePeriodTextBox.Size = new System.Drawing.Size(132, 22);
            this.mUpdatePeriodTextBox.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Update interval (sec):";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mEnabledCheckBox
            // 
            this.mEnabledCheckBox.AutoSize = true;
            this.mEnabledCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.mEnabledCheckBox.Location = new System.Drawing.Point(263, 124);
            this.mEnabledCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.mEnabledCheckBox.Name = "mEnabledCheckBox";
            this.mEnabledCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mEnabledCheckBox.Size = new System.Drawing.Size(74, 21);
            this.mEnabledCheckBox.TabIndex = 9;
            this.mEnabledCheckBox.Text = "Enable";
            this.mEnabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // mDeltaPressureMax
            // 
            this.mDeltaPressureMax.Location = new System.Drawing.Point(205, 94);
            this.mDeltaPressureMax.Margin = new System.Windows.Forms.Padding(4);
            this.mDeltaPressureMax.Name = "mDeltaPressureMax";
            this.mDeltaPressureMax.Size = new System.Drawing.Size(132, 22);
            this.mDeltaPressureMax.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 97);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Max Pressure Delta";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mCancelButton
            // 
            this.mCancelButton.Location = new System.Drawing.Point(237, 494);
            this.mCancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.mCancelButton.Name = "mCancelButton";
            this.mCancelButton.Size = new System.Drawing.Size(100, 28);
            this.mCancelButton.TabIndex = 12;
            this.mCancelButton.Text = "Cancel";
            this.mCancelButton.UseVisualStyleBackColor = true;
            // 
            // PluginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 566);
            this.ControlBox = false;
            this.Controls.Add(this.mCancelButton);
            this.Controls.Add(this.mDeltaPressureMax);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mEnabledCheckBox);
            this.Controls.Add(this.mUpdatePeriodTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mMessagesListBox);
            this.Controls.Add(this.mSaveButton);
            this.Controls.Add(this.mComPortTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "PluginForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Ground Pressure Monitor Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ListBox mMessagesListBox;
        internal System.Windows.Forms.Button mSaveButton;
        internal System.Windows.Forms.TextBox mComPortTextBox;
        internal System.Windows.Forms.TextBox mUpdatePeriodTextBox;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.CheckBox mEnabledCheckBox;
        internal System.Windows.Forms.TextBox mDeltaPressureMax;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Button mCancelButton;
    }
}