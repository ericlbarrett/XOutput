namespace XOutput
{
    partial class XOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XOut));
            this.StartStopBtn = new System.Windows.Forms.Button();
            this.controllerBoxOne = new System.Windows.Forms.GroupBox();
            this.optionsOne = new System.Windows.Forms.Button();
            this.moveOneDown = new System.Windows.Forms.Button();
            this.enabledTwo = new System.Windows.Forms.CheckBox();
            this.enabledOne = new System.Windows.Forms.CheckBox();
            this.controllerBoxTwo = new System.Windows.Forms.GroupBox();
            this.optionsTwo = new System.Windows.Forms.Button();
            this.moveTwoUp = new System.Windows.Forms.Button();
            this.moveTwoDown = new System.Windows.Forms.Button();
            this.controllerBoxThree = new System.Windows.Forms.GroupBox();
            this.optionsThree = new System.Windows.Forms.Button();
            this.moveThreeUp = new System.Windows.Forms.Button();
            this.moveThreeDown = new System.Windows.Forms.Button();
            this.enabledThree = new System.Windows.Forms.CheckBox();
            this.controllerBoxFour = new System.Windows.Forms.GroupBox();
            this.optionsFour = new System.Windows.Forms.Button();
            this.moveFourUp = new System.Windows.Forms.Button();
            this.enabledFour = new System.Windows.Forms.CheckBox();
            this.isExclusive = new System.Windows.Forms.CheckBox();
            this.controllerBoxOne.SuspendLayout();
            this.controllerBoxTwo.SuspendLayout();
            this.controllerBoxThree.SuspendLayout();
            this.controllerBoxFour.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartStopBtn
            // 
            this.StartStopBtn.Location = new System.Drawing.Point(397, 316);
            this.StartStopBtn.Name = "StartStopBtn";
            this.StartStopBtn.Size = new System.Drawing.Size(75, 23);
            this.StartStopBtn.TabIndex = 0;
            this.StartStopBtn.Text = "Start";
            this.StartStopBtn.UseVisualStyleBackColor = true;
            this.StartStopBtn.Click += new System.EventHandler(this.StartStopBtn_Click);
            // 
            // controllerBoxOne
            // 
            this.controllerBoxOne.Controls.Add(this.optionsOne);
            this.controllerBoxOne.Controls.Add(this.moveOneDown);
            this.controllerBoxOne.Location = new System.Drawing.Point(12, 12);
            this.controllerBoxOne.Name = "controllerBoxOne";
            this.controllerBoxOne.Size = new System.Drawing.Size(460, 70);
            this.controllerBoxOne.TabIndex = 1;
            this.controllerBoxOne.TabStop = false;
            this.controllerBoxOne.Text = "`";
            // 
            // optionsOne
            // 
            this.optionsOne.Image = global::XOutput.Properties.Resources.gear;
            this.optionsOne.Location = new System.Drawing.Point(6, 41);
            this.optionsOne.Name = "optionsOne";
            this.optionsOne.Size = new System.Drawing.Size(27, 23);
            this.optionsOne.TabIndex = 7;
            this.optionsOne.UseVisualStyleBackColor = true;
            // 
            // moveOneDown
            // 
            this.moveOneDown.Image = global::XOutput.Properties.Resources.arrow_Down;
            this.moveOneDown.Location = new System.Drawing.Point(427, 41);
            this.moveOneDown.Name = "moveOneDown";
            this.moveOneDown.Size = new System.Drawing.Size(27, 23);
            this.moveOneDown.TabIndex = 1;
            this.moveOneDown.UseVisualStyleBackColor = true;
            // 
            // enabledTwo
            // 
            this.enabledTwo.AutoSize = true;
            this.enabledTwo.Checked = true;
            this.enabledTwo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enabledTwo.Location = new System.Drawing.Point(51, 133);
            this.enabledTwo.Name = "enabledTwo";
            this.enabledTwo.Size = new System.Drawing.Size(65, 17);
            this.enabledTwo.TabIndex = 8;
            this.enabledTwo.Text = "Enabled";
            this.enabledTwo.UseVisualStyleBackColor = true;
            // 
            // enabledOne
            // 
            this.enabledOne.AutoSize = true;
            this.enabledOne.Checked = true;
            this.enabledOne.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enabledOne.Location = new System.Drawing.Point(51, 56);
            this.enabledOne.Name = "enabledOne";
            this.enabledOne.Size = new System.Drawing.Size(65, 17);
            this.enabledOne.TabIndex = 6;
            this.enabledOne.Text = "Enabled";
            this.enabledOne.UseVisualStyleBackColor = true;
            // 
            // controllerBoxTwo
            // 
            this.controllerBoxTwo.Controls.Add(this.optionsTwo);
            this.controllerBoxTwo.Controls.Add(this.moveTwoUp);
            this.controllerBoxTwo.Controls.Add(this.moveTwoDown);
            this.controllerBoxTwo.Location = new System.Drawing.Point(12, 88);
            this.controllerBoxTwo.Name = "controllerBoxTwo";
            this.controllerBoxTwo.Size = new System.Drawing.Size(460, 70);
            this.controllerBoxTwo.TabIndex = 2;
            this.controllerBoxTwo.TabStop = false;
            // 
            // optionsTwo
            // 
            this.optionsTwo.Image = global::XOutput.Properties.Resources.gear;
            this.optionsTwo.Location = new System.Drawing.Point(6, 41);
            this.optionsTwo.Name = "optionsTwo";
            this.optionsTwo.Size = new System.Drawing.Size(27, 23);
            this.optionsTwo.TabIndex = 7;
            this.optionsTwo.UseVisualStyleBackColor = true;
            // 
            // moveTwoUp
            // 
            this.moveTwoUp.Image = global::XOutput.Properties.Resources.arrow_Up;
            this.moveTwoUp.Location = new System.Drawing.Point(427, 12);
            this.moveTwoUp.Name = "moveTwoUp";
            this.moveTwoUp.Size = new System.Drawing.Size(27, 23);
            this.moveTwoUp.TabIndex = 3;
            this.moveTwoUp.UseVisualStyleBackColor = true;
            // 
            // moveTwoDown
            // 
            this.moveTwoDown.Image = global::XOutput.Properties.Resources.arrow_Down;
            this.moveTwoDown.Location = new System.Drawing.Point(427, 41);
            this.moveTwoDown.Name = "moveTwoDown";
            this.moveTwoDown.Size = new System.Drawing.Size(27, 23);
            this.moveTwoDown.TabIndex = 2;
            this.moveTwoDown.UseVisualStyleBackColor = true;
            // 
            // controllerBoxThree
            // 
            this.controllerBoxThree.Controls.Add(this.optionsThree);
            this.controllerBoxThree.Controls.Add(this.moveThreeUp);
            this.controllerBoxThree.Controls.Add(this.moveThreeDown);
            this.controllerBoxThree.Location = new System.Drawing.Point(12, 164);
            this.controllerBoxThree.Name = "controllerBoxThree";
            this.controllerBoxThree.Size = new System.Drawing.Size(460, 70);
            this.controllerBoxThree.TabIndex = 3;
            this.controllerBoxThree.TabStop = false;
            // 
            // optionsThree
            // 
            this.optionsThree.Image = global::XOutput.Properties.Resources.gear;
            this.optionsThree.Location = new System.Drawing.Point(6, 41);
            this.optionsThree.Name = "optionsThree";
            this.optionsThree.Size = new System.Drawing.Size(27, 23);
            this.optionsThree.TabIndex = 6;
            this.optionsThree.UseVisualStyleBackColor = true;
            // 
            // moveThreeUp
            // 
            this.moveThreeUp.Image = global::XOutput.Properties.Resources.arrow_Up;
            this.moveThreeUp.Location = new System.Drawing.Point(427, 12);
            this.moveThreeUp.Name = "moveThreeUp";
            this.moveThreeUp.Size = new System.Drawing.Size(27, 23);
            this.moveThreeUp.TabIndex = 4;
            this.moveThreeUp.UseVisualStyleBackColor = true;
            // 
            // moveThreeDown
            // 
            this.moveThreeDown.Image = global::XOutput.Properties.Resources.arrow_Down;
            this.moveThreeDown.Location = new System.Drawing.Point(427, 41);
            this.moveThreeDown.Name = "moveThreeDown";
            this.moveThreeDown.Size = new System.Drawing.Size(27, 23);
            this.moveThreeDown.TabIndex = 3;
            this.moveThreeDown.UseVisualStyleBackColor = true;
            // 
            // enabledThree
            // 
            this.enabledThree.AutoSize = true;
            this.enabledThree.Checked = true;
            this.enabledThree.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enabledThree.Location = new System.Drawing.Point(51, 209);
            this.enabledThree.Name = "enabledThree";
            this.enabledThree.Size = new System.Drawing.Size(65, 17);
            this.enabledThree.TabIndex = 7;
            this.enabledThree.Text = "Enabled";
            this.enabledThree.UseVisualStyleBackColor = true;
            // 
            // controllerBoxFour
            // 
            this.controllerBoxFour.Controls.Add(this.optionsFour);
            this.controllerBoxFour.Controls.Add(this.moveFourUp);
            this.controllerBoxFour.Location = new System.Drawing.Point(12, 240);
            this.controllerBoxFour.Name = "controllerBoxFour";
            this.controllerBoxFour.Size = new System.Drawing.Size(460, 70);
            this.controllerBoxFour.TabIndex = 4;
            this.controllerBoxFour.TabStop = false;
            // 
            // optionsFour
            // 
            this.optionsFour.Image = global::XOutput.Properties.Resources.gear;
            this.optionsFour.Location = new System.Drawing.Point(6, 41);
            this.optionsFour.Name = "optionsFour";
            this.optionsFour.Size = new System.Drawing.Size(27, 23);
            this.optionsFour.TabIndex = 5;
            this.optionsFour.UseVisualStyleBackColor = true;
            // 
            // moveFourUp
            // 
            this.moveFourUp.Image = global::XOutput.Properties.Resources.arrow_Up;
            this.moveFourUp.Location = new System.Drawing.Point(427, 12);
            this.moveFourUp.Name = "moveFourUp";
            this.moveFourUp.Size = new System.Drawing.Size(27, 23);
            this.moveFourUp.TabIndex = 4;
            this.moveFourUp.UseVisualStyleBackColor = true;
            // 
            // enabledFour
            // 
            this.enabledFour.AutoSize = true;
            this.enabledFour.Checked = true;
            this.enabledFour.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enabledFour.Location = new System.Drawing.Point(51, 285);
            this.enabledFour.Name = "enabledFour";
            this.enabledFour.Size = new System.Drawing.Size(65, 17);
            this.enabledFour.TabIndex = 7;
            this.enabledFour.Text = "Enabled";
            this.enabledFour.UseVisualStyleBackColor = true;
            // 
            // isExclusive
            // 
            this.isExclusive.AutoSize = true;
            this.isExclusive.Location = new System.Drawing.Point(18, 320);
            this.isExclusive.Name = "isExclusive";
            this.isExclusive.Size = new System.Drawing.Size(75, 17);
            this.isExclusive.TabIndex = 9;
            this.isExclusive.Text = "Exclusivity";
            this.isExclusive.UseVisualStyleBackColor = true;
            this.isExclusive.CheckedChanged += new System.EventHandler(this.isExclusive_CheckedChanged);
            // 
            // XOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 351);
            this.Controls.Add(this.isExclusive);
            this.Controls.Add(this.enabledOne);
            this.Controls.Add(this.enabledTwo);
            this.Controls.Add(this.enabledThree);
            this.Controls.Add(this.enabledFour);
            this.Controls.Add(this.controllerBoxOne);
            this.Controls.Add(this.controllerBoxTwo);
            this.Controls.Add(this.controllerBoxThree);
            this.Controls.Add(this.controllerBoxFour);
            this.Controls.Add(this.StartStopBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "XOut";
            this.Text = "XOutput";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.XOut_Closing);
            this.Load += new System.EventHandler(this.XOut_Load);
            this.Shown += new System.EventHandler(this.XOut_Shown);
            this.controllerBoxOne.ResumeLayout(false);
            this.controllerBoxTwo.ResumeLayout(false);
            this.controllerBoxThree.ResumeLayout(false);
            this.controllerBoxFour.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartStopBtn;

        private System.Windows.Forms.GroupBox[] boxes;
        private System.Windows.Forms.CheckBox[] checks;
        private System.Windows.Forms.Button[] options;
        private ControllerOptions optionsWindow;
        private ControllerManager controllerManager;
        private System.Windows.Forms.GroupBox controllerBoxOne;
        private System.Windows.Forms.GroupBox controllerBoxTwo;
        private System.Windows.Forms.GroupBox controllerBoxThree;
        private System.Windows.Forms.GroupBox controllerBoxFour;
        private System.Windows.Forms.Button moveOneDown;
        private System.Windows.Forms.Button moveTwoUp;
        private System.Windows.Forms.Button moveTwoDown;
        private System.Windows.Forms.Button moveThreeUp;
        private System.Windows.Forms.Button moveThreeDown;
        private System.Windows.Forms.Button moveFourUp;
        private System.Windows.Forms.Button optionsOne;
        private System.Windows.Forms.Button optionsTwo;
        private System.Windows.Forms.Button optionsThree;
        private System.Windows.Forms.Button optionsFour;
        private System.Windows.Forms.CheckBox enabledOne;
        private System.Windows.Forms.CheckBox enabledTwo;
        private System.Windows.Forms.CheckBox enabledThree;
        private System.Windows.Forms.CheckBox enabledFour;
        private System.Windows.Forms.CheckBox isExclusive;
    }
}