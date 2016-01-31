namespace TurboControlTest
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.segmentDisplayCounter = new TurboControl.SegmentDisplay();
            this.matrixDisplayBottom = new TurboControl.MatrixDisplay();
            this.digiSwitch4 = new TurboControl.DigiSwitch();
            this.digiSwitch3 = new TurboControl.DigiSwitch();
            this.digiSwitch2 = new TurboControl.DigiSwitch();
            this.glowSwitchMasterWarning = new TurboControl.GlowSwitch();
            this.glowSwitchYES = new TurboControl.GlowSwitch();
            this.glowSwitchNO = new TurboControl.GlowSwitch();
            this.segmentDisplayClock = new TurboControl.SegmentDisplay();
            this.matrixDisplayTop = new TurboControl.MatrixDisplay();
            this.digiSwitch1 = new TurboControl.DigiSwitch();
            this.digiSwitch = new TurboControl.DigiSwitch();
            this.glowSwitchOK = new TurboControl.GlowSwitch();
            this.glowSwitchERROR = new TurboControl.GlowSwitch();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.digiSwitchClock = new TurboControl.DigiSwitch();
            this.digiSwitchCounter = new TurboControl.DigiSwitch();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.timer1Sec = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // segmentDisplayCounter
            // 
            this.segmentDisplayCounter.BackColor = System.Drawing.Color.Black;
            this.segmentDisplayCounter.Columns = 8;
            this.segmentDisplayCounter.ForeColor = System.Drawing.Color.Red;
            this.segmentDisplayCounter.FrameStyle = TurboControl.FrameStyles.WOPR;
            this.segmentDisplayCounter.FrameWidth = 1;
            this.segmentDisplayCounter.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.segmentDisplayCounter.Location = new System.Drawing.Point(6, 87);
            this.segmentDisplayCounter.Name = "segmentDisplayCounter";
            this.segmentDisplayCounter.SegmentStyle = TurboControl.SegmentStyle.SevenUpright;
            this.segmentDisplayCounter.Size = new System.Drawing.Size(160, 60);
            this.segmentDisplayCounter.TabIndex = 13;
            this.segmentDisplayCounter.Text = "324";
            // 
            // matrixDisplayBottom
            // 
            this.matrixDisplayBottom.BackColor = System.Drawing.Color.LawnGreen;
            this.matrixDisplayBottom.Columns = 14;
            this.matrixDisplayBottom.FrameStyle = TurboControl.FrameStyles.WOPR;
            this.matrixDisplayBottom.InactiveColor = System.Drawing.Color.LimeGreen;
            this.matrixDisplayBottom.Location = new System.Drawing.Point(18, 130);
            this.matrixDisplayBottom.Name = "matrixDisplayBottom";
            this.matrixDisplayBottom.Rows = 4;
            this.matrixDisplayBottom.Size = new System.Drawing.Size(236, 112);
            this.matrixDisplayBottom.StyleHorizontal = TurboControl.HorizontalStyles.Triple;
            this.matrixDisplayBottom.TabIndex = 12;
            // 
            // digiSwitch4
            // 
            this.digiSwitch4.AutoToggle = false;
            this.digiSwitch4.Location = new System.Drawing.Point(89, 267);
            this.digiSwitch4.Name = "digiSwitch4";
            this.digiSwitch4.Size = new System.Drawing.Size(22, 32);
            this.digiSwitch4.StateLED = false;
            this.digiSwitch4.Style = TurboControl.DigiSwitchStyles.GreenLED;
            this.digiSwitch4.StyleColor = TurboControl.DigiSwitchColors.Green;
            this.digiSwitch4.TabIndex = 10;
            this.digiSwitch4.Text = "digiSwitch4";
            this.digiSwitch4.Click += new TurboControl.DigiSwitchClickHandler(this.digiSwitch4_Click);
            // 
            // digiSwitch3
            // 
            this.digiSwitch3.AutoToggle = false;
            this.digiSwitch3.Location = new System.Drawing.Point(67, 267);
            this.digiSwitch3.Name = "digiSwitch3";
            this.digiSwitch3.Size = new System.Drawing.Size(22, 32);
            this.digiSwitch3.StateLED = false;
            this.digiSwitch3.Style = TurboControl.DigiSwitchStyles.GreenLED;
            this.digiSwitch3.StyleColor = TurboControl.DigiSwitchColors.Green;
            this.digiSwitch3.TabIndex = 9;
            this.digiSwitch3.Text = "digiSwitch3";
            this.digiSwitch3.Click += new TurboControl.DigiSwitchClickHandler(this.digiSwitch3_Click);
            // 
            // digiSwitch2
            // 
            this.digiSwitch2.AutoToggle = false;
            this.digiSwitch2.Location = new System.Drawing.Point(45, 267);
            this.digiSwitch2.Name = "digiSwitch2";
            this.digiSwitch2.Size = new System.Drawing.Size(22, 32);
            this.digiSwitch2.StateLED = false;
            this.digiSwitch2.Style = TurboControl.DigiSwitchStyles.GreenLED;
            this.digiSwitch2.StyleColor = TurboControl.DigiSwitchColors.Green;
            this.digiSwitch2.TabIndex = 8;
            this.digiSwitch2.Text = "digiSwitch2";
            this.digiSwitch2.Click += new TurboControl.DigiSwitchClickHandler(this.digiSwitch2_Click);
            // 
            // glowSwitchMasterWarning
            // 
            this.glowSwitchMasterWarning.Active = false;
            this.glowSwitchMasterWarning.AutoHighlight = true;
            this.glowSwitchMasterWarning.ColorScheme = TurboControl.GlowSwitchColorScheme.Red;
            this.glowSwitchMasterWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.glowSwitchMasterWarning.ForeColor = System.Drawing.Color.Firebrick;
            this.glowSwitchMasterWarning.FrameWidth = 2;
            this.glowSwitchMasterWarning.GlareColor = System.Drawing.Color.OrangeRed;
            this.glowSwitchMasterWarning.HighlightColor = System.Drawing.Color.Red;
            this.glowSwitchMasterWarning.HorizontalAlignment = TurboControl.GlowSwitchHorizontalAlignment.Center;
            this.glowSwitchMasterWarning.ImageStyle = TurboControl.GlowSwitchImageStyle.Text;
            this.glowSwitchMasterWarning.Location = new System.Drawing.Point(22, 19);
            this.glowSwitchMasterWarning.Mask = ((System.Drawing.Bitmap)(resources.GetObject("glowSwitchMasterWarning.Mask")));
            this.glowSwitchMasterWarning.Name = "glowSwitchMasterWarning";
            this.glowSwitchMasterWarning.NumTag = 0;
            this.glowSwitchMasterWarning.OuterFrameColor = System.Drawing.Color.Maroon;
            this.glowSwitchMasterWarning.Size = new System.Drawing.Size(156, 51);
            this.glowSwitchMasterWarning.State = false;
            this.glowSwitchMasterWarning.SwitchColor = System.Drawing.Color.Maroon;
            this.glowSwitchMasterWarning.TabIndex = 6;
            this.glowSwitchMasterWarning.Text = "MASTER WARNING";
            this.glowSwitchMasterWarning.VerticalAlignment = TurboControl.GlowSwitchVerticalAlignment.Middle;
            this.glowSwitchMasterWarning.Click += new TurboControl.GlowSwitchClick(this.glowSwitchMasterWarning_Click);
            // 
            // glowSwitchYES
            // 
            this.glowSwitchYES.Active = true;
            this.glowSwitchYES.AutoHighlight = true;
            this.glowSwitchYES.ColorScheme = TurboControl.GlowSwitchColorScheme.Green;
            this.glowSwitchYES.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.glowSwitchYES.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(187)))), ((int)(((byte)(93)))));
            this.glowSwitchYES.FrameWidth = 3;
            this.glowSwitchYES.GlareColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(162)))), ((int)(((byte)(33)))));
            this.glowSwitchYES.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(42)))));
            this.glowSwitchYES.HorizontalAlignment = TurboControl.GlowSwitchHorizontalAlignment.Center;
            this.glowSwitchYES.ImageStyle = TurboControl.GlowSwitchImageStyle.Text;
            this.glowSwitchYES.Location = new System.Drawing.Point(22, 76);
            this.glowSwitchYES.Mask = null;
            this.glowSwitchYES.Name = "glowSwitchYES";
            this.glowSwitchYES.NumTag = 0;
            this.glowSwitchYES.OuterFrameColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(138)))), ((int)(((byte)(119)))));
            this.glowSwitchYES.Size = new System.Drawing.Size(75, 33);
            this.glowSwitchYES.State = false;
            this.glowSwitchYES.SwitchColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(74)))), ((int)(((byte)(22)))));
            this.glowSwitchYES.TabIndex = 5;
            this.glowSwitchYES.Text = "YES";
            this.glowSwitchYES.VerticalAlignment = TurboControl.GlowSwitchVerticalAlignment.Middle;
            this.glowSwitchYES.Click += new TurboControl.GlowSwitchClick(this.glowSwitchYES_Click);
            // 
            // glowSwitchNO
            // 
            this.glowSwitchNO.Active = false;
            this.glowSwitchNO.AutoHighlight = true;
            this.glowSwitchNO.ColorScheme = TurboControl.GlowSwitchColorScheme.Red;
            this.glowSwitchNO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.glowSwitchNO.ForeColor = System.Drawing.Color.Firebrick;
            this.glowSwitchNO.FrameWidth = 3;
            this.glowSwitchNO.GlareColor = System.Drawing.Color.OrangeRed;
            this.glowSwitchNO.HighlightColor = System.Drawing.Color.Red;
            this.glowSwitchNO.HorizontalAlignment = TurboControl.GlowSwitchHorizontalAlignment.Center;
            this.glowSwitchNO.ImageStyle = TurboControl.GlowSwitchImageStyle.Text;
            this.glowSwitchNO.Location = new System.Drawing.Point(103, 76);
            this.glowSwitchNO.Mask = null;
            this.glowSwitchNO.Name = "glowSwitchNO";
            this.glowSwitchNO.NumTag = 0;
            this.glowSwitchNO.OuterFrameColor = System.Drawing.Color.Maroon;
            this.glowSwitchNO.Size = new System.Drawing.Size(75, 33);
            this.glowSwitchNO.State = false;
            this.glowSwitchNO.SwitchColor = System.Drawing.Color.Maroon;
            this.glowSwitchNO.TabIndex = 4;
            this.glowSwitchNO.Text = "NO";
            this.glowSwitchNO.VerticalAlignment = TurboControl.GlowSwitchVerticalAlignment.Middle;
            this.glowSwitchNO.Click += new TurboControl.GlowSwitchClick(this.glowSwitchNO_Click);
            // 
            // segmentDisplayClock
            // 
            this.segmentDisplayClock.BackColor = System.Drawing.Color.Black;
            this.segmentDisplayClock.Columns = 8;
            this.segmentDisplayClock.ForeColor = System.Drawing.Color.Red;
            this.segmentDisplayClock.FrameStyle = TurboControl.FrameStyles.WOPR;
            this.segmentDisplayClock.FrameWidth = 1;
            this.segmentDisplayClock.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.segmentDisplayClock.Location = new System.Drawing.Point(6, 30);
            this.segmentDisplayClock.Name = "segmentDisplayClock";
            this.segmentDisplayClock.SegmentStyle = TurboControl.SegmentStyle.SevenUpright;
            this.segmentDisplayClock.Size = new System.Drawing.Size(160, 60);
            this.segmentDisplayClock.TabIndex = 3;
            this.segmentDisplayClock.Text = "09:38:15";
            // 
            // matrixDisplayTop
            // 
            this.matrixDisplayTop.BackColor = System.Drawing.Color.LawnGreen;
            this.matrixDisplayTop.Columns = 14;
            this.matrixDisplayTop.FrameStyle = TurboControl.FrameStyles.WOPR;
            this.matrixDisplayTop.InactiveColor = System.Drawing.Color.LimeGreen;
            this.matrixDisplayTop.Location = new System.Drawing.Point(18, 19);
            this.matrixDisplayTop.Name = "matrixDisplayTop";
            this.matrixDisplayTop.Rows = 4;
            this.matrixDisplayTop.Size = new System.Drawing.Size(236, 112);
            this.matrixDisplayTop.StyleHorizontal = TurboControl.HorizontalStyles.Triple;
            this.matrixDisplayTop.TabIndex = 2;
            // 
            // digiSwitch1
            // 
            this.digiSwitch1.AutoToggle = false;
            this.digiSwitch1.Location = new System.Drawing.Point(23, 267);
            this.digiSwitch1.Name = "digiSwitch1";
            this.digiSwitch1.Size = new System.Drawing.Size(22, 32);
            this.digiSwitch1.StateLED = true;
            this.digiSwitch1.Style = TurboControl.DigiSwitchStyles.GreenLED;
            this.digiSwitch1.StyleColor = TurboControl.DigiSwitchColors.Green;
            this.digiSwitch1.TabIndex = 0;
            this.digiSwitch1.Text = "digiSwitch1";
            this.digiSwitch1.Click += new TurboControl.DigiSwitchClickHandler(this.digiSwitch1_Click);
            // 
            // digiSwitch
            // 
            this.digiSwitch.AutoToggle = false;
            this.digiSwitch.Location = new System.Drawing.Point(132, 267);
            this.digiSwitch.Name = "digiSwitch";
            this.digiSwitch.Size = new System.Drawing.Size(22, 32);
            this.digiSwitch.StateLED = true;
            this.digiSwitch.Style = TurboControl.DigiSwitchStyles.RedLED;
            this.digiSwitch.StyleColor = TurboControl.DigiSwitchColors.Red;
            this.digiSwitch.TabIndex = 14;
            this.digiSwitch.Text = "digiSwitch5";
            this.digiSwitch.Click += new TurboControl.DigiSwitchClickHandler(this.digiSwitch_Click);
            // 
            // glowSwitchOK
            // 
            this.glowSwitchOK.Active = true;
            this.glowSwitchOK.AutoHighlight = true;
            this.glowSwitchOK.ColorScheme = TurboControl.GlowSwitchColorScheme.Green;
            this.glowSwitchOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.glowSwitchOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(187)))), ((int)(((byte)(93)))));
            this.glowSwitchOK.FrameWidth = 3;
            this.glowSwitchOK.GlareColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(162)))), ((int)(((byte)(33)))));
            this.glowSwitchOK.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(42)))));
            this.glowSwitchOK.HorizontalAlignment = TurboControl.GlowSwitchHorizontalAlignment.Center;
            this.glowSwitchOK.ImageStyle = TurboControl.GlowSwitchImageStyle.Text;
            this.glowSwitchOK.Location = new System.Drawing.Point(22, 115);
            this.glowSwitchOK.Mask = null;
            this.glowSwitchOK.Name = "glowSwitchOK";
            this.glowSwitchOK.NumTag = 0;
            this.glowSwitchOK.OuterFrameColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(138)))), ((int)(((byte)(119)))));
            this.glowSwitchOK.Size = new System.Drawing.Size(75, 33);
            this.glowSwitchOK.State = false;
            this.glowSwitchOK.SwitchColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(74)))), ((int)(((byte)(22)))));
            this.glowSwitchOK.TabIndex = 16;
            this.glowSwitchOK.Text = "OK";
            this.glowSwitchOK.VerticalAlignment = TurboControl.GlowSwitchVerticalAlignment.Middle;
            this.glowSwitchOK.Click += new TurboControl.GlowSwitchClick(this.glowSwitchOK_Click);
            // 
            // glowSwitchERROR
            // 
            this.glowSwitchERROR.Active = false;
            this.glowSwitchERROR.AutoHighlight = true;
            this.glowSwitchERROR.ColorScheme = TurboControl.GlowSwitchColorScheme.Red;
            this.glowSwitchERROR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.glowSwitchERROR.ForeColor = System.Drawing.Color.Firebrick;
            this.glowSwitchERROR.FrameWidth = 3;
            this.glowSwitchERROR.GlareColor = System.Drawing.Color.OrangeRed;
            this.glowSwitchERROR.HighlightColor = System.Drawing.Color.Red;
            this.glowSwitchERROR.HorizontalAlignment = TurboControl.GlowSwitchHorizontalAlignment.Center;
            this.glowSwitchERROR.ImageStyle = TurboControl.GlowSwitchImageStyle.Text;
            this.glowSwitchERROR.Location = new System.Drawing.Point(103, 115);
            this.glowSwitchERROR.Mask = null;
            this.glowSwitchERROR.Name = "glowSwitchERROR";
            this.glowSwitchERROR.NumTag = 0;
            this.glowSwitchERROR.OuterFrameColor = System.Drawing.Color.Maroon;
            this.glowSwitchERROR.Size = new System.Drawing.Size(75, 33);
            this.glowSwitchERROR.State = false;
            this.glowSwitchERROR.SwitchColor = System.Drawing.Color.Maroon;
            this.glowSwitchERROR.TabIndex = 15;
            this.glowSwitchERROR.Text = "ERROR";
            this.glowSwitchERROR.VerticalAlignment = TurboControl.GlowSwitchVerticalAlignment.Middle;
            this.glowSwitchERROR.Click += new TurboControl.GlowSwitchClick(this.glowSwitchERROR_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.matrixDisplayTop);
            this.groupBox1.Controls.Add(this.matrixDisplayBottom);
            this.groupBox1.Controls.Add(this.digiSwitch4);
            this.groupBox1.Controls.Add(this.digiSwitch);
            this.groupBox1.Controls.Add(this.digiSwitch1);
            this.groupBox1.Controls.Add(this.digiSwitch2);
            this.groupBox1.Controls.Add(this.digiSwitch3);
            this.groupBox1.Location = new System.Drawing.Point(260, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 352);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // digiSwitchClock
            // 
            this.digiSwitchClock.AutoToggle = false;
            this.digiSwitchClock.Location = new System.Drawing.Point(172, 44);
            this.digiSwitchClock.Name = "digiSwitchClock";
            this.digiSwitchClock.Size = new System.Drawing.Size(22, 32);
            this.digiSwitchClock.StateLED = true;
            this.digiSwitchClock.Style = TurboControl.DigiSwitchStyles.RedLED;
            this.digiSwitchClock.StyleColor = TurboControl.DigiSwitchColors.Red;
            this.digiSwitchClock.TabIndex = 15;
            this.digiSwitchClock.Text = "digiSwitch6";
            this.digiSwitchClock.Click += new TurboControl.DigiSwitchClickHandler(this.digiSwitchClock_Click);
            // 
            // digiSwitchCounter
            // 
            this.digiSwitchCounter.AutoToggle = false;
            this.digiSwitchCounter.Location = new System.Drawing.Point(172, 105);
            this.digiSwitchCounter.Name = "digiSwitchCounter";
            this.digiSwitchCounter.Size = new System.Drawing.Size(22, 32);
            this.digiSwitchCounter.StateLED = true;
            this.digiSwitchCounter.Style = TurboControl.DigiSwitchStyles.RedLED;
            this.digiSwitchCounter.StyleColor = TurboControl.DigiSwitchColors.Red;
            this.digiSwitchCounter.TabIndex = 18;
            this.digiSwitchCounter.Text = "digiSwitch7";
            this.digiSwitchCounter.Click += new TurboControl.DigiSwitchClickHandler(this.digiSwitchCounter_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.glowSwitchMasterWarning);
            this.groupBox2.Controls.Add(this.glowSwitchNO);
            this.groupBox2.Controls.Add(this.glowSwitchYES);
            this.groupBox2.Controls.Add(this.glowSwitchERROR);
            this.groupBox2.Controls.Add(this.glowSwitchOK);
            this.groupBox2.Location = new System.Drawing.Point(34, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 162);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.segmentDisplayClock);
            this.groupBox3.Controls.Add(this.segmentDisplayCounter);
            this.groupBox3.Controls.Add(this.digiSwitchCounter);
            this.groupBox3.Controls.Add(this.digiSwitchClock);
            this.groupBox3.Location = new System.Drawing.Point(34, 201);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 172);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            // 
            // timer1Sec
            // 
            this.timer1Sec.Enabled = true;
            this.timer1Sec.Interval = 1000;
            this.timer1Sec.Tick += new System.EventHandler(this.timer1Sec_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(566, 403);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "TurboControlTest";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TurboControl.DigiSwitch digiSwitch1;
        private TurboControl.MatrixDisplay matrixDisplayTop;
        private TurboControl.SegmentDisplay segmentDisplayClock;
        private TurboControl.GlowSwitch glowSwitchNO;
        private TurboControl.GlowSwitch glowSwitchYES;
        private TurboControl.GlowSwitch glowSwitchMasterWarning;
        private TurboControl.DigiSwitch digiSwitch2;
        private TurboControl.DigiSwitch digiSwitch3;
        private TurboControl.DigiSwitch digiSwitch4;
        private TurboControl.MatrixDisplay matrixDisplayBottom;
        private TurboControl.SegmentDisplay segmentDisplayCounter;
        private TurboControl.DigiSwitch digiSwitch;
        private TurboControl.GlowSwitch glowSwitchOK;
        private TurboControl.GlowSwitch glowSwitchERROR;
        private System.Windows.Forms.GroupBox groupBox1;
        private TurboControl.DigiSwitch digiSwitchClock;
        private TurboControl.DigiSwitch digiSwitchCounter;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Timer timer1Sec;
    }
}

