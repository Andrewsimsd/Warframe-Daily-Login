namespace WarframeDailyLogin
{
    partial class Form1
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
            this.tbGamePath = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.btnBrowseGamePath = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGetMousePoint = new System.Windows.Forms.Button();
            this.gbClickLocations = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDelay = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbLauncherY = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbLauncherX = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbExitWaitTime = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbGameLoadTime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbLauncherLoadTime = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbLoginTimeSeconds = new System.Windows.Forms.TextBox();
            this.tbLoginTimeMinutes = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbLoginTimeHours = new System.Windows.Forms.TextBox();
            this.gbClickLocations.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbGamePath
            // 
            this.tbGamePath.Location = new System.Drawing.Point(12, 32);
            this.tbGamePath.Name = "tbGamePath";
            this.tbGamePath.Size = new System.Drawing.Size(402, 20);
            this.tbGamePath.TabIndex = 0;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(12, 71);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(402, 20);
            this.tbPassword.TabIndex = 1;
            // 
            // btnBrowseGamePath
            // 
            this.btnBrowseGamePath.Location = new System.Drawing.Point(420, 30);
            this.btnBrowseGamePath.Name = "btnBrowseGamePath";
            this.btnBrowseGamePath.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseGamePath.TabIndex = 2;
            this.btnBrowseGamePath.Text = "Browse";
            this.btnBrowseGamePath.UseVisualStyleBackColor = true;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(480, 310);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(135, 55);
            this.btnRun.TabIndex = 3;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Game Path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password";
            // 
            // btnGetMousePoint
            // 
            this.btnGetMousePoint.Location = new System.Drawing.Point(28, 45);
            this.btnGetMousePoint.Name = "btnGetMousePoint";
            this.btnGetMousePoint.Size = new System.Drawing.Size(113, 23);
            this.btnGetMousePoint.TabIndex = 6;
            this.btnGetMousePoint.Text = "Get Mouse Point";
            this.btnGetMousePoint.UseVisualStyleBackColor = true;
            this.btnGetMousePoint.Click += new System.EventHandler(this.btnGetMousePoint_Click);
            // 
            // gbClickLocations
            // 
            this.gbClickLocations.Controls.Add(this.label3);
            this.gbClickLocations.Controls.Add(this.tbDelay);
            this.gbClickLocations.Controls.Add(this.label5);
            this.gbClickLocations.Controls.Add(this.tbLauncherY);
            this.gbClickLocations.Controls.Add(this.label4);
            this.gbClickLocations.Controls.Add(this.tbLauncherX);
            this.gbClickLocations.Controls.Add(this.btnGetMousePoint);
            this.gbClickLocations.Location = new System.Drawing.Point(12, 97);
            this.gbClickLocations.Name = "gbClickLocations";
            this.gbClickLocations.Size = new System.Drawing.Size(402, 83);
            this.gbClickLocations.TabIndex = 7;
            this.gbClickLocations.TabStop = false;
            this.gbClickLocations.Text = "Launcher Start Button Location";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(157, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Delay (Seconds)";
            // 
            // tbDelay
            // 
            this.tbDelay.Location = new System.Drawing.Point(248, 47);
            this.tbDelay.Name = "tbDelay";
            this.tbDelay.Size = new System.Drawing.Size(54, 20);
            this.tbDelay.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(76, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Y:";
            // 
            // tbLauncherY
            // 
            this.tbLauncherY.Location = new System.Drawing.Point(99, 19);
            this.tbLauncherY.Name = "tbLauncherY";
            this.tbLauncherY.Size = new System.Drawing.Size(42, 20);
            this.tbLauncherY.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "X:";
            // 
            // tbLauncherX
            // 
            this.tbLauncherX.Location = new System.Drawing.Point(28, 19);
            this.tbLauncherX.Name = "tbLauncherX";
            this.tbLauncherX.Size = new System.Drawing.Size(42, 20);
            this.tbLauncherX.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbExitWaitTime);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbGameLoadTime);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbLauncherLoadTime);
            this.groupBox1.Location = new System.Drawing.Point(12, 186);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 100);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Wait Times";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Exit Wait Time (Seconds):";
            // 
            // tbExitWaitTime
            // 
            this.tbExitWaitTime.Location = new System.Drawing.Point(168, 71);
            this.tbExitWaitTime.Name = "tbExitWaitTime";
            this.tbExitWaitTime.Size = new System.Drawing.Size(42, 20);
            this.tbExitWaitTime.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Game Load Time (Seconds):";
            // 
            // tbGameLoadTime
            // 
            this.tbGameLoadTime.Location = new System.Drawing.Point(168, 45);
            this.tbGameLoadTime.Name = "tbGameLoadTime";
            this.tbGameLoadTime.Size = new System.Drawing.Size(42, 20);
            this.tbGameLoadTime.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(159, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Launcher Load Time (Seconds):";
            // 
            // tbLauncherLoadTime
            // 
            this.tbLauncherLoadTime.Location = new System.Drawing.Point(168, 19);
            this.tbLauncherLoadTime.Name = "tbLauncherLoadTime";
            this.tbLauncherLoadTime.Size = new System.Drawing.Size(42, 20);
            this.tbLauncherLoadTime.TabIndex = 14;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.tbLoginTimeSeconds);
            this.groupBox2.Controls.Add(this.tbLoginTimeMinutes);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.tbLoginTimeHours);
            this.groupBox2.Location = new System.Drawing.Point(12, 292);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(164, 73);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Daily Login Time";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label13.Location = new System.Drawing.Point(111, 26);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(21, 13);
            this.label13.TabIndex = 27;
            this.label13.Text = "SS";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label12.Location = new System.Drawing.Point(61, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(25, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "MM";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(90, 38);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(15, 24);
            this.label11.TabIndex = 25;
            this.label11.Text = ":";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(45, 38);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 24);
            this.label10.TabIndex = 24;
            this.label10.Text = ":";
            // 
            // tbLoginTimeSeconds
            // 
            this.tbLoginTimeSeconds.Location = new System.Drawing.Point(110, 42);
            this.tbLoginTimeSeconds.Name = "tbLoginTimeSeconds";
            this.tbLoginTimeSeconds.Size = new System.Drawing.Size(22, 20);
            this.tbLoginTimeSeconds.TabIndex = 23;
            // 
            // tbLoginTimeMinutes
            // 
            this.tbLoginTimeMinutes.Location = new System.Drawing.Point(62, 42);
            this.tbLoginTimeMinutes.Name = "tbLoginTimeMinutes";
            this.tbLoginTimeMinutes.Size = new System.Drawing.Size(22, 20);
            this.tbLoginTimeMinutes.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "HH";
            // 
            // tbLoginTimeHours
            // 
            this.tbLoginTimeHours.Location = new System.Drawing.Point(19, 42);
            this.tbLoginTimeHours.Name = "tbLoginTimeHours";
            this.tbLoginTimeHours.Size = new System.Drawing.Size(22, 20);
            this.tbLoginTimeHours.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 374);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbClickLocations);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnBrowseGamePath);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbGamePath);
            this.Name = "Form1";
            this.Text = "Form1";
            this.gbClickLocations.ResumeLayout(false);
            this.gbClickLocations.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbGamePath;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Button btnBrowseGamePath;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGetMousePoint;
        private System.Windows.Forms.GroupBox gbClickLocations;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbLauncherY;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbLauncherX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDelay;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbLauncherLoadTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbExitWaitTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbGameLoadTime;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbLoginTimeSeconds;
        private System.Windows.Forms.TextBox tbLoginTimeMinutes;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbLoginTimeHours;
    }
}

