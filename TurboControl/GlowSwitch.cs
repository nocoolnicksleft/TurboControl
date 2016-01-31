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
	public delegate void GlowSwitchStateChangedHandler(GlowSwitch sender, bool newState);
	public delegate void GlowSwitchClick(GlowSwitch sender);

	/// <summary>
	/// Summary description for GlowSwitch.
	/// </summary>
	/// 
	[ToolboxBitmap(typeof(GlowSwitch), "Images.Designer.TurboControl.GlowSwitch.bmp")]
    [System.ComponentModel.DesignerCategory("")]
    public class GlowSwitch : System.Windows.Forms.Control
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		protected Bitmap bmNormal;
		protected Bitmap bmActive;
		protected Bitmap bmHighlighted;
		protected Bitmap bmMask;

		protected int iNumTag;


		protected Color iSwitchColor;
		protected Color iOuterFrameColor;
		protected Color iHighlightColor;
		protected Color iGlareColor;

		protected int iFrameWidth = 1;
		protected int iMinimumHeight = 9;
		protected int iMinimumWidth = 9;

		protected GlowSwitchHorizontalAlignment iHorizontalAlignment = GlowSwitchHorizontalAlignment.Center;
		protected GlowSwitchVerticalAlignment iVerticalAlignment = GlowSwitchVerticalAlignment.Middle;
		
		protected bool iState = false;
		protected bool iActive = false;
		protected bool iAutoHighlight = true;
		protected GlowSwitchColorScheme iColorScheme = GlowSwitchColorScheme.Green;
		protected GlowSwitchImageStyle iImageStyle = GlowSwitchImageStyle.Text;

		public event GlowSwitchStateChangedHandler StateChanged;
		public new event GlowSwitchClick Click;

		protected System.Threading.Timer ClickTimer;

		public void AnimateClick() 
		{
			iState = true;
			if (Click != null) Click(this);
			this.Invalidate();
			ClickTimer = new System.Threading.Timer(new TimerCallback(this.AnimateClickEnd),
				null, 
				TimeSpan.FromMilliseconds(120), 
				TimeSpan.FromMilliseconds(120));
			
		}

		public void AnimateClickEnd(Object state) 
		{
			iState = false;
			this.Invalidate();
			ClickTimer.Dispose();
		}

		

		[Description("Numeric Tag")]
		public int NumTag
		{
			get 
			{
				return iNumTag;
			}
			set 
			{
				iNumTag = value;
			}
		}

		[Category("Misc")]
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
				ClearBitmapCache();
				this.Invalidate();
			}
		}

		[Category("Misc")]
		public override Font Font
		{
			get
			{
				return base.Font;
			}
			set
			{
				base.Font = value;
				ClearBitmapCache();
				this.Invalidate();
			}
		}

		[Category("Misc")]
		public GlowSwitchHorizontalAlignment HorizontalAlignment 
		{
			get 
			{
				return iHorizontalAlignment;
			}
			set 
			{
				iHorizontalAlignment = value;
				ClearBitmapCache();
				this.Invalidate();
			}

		}
		
		[Category("Misc")]
		public GlowSwitchVerticalAlignment VerticalAlignment 
		{
			get 
			{
				return iVerticalAlignment;
			}
			set 
			{
				iVerticalAlignment = value;
				ClearBitmapCache();
				this.Invalidate();
			}

		}
		
		/*
		[Category("Misc")]
		[Description("General background color. Used for areas not covered by switch.")]
		public override Color BackColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				base.BackColor = value;
				ClearBitmapCache();
				this.Invalidate();
			}
		}
		*/


		[Category("Misc")]
		[Description("Forecolor used when switch is not pressed and not active. Can only be set when ColorScheme is set to 'Free'")]
		public override Color ForeColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				if (iColorScheme == GlowSwitchColorScheme.Free) 
				{
					base.ForeColor = value;
					ClearBitmapCache();
					this.Invalidate();
				}
			}
		}

		[Category("Misc")]
		[Description("Switch background color. Can only be set when ColorScheme is set to 'Free'")]
		public Color SwitchColor
		{
			get
			{
				return iSwitchColor;
			}
			set
			{
				if (iColorScheme == GlowSwitchColorScheme.Free) 
				{
					iSwitchColor = value;
					ClearBitmapCache();
					this.Invalidate();
				}
			}
		}

		[Category("Misc")]
		[Description("Color of outer side of switch frame. Can only be set when ColorScheme is set to 'Free'")]
		public Color OuterFrameColor
		{
			get
			{
				return iOuterFrameColor;
			}
			set
			{
				if (iColorScheme == GlowSwitchColorScheme.Free) 
				{
					iOuterFrameColor = value;
					ClearBitmapCache();
					this.Invalidate();
				}
			}
		}

		[Category("Misc")]
		[Description("Forecolor used when switch is pressed or active. Can only be set when ColorScheme is set to 'Free'")]
		public Color HighlightColor
		{
			get
			{
				return iHighlightColor;
			}
			set
			{
				if (iColorScheme == GlowSwitchColorScheme.Free) 
				{
					iHighlightColor = value;
					ClearBitmapCache();
					this.Invalidate();
				}
			}
		}

		[Category("Misc")]
		[Description("Color of glare displayed when switch is pressed. Can only be set when ColorScheme is set to 'Free'")]
		public Color GlareColor
		{
			get
			{
				return iGlareColor;
			}
			set
			{
				if (iColorScheme == GlowSwitchColorScheme.Free) 
				{
					iGlareColor = value;
					ClearBitmapCache();
					this.Invalidate();
				}
			}
		}

		[Description("Highlight State")]
		public bool State 
		{
			get 
			{
				return iState;
			}
			set 
			{
				iState = value;
				if (StateChanged != null) StateChanged(this,iState);
				this.Invalidate();
			}
		}

		[Description("Active State")]
		public bool Active
		{
			get 
			{
				return iActive;
			}
			set 
			{
				iActive = value;
				if (StateChanged != null) StateChanged(this,iState);
				this.Invalidate();
			}
		}

		[Description("Mask bitmap. Only black pixels are used for the button image.")]
		[RefreshProperties(RefreshProperties.Repaint)]
		public Bitmap Mask 
		{
			get 
			{
				return bmMask;
			}
			set 
			{
				bmMask = value;

				if (bmMask != null) 
				{
					iMinimumWidth = bmMask.Width + 8;
					iMinimumHeight = bmMask.Height + 8;
					this.Width = iMinimumWidth;
					this.Height = iMinimumHeight;
					ClearBitmapCache();
				}
				this.Invalidate();
			}
		}

		[Description("Width of outer frame")]
		public int FrameWidth
		{
			get 
			{
				return iFrameWidth;
			}
			set 
			{
				iFrameWidth = value;
				ClearBitmapCache();
				this.Invalidate();
			}
		}

		[Description("Change to highlight state while clicking")]
		public bool AutoHighlight
		{
			get 
			{
				return iAutoHighlight;
			}
			set 
			{
				iAutoHighlight = value;
				this.Invalidate();
			}
		}

		[Description("Global color scheme, set to 'Free' before selecting individual colors")]
		[RefreshProperties(RefreshProperties.Repaint)]
		public GlowSwitchColorScheme ColorScheme 
		{
			get 
			{ 
				return iColorScheme; 
			}
			set
			{
				if (value == GlowSwitchColorScheme.Green) 
				{
					this.iSwitchColor = System.Drawing.Color.FromArgb(((System.Byte)(6)), ((System.Byte)(74)), ((System.Byte)(22)));
					base.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(75)), ((System.Byte)(187)), ((System.Byte)(93)));;
					this.iHighlightColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(255)), ((System.Byte)(42)));
					this.iOuterFrameColor = System.Drawing.Color.FromArgb(((System.Byte)(116)), ((System.Byte)(138)), ((System.Byte)(119)));
					this.iGlareColor = System.Drawing.Color.FromArgb(((System.Byte)(3)), ((System.Byte)(162)), ((System.Byte)(33)));
				}

				if (value == GlowSwitchColorScheme.Red) 
				{
					this.iSwitchColor = Color.Maroon;
					base.ForeColor = Color.Firebrick;
					this.iHighlightColor = Color.Red;
					this.iOuterFrameColor = Color.Maroon;
					this.iGlareColor = Color.OrangeRed;
				}

				iColorScheme = value;
				ClearBitmapCache();
				this.Invalidate();
			}
		}

		[Description("Determines the way images are generated. May be fixed or user defined.")]
		[RefreshProperties(RefreshProperties.Repaint)]
		public GlowSwitchImageStyle ImageStyle 
		{
			get 
			{ 
				return iImageStyle; 
			}
			set
			{
				iImageStyle = value;
				ClearBitmapCache();
				this.Invalidate();
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

		protected void MakeBitmaps()
		{
				
			ClearBitmapCache();

			if ((iImageStyle < GlowSwitchImageStyle.Text )) 
			{
				string mainstr = "TurboControl.Images.GlowSwitch.Mask";
				
				string imgstr = "ArrowUp";
				if (iImageStyle == GlowSwitchImageStyle.ArrowUp) imgstr = "ArrowUp";
				if (iImageStyle == GlowSwitchImageStyle.ArrowDown) imgstr = "ArrowDown";
				if (iImageStyle == GlowSwitchImageStyle.ArrowLeft) imgstr = "ArrowLeft";
				if (iImageStyle == GlowSwitchImageStyle.ArrowRight) imgstr = "ArrowRight";

				this.bmMask = new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream( mainstr + imgstr + ".bmp"));
				iMinimumWidth = bmMask.Width + 8;
				iMinimumHeight = bmMask.Height + 8;
				if (this.Width < iMinimumWidth) this.Width = iMinimumWidth;
				if (this.Height < iMinimumHeight) this.Height = iMinimumHeight;

			} 

			if ((this.Width >= iMinimumWidth) & (this.Height >= iMinimumHeight)) 
			{

				int x;
				int y;
				int xoffset;
				int yoffset;
				
				bmNormal = new Bitmap(this.Width,this.Height);
				Graphics g = Graphics.FromImage(bmNormal);
					
				SolidBrush frameBrush = new SolidBrush(this.iOuterFrameColor);
				SolidBrush switchBrush = new SolidBrush(this.iSwitchColor);
				SolidBrush foreBrush = new SolidBrush(base.ForeColor);
				SolidBrush backBrush = new SolidBrush(base.BackColor);
					
				g.FillRectangle(switchBrush,0,0,this.Width, this.Height);
			
		
		
				if (iFrameWidth > 0) 
				{
					Color ColorBottomRight  = Color.FromArgb(max(iOuterFrameColor.R / 2,0),max(iOuterFrameColor.G / 2,0),max(iOuterFrameColor.B / 2,0));
					Color  ColorTopLeft = Color.FromArgb(min((int)(iOuterFrameColor.R * 1.5),255),min((int)(iOuterFrameColor.G * 1.5),255),min((int)(iOuterFrameColor.B * 1.5),255));

					Pen PenTopLeft = new Pen(new SolidBrush(ColorTopLeft),1);
					Pen PenBottomRight = new Pen(new SolidBrush(ColorBottomRight),1);

					g.DrawRectangle(PenBottomRight,0,0,this.Width-1,this.Height-1);
					g.DrawRectangle(PenTopLeft,0,0,this.Width-2,this.Height-2);

					Pen forePen = new Pen(foreBrush,iFrameWidth);
					g.DrawRectangle(forePen,1,1,bmNormal.Width-3, bmNormal.Height-3);
					forePen.Dispose();
				} 

					
				
				if ((this.bmMask != null) && (iImageStyle != GlowSwitchImageStyle.Text))
				{
					xoffset = 4;
					if (iHorizontalAlignment == GlowSwitchHorizontalAlignment.Center) xoffset = (this.Width - 4 - bmMask.Width) / 2 + 2;
					if (iHorizontalAlignment == GlowSwitchHorizontalAlignment.Right) xoffset = (this.Width - 4 - bmMask.Width);
						
					yoffset = 4;
					if (iVerticalAlignment == GlowSwitchVerticalAlignment.Middle) yoffset = (this.Height - 4 - bmMask.Height) / 2 + 2;
					if (iVerticalAlignment == GlowSwitchVerticalAlignment.Bottom) yoffset = (this.Height - 4 - bmMask.Height);
						
					for (y = 0; y < bmMask.Height; y++) 
					{
						for (x = 0; x < bmMask.Width; x++)
						{
							if (CompareColors(bmMask.GetPixel(x,y),Color.Black)) bmNormal.SetPixel(x+xoffset,y+yoffset,base.ForeColor);
							else bmNormal.SetPixel(x+xoffset,y+yoffset,this.iSwitchColor);
						}
					}
				} 
				else 
				{
					StringFormat sf = new StringFormat();
					if (iHorizontalAlignment == GlowSwitchHorizontalAlignment.Center) sf.Alignment = StringAlignment.Center;
					if (iHorizontalAlignment == GlowSwitchHorizontalAlignment.Right) sf.Alignment = StringAlignment.Far;
					SizeF ssize = g.MeasureString(this.Text,this.Font,this.Width-8,sf);

					yoffset = 4;
					if (iVerticalAlignment == GlowSwitchVerticalAlignment.Middle) yoffset = (this.Height - 4 - (int)ssize.Height) / 2 + 2;
					if (iVerticalAlignment == GlowSwitchVerticalAlignment.Bottom) yoffset = (this.Height - 4 - (int)ssize.Height);
						

					g.DrawString(this.Text,this.Font,foreBrush,new Rectangle(4,yoffset,this.Width-8,this.Height-4),sf);
				}
					
				g.Dispose();

				backBrush.Dispose();
				foreBrush.Dispose();
				switchBrush.Dispose();
				frameBrush.Dispose();


				// Aktive Variante: ForeColor durch HighlightColor ersetzen
				bmActive = new Bitmap(bmNormal);
				for (y = 0; y < bmActive.Height; y++) 
				{ 
					for (x = 0; x < bmActive.Width; x++) 
					{
						if (CompareColors(bmActive.GetPixel(x,y),base.ForeColor)) 
						{
							bmActive.SetPixel(x,y,this.iHighlightColor);
						} 
					}
				}
					

				// Gedrückte Variante: GlareColor um HighlightColor-Pixel platzieren
				bmHighlighted = new Bitmap(bmActive);
				for (y = (bmHighlighted.Height - 3); y > 3; y--) 
				{ 
					for (x = (bmHighlighted.Width - 3); x > 3; x--) 
					{
						bmHighlighted.SetPixel(x,y,bmHighlighted.GetPixel(x-1,y-1)); 
					}
				}
						
				for (y = 0; y < bmHighlighted.Height ; y++) 
				{ 
					for (x = 0; x < bmHighlighted.Width; x++) 
					{
						if (!CompareColors(bmHighlighted.GetPixel(x,y),iHighlightColor)) 
						{ 
							if (
								( (x < bmHighlighted.Width-1) && CompareColors(bmHighlighted.GetPixel(x+1,y),iHighlightColor) ) |
								( (x > 0) && CompareColors(bmHighlighted.GetPixel(x-1,y),iHighlightColor) ) |
								( (y < bmHighlighted.Height-1) && CompareColors(bmHighlighted.GetPixel(x,y+1),iHighlightColor) ) |
								( (y > 0) && CompareColors(bmHighlighted.GetPixel(x,y-1),iHighlightColor) ) |
								( ((x < bmHighlighted.Width-1) && (y < bmHighlighted.Height-1)) && CompareColors(bmHighlighted.GetPixel(x+1,y+1),iHighlightColor) ) | 
								( ((x < bmHighlighted.Width-1) && (y > 0)) && CompareColors(bmHighlighted.GetPixel(x+1,y-1),iHighlightColor) ) |
								( ((x > 0) && (y < bmHighlighted.Height-1)) && CompareColors(bmHighlighted.GetPixel(x-1,y+1),iHighlightColor) ) |
								( ((x > 0) && (y > 0)) && CompareColors(bmHighlighted.GetPixel(x-1,y-1),iHighlightColor) )
								)
							{
								bmHighlighted.SetPixel(x,y,this.iGlareColor);
							}
						} 
						else 
						{
							
						}
					}

				}					
			}
		}

		public static bool CompareColors(Color a, Color b)
		{
			if(a.R == b.R && a.G==b.G && a.B==b.B)
				return true;
			return false;
		}


		public void ClearBitmapCache()
		{
			if (bmNormal != null) 
			{
				bmNormal.Dispose();
				bmNormal = null;
			}
			if (bmActive != null) 
			{
				bmActive.Dispose();
				bmActive = null; 
			}
			if (bmHighlighted != null) 
			{
				bmHighlighted.Dispose();
				bmHighlighted = null; 
			}
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			ClearBitmapCache();
			this.Invalidate();
		}


		public GlowSwitch()
		{
			// Required for Windows.Forms Class Composition Designer support
			InitializeComponent();

            ColorScheme = GlowSwitchColorScheme.Green;

			SetStyle(ControlStyles.UserPaint, true);
			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.ResizeRedraw, true);
			UpdateStyles();

			MakeBitmaps();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
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

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown (e);
			if (iAutoHighlight) 
			{
				iState = true;
				if (StateChanged != null) StateChanged(this,iState);
				this.Invalidate();
			}
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp (e);
			if (iAutoHighlight) 
			{
				iState = false;
				if (StateChanged != null) StateChanged(this,iState);
				this.Invalidate();
			}
			if (Click != null) Click(this);
		}



		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			base.OnPaintBackground (pevent);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (iState) 
			{
				if (bmHighlighted == null) MakeBitmaps();
				if (bmHighlighted != null) 
				{
					e.Graphics.DrawImage(bmHighlighted,0,0,bmHighlighted.Width,bmHighlighted.Height);
					//Win32.TurboBitmapCopy(e.Graphics,bmHighlighted,0,0);
				}
			} 
			else 
			{
				if (iActive) 
				{
					if (bmActive == null) MakeBitmaps();
					if (bmActive != null) 
					{
						e.Graphics.DrawImage(bmActive,0,0,bmActive.Width,bmActive.Height);
						//Win32.TurboBitmapCopy(e.Graphics,bmActive,0,0);
					}
				} 
				else 
				{
					if (bmNormal == null) MakeBitmaps();
					if (bmNormal != null) 
					{
						e.Graphics.DrawImage(bmNormal,0,0,bmNormal.Width,bmNormal.Height);
						//Win32.TurboBitmapCopy(e.Graphics,bmNormal,0,0);
					}
				}
			}
		}

		protected override void WndProc(ref Message m) 
		{
			if (m.Msg == Win32.WM_WINDOWPOSCHANGING) 
			{
				WM_PosChanging lParam;
				lParam = (WM_PosChanging) m.GetLParam(typeof(WM_PosChanging));
				
				if (lParam.cX < iMinimumWidth) lParam.cX = iMinimumWidth;
				if (lParam.cY < iMinimumHeight) lParam.cY = iMinimumHeight;

				Marshal.StructureToPtr(lParam, m.LParam, true);
			}
			base.WndProc(ref m);
		}


	}

	
	public enum GlowSwitchVerticalAlignment 
	{
		Top,
		Middle,
		Bottom
	}

	public enum GlowSwitchHorizontalAlignment 
	{
		Left,
		Center,
		Right
	}
	
	public enum GlowSwitchColorScheme 
	{
		Green,
		Red,
		Free
	}

	public enum GlowSwitchImageStyle
	{
		ArrowUp,
		ArrowDown,
		ArrowLeft,
		ArrowRight,
		Text,
		Bitmap
	}
}
