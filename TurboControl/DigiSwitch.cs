using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

namespace TurboControl
{
	public delegate void DigiSwitchStateChangedHandler(DigiSwitch sender, bool newState, bool newLEDState);
	public delegate void DigiSwitchClickHandler(DigiSwitch sender);

	/// <summary>
	/// Visible Control resembling the german DigiTast of the seventies
	/// </summary>
	[
	 Designer(typeof(TurboControl.NoResizeDesigner)),
	 ToolboxBitmap(typeof(DigiSwitch), "Images.Designer.TurboControl.DigiSwitch.bmp")
     System.ComponentModel.DesignerCategory("")
    ]
    public class DigiSwitch : System.Windows.Forms.Control
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		protected DigiSwitchColors iColor = DigiSwitchColors.Red;
		protected DigiSwitchStyles iStyle = DigiSwitchStyles.Pure;

		protected bool iClosed = false;
		protected bool iStateLED = false;
		protected bool iAutoToggle = false;

		protected Bitmap ibmOpenOff;
		protected Bitmap ibmOpenOn;
		protected Bitmap ibmClosedOn;
		protected Bitmap ibmClosedOff;

		public event DigiSwitchStateChangedHandler StateChanged;
		public new event DigiSwitchClickHandler Click;

		protected System.Threading.Timer ClickTimer;

		public void AnimateClick() 
		{
			iClosed = true;
			if (Click != null) Click(this);
			this.Invalidate();
			ClickTimer = new System.Threading.Timer(new TimerCallback(this.AnimateClickEnd),
				null, 
				TimeSpan.FromMilliseconds(120), 
				TimeSpan.FromMilliseconds(120));
		}

		public void AnimateClickEnd(Object state) 
		{
			iClosed = false;
			this.Invalidate();
			ClickTimer.Dispose();
		}

		/// <summary>
		/// Initializes a red digiswitch without an LED
		/// </summary>
		public DigiSwitch()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitComponent call
			iColor = DigiSwitchColors.Red;
			iStyle = DigiSwitchStyles.Pure;

			this.SetDimensions();

			SetStyle(ControlStyles.UserPaint, true);
			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.ResizeRedraw, true);
			UpdateStyles();

			this.OpenBitmaps();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
			}

			if (ibmOpenOff != null) ibmOpenOff.Dispose();
			if (ibmOpenOn  != null) ibmOpenOn.Dispose();
			if (ibmClosedOff != null) ibmClosedOff.Dispose();
			if (ibmClosedOn  != null) ibmClosedOn.Dispose();

			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion

		[Browsable(false)]
		public override Font Font
		{
			get
			{
				return base.Font;
			}
			set
			{
				base.Font = value;
			}
		}

		[Browsable(false)]
		public override Image BackgroundImage
		{
			get
			{
				return base.BackgroundImage;
			}
			set
			{
				base.BackgroundImage = value;
			}
		}

		/// <summary>
		/// State of the LED. If the switch does not have an LED the value is stored anyway.
		/// </summary>
		[Description("LED State")]
		public bool StateLED 
		{
			get 
			{
				return iStateLED;
			}
			set 
			{
				if (iStateLED != value) 
				{
					iStateLED = value;
					this.Invalidate();
				}

			}
		}

		/// <summary>
		/// When set to true, the digiswitch will toggle the state of the LED each time it is left-clicked.
		/// </summary>
		[Description("Auto-Toggle LED on click")]
		public bool AutoToggle 
		{
			get 
			{
				return iAutoToggle;
			}
			set 
			{
				iAutoToggle= value;
			}
		}

		/// <summary>
		/// Color of the switch. It is available in commercial version colors.
		/// </summary>
		[
		Description("Color Style")
		]
		public TurboControl.DigiSwitchColors StyleColor
		{
			get 
			{
				return iColor;
			}
			set 
			{
				if (iColor != value) 
				{
					iColor = value;
					OpenBitmaps();
					this.Invalidate();
				}

			}
		}

		/// <summary>
		/// Display and color of the integrated LED.
		/// </summary>
		// [Category("Appearance")]
		[
		Description("LED Style")
		]
		public TurboControl.DigiSwitchStyles Style
		{
			get 
			{
				return iStyle;
			}
			set 
			{
				if (iStyle != value) 
				{
					iStyle = value;
					OpenBitmaps();
					this.Invalidate();
				}

			}
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown (e);
			iClosed = true;
			if (StateChanged != null) StateChanged(this,iClosed,iStateLED);
			this.Invalidate();
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp (e);
			iClosed = false;
			if (iAutoToggle) iStateLED = !iStateLED;
			if (StateChanged != null) StateChanged(this,iClosed,iStateLED);
			if (Click != null) Click(this);
			this.Invalidate();
		}



		/// <summary>
		/// Set Dimensions of the control from its properties.
		/// </summary>
		protected void SetDimensions()
		{
			this.Width = 20 + 2;
			this.Height = 30 + 2;
		}

		protected void ClearBitmapCache()
		{
			if (ibmOpenOff != null) 
			{
				ibmOpenOff.Dispose();
				ibmOpenOff = null;
			}

			if (ibmOpenOn != null) 
			{
				ibmOpenOn.Dispose();
				ibmOpenOn = null;
			}

			if (ibmClosedOff != null) 
			{
				ibmClosedOff.Dispose();
				ibmClosedOff = null;
			}

			if (ibmClosedOn != null) 
			{
				ibmClosedOn.Dispose();
				ibmClosedOn = null;
			}

		}


		/// <summary>
		/// Set up the needed bitmaps from the properties of the control.
		/// </summary>
		protected void OpenBitmaps() 
		{
			ClearBitmapCache();
			
			string mainstr = "TurboControl.Images.DigiSwitch.";
			string ledstr = "";
			string colstr = "red";
			
			if (iColor == DigiSwitchColors.Green) colstr = "green";
			else if (iColor == DigiSwitchColors.Blue) colstr = "blue";
			else if (iColor == DigiSwitchColors.Black) colstr = "black";
			else if (iColor == DigiSwitchColors.Yellow) colstr = "yellow";

			if (iStyle == DigiSwitchStyles.RedLED) ledstr = "_redled";
			if (iStyle == DigiSwitchStyles.GreenLED) ledstr = "_greenled";
				
			if (iStyle == DigiSwitchStyles.Pure) 
			{
				ibmOpenOff   = new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream(mainstr + colstr + "_open.bmp"));
				ibmOpenOn    = new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream(mainstr + colstr + "_open.bmp"));
				ibmClosedOff = new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream(mainstr + colstr + "_closed.bmp"));
				ibmClosedOn  = new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream(mainstr + colstr + "_closed.bmp"));
			} 
			else
			{
				ibmOpenOff   = new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream(mainstr + colstr + "_open" + ledstr + "_off.bmp"));
				ibmOpenOn    = new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream(mainstr + colstr + "_open" + ledstr + "_on.bmp"));
				ibmClosedOff = new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream(mainstr + colstr + "_closed" + ledstr + "_off.bmp"));
				ibmClosedOn  = new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream(mainstr + colstr + "_closed" + ledstr + "_on.bmp"));
			}
		}

		private int max ( int a, int b)
		{
			if (a>b) return a;
			return b;
		}

		private int min ( int a, int b)
		{
			if (b>a) return a;
			return b;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			//base.OnPaint (e);
			Color ColorTopLeft = Color.FromArgb(max(BackColor.R / 2,0),max(BackColor.G / 2,0),max(BackColor.B / 2,0));
			Color ColorBottomRight = Color.FromArgb(min((int)(BackColor.R * 1.5),255),min((int)(BackColor.G * 1.5),255),min((int)(BackColor.B * 1.5),255));

			Pen PenTopLeft = new Pen(new SolidBrush(ColorTopLeft),1);
			Pen PenBottomRight = new Pen(new SolidBrush(ColorBottomRight),1);

			e.Graphics.DrawRectangle(PenBottomRight,0,0,this.Width-1,this.Height-1);
			e.Graphics.DrawRectangle(PenTopLeft,0,0,this.Width-2,this.Height-2);
			

			if (iClosed) 
			{
				if (iStateLED) 
				{
					e.Graphics.DrawImage(ibmClosedOn,1,1,this.Width-2,this.Height-2);
				} 
				else 
				{
					e.Graphics.DrawImage(ibmClosedOff,1,1,this.Width-2,this.Height-2);
				}
			} 
			else 
			{
				if (iStateLED) 
				{
					e.Graphics.DrawImage(ibmOpenOn,1,1,this.Width-2,this.Height-2);
				} 
				else 
				{
					e.Graphics.DrawImage(ibmOpenOff,1,1,this.Width-2,this.Height-2);
				}
			}

		}


	}

	/// <summary>
	/// Color options used for digiswitch controls.
	/// </summary>
	public enum DigiSwitchColors 
	{
		Black,
		Blue,
		Green,
		Red,
		Yellow
	}

	/// <summary>
	/// LED color options for digiswitch controls.
	/// </summary>
	public enum DigiSwitchStyles
	{
		Pure,
		RedLED,
		GreenLED
	}
		
}
