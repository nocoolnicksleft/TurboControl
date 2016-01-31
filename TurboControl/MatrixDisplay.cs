using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.IO;
using System.Reflection;



namespace TurboControl
{

	/// <summary>
	/// Display Control in the style of early five-by-seven matrix displays
	/// </summary>
	/// 
	[
	 Designer(typeof(TurboControl.NoResizeDesigner)),
	 ToolboxBitmap(typeof(MatrixDisplay), "Images.Designer.TurboControl.MatrixDisplay.bmp")
	]
    [System.ComponentModel.DesignerCategory("")]
    public class MatrixDisplay : System.Windows.Forms.Control
	{
		protected const int MinCharacter = 32;
		protected const int MaxCharacter = 128;
		protected const int MaxColumns = 50;
		protected const int MaxRows = 30;

		protected int iColumns = 15;
		protected int iRows = 1;
		protected string iValue = "WOPR";
	
		protected Color iColorInactive = Color.Black;
		protected VerticalStyles iVerticalStyle = VerticalStyles.Scanlines;
		protected HorizontalStyles iHorizontalStyle = HorizontalStyles.Double;
		protected FrameStyles iFrameStyle = FrameStyles.Empty;

		protected int iFrameWidth = 5;
		protected int iFrameEffective = 5;

		protected bool iIntegrateDecimal = false;
		protected bool iIntegrateComma = false;
		protected bool iAlwaysAlignRight = false;

		protected int CharacterWidth = 14;
		protected int CharacterHeight = 18;

		protected int iCurrentRow = 0;

		protected ulong[] Bytecode;
		protected Bitmap[] CharacterBitmap = new Bitmap[MaxCharacter];
		protected int[,] CharacterCode = new int[MaxRows,MaxColumns];

		protected Rectangle FrameTop;
		protected Rectangle FrameLeft;
		protected Rectangle FrameRight;
		protected Rectangle FrameBottom;

		
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		
        /// <summary>
        /// General constructor
        /// </summary>
		public MatrixDisplay()
		{
			InitializeComponent();

			Bytecode = new ulong[MaxCharacter];

			this.SetDimensions();

			SetStyle(ControlStyles.UserPaint, true);
			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.ResizeRedraw, true);
			UpdateStyles();

			this.InitCharacterTable();
		}

        /// <summary>
        /// Build 7-bit ASCII character table
        /// </summary>
		protected virtual void InitCharacterTable() 
		{
			try 
			{
				Bytecode[32] = Convert.ToUInt64("00000000000000000000000000000000000",2);
				Bytecode[33] = Convert.ToUInt64("00100001000010000100001000000000100",2);
				Bytecode[34] = Convert.ToUInt64("01010010100000000000000000000000000",2);
				Bytecode[35] = Convert.ToUInt64("01010010101111101010111110101001010",2);
				Bytecode[36] = Convert.ToUInt64("00100011101010001110001010111000100",2);
				Bytecode[37] = Convert.ToUInt64("00000010010001000100010001001000000",2);
				Bytecode[38] = Convert.ToUInt64("00000011001001001100100111001001101",2);
				Bytecode[39] = Convert.ToUInt64("00100001000000000000000000000000000",2);
				Bytecode[40] = Convert.ToUInt64("00100010001000010000100000100000100",2);
				Bytecode[41] = Convert.ToUInt64("00100000100000100001000010001000100",2);
				Bytecode[42] = Convert.ToUInt64("00100001001010101110010101000100000",2);
				Bytecode[43] = Convert.ToUInt64("00000001000010011111001000010000000",2);
				Bytecode[44] = Convert.ToUInt64("00000000000000000000000000100010000",2);
				Bytecode[45] = Convert.ToUInt64("00000000000000011111000000000000000",2);
				Bytecode[46] = Convert.ToUInt64("00000000000000000000000000100000000",2);
				Bytecode[47] = Convert.ToUInt64("00000000010001000100010001000000000",2);
				Bytecode[48] = Convert.ToUInt64("01110100011001110101110011000101110",2);
				Bytecode[49] = Convert.ToUInt64("00100011000010000100001000010001110",2);
				Bytecode[50] = Convert.ToUInt64("01110100010001000100010001000011111",2);
				Bytecode[51] = Convert.ToUInt64("01110100010000100010000011000101110",2);
				Bytecode[52] = Convert.ToUInt64("00001000110010101001111110000100001",2);
				Bytecode[53] = Convert.ToUInt64("11111100001000011110000011000101110",2);
				Bytecode[54] = Convert.ToUInt64("01110100011000011110100011000101110",2);
				Bytecode[55] = Convert.ToUInt64("11111000010000100010001000100001000",2);
				Bytecode[56] = Convert.ToUInt64("01110100011000101110100011000101110",2);
				Bytecode[57] = Convert.ToUInt64("01110100011000101111000011000101110",2);
				Bytecode[58] = Convert.ToUInt64("00000001000010000000001000010000000",2);
				Bytecode[59] = Convert.ToUInt64("00000001000010000000001000010001000",2);
				Bytecode[60] = Convert.ToUInt64("00010001000100010000010000010000010",2);
				Bytecode[61] = Convert.ToUInt64("00000000001111100000111110000000000",2);
				Bytecode[62] = Convert.ToUInt64("01000001000001000001000100010001000",2);
				Bytecode[63] = Convert.ToUInt64("01110100010000100010001000000000100",2);
				Bytecode[64] = Convert.ToUInt64("01110100011110110101111101000001111",2);
				Bytecode[65] = Convert.ToUInt64("00100010101000110001111111000110001",2);
				Bytecode[66] = Convert.ToUInt64("11110100011000111110100011000111110",2);
				Bytecode[67] = Convert.ToUInt64("01110100011000010000100001000101110",2);
				Bytecode[68] = Convert.ToUInt64("11110100011000110001100011000111110",2);
				Bytecode[69] = Convert.ToUInt64("11111100001000011110100001000011111",2);
				Bytecode[70] = Convert.ToUInt64("11111100001000011110100001000010000",2);
				Bytecode[71] = Convert.ToUInt64("01110100011000010011100011000101110",2);
				Bytecode[72] = Convert.ToUInt64("10001100011000111111100011000110001",2);
				Bytecode[73] = Convert.ToUInt64("01110001000010000100001000010001110",2);
				Bytecode[74] = Convert.ToUInt64("00001000010000100001000011000101110",2);
				Bytecode[75] = Convert.ToUInt64("10001100101010011000101001001010001",2);
				Bytecode[76] = Convert.ToUInt64("10000100001000010000100001000011111",2);
				Bytecode[77] = Convert.ToUInt64("10001110111010110101100011000110001",2);
				Bytecode[78] = Convert.ToUInt64("10001100011100110101100111000110001",2);
				Bytecode[79] = Convert.ToUInt64("01110100011000110001100011000101110",2);
				Bytecode[80] = Convert.ToUInt64("11110100011000111110100001000010000",2);
				Bytecode[81] = Convert.ToUInt64("01110100011000110001101011001101110",2);
				Bytecode[82] = Convert.ToUInt64("11110100011000111110101001001010001",2);
				Bytecode[83] = Convert.ToUInt64("01110100011000001110000011000101110",2);
				Bytecode[84] = Convert.ToUInt64("11111001000010000100001000010000100",2);
				Bytecode[85] = Convert.ToUInt64("10001100011000110001100011000101110",2);
				Bytecode[86] = Convert.ToUInt64("10001100010101001010010100010000100",2);
				Bytecode[87] = Convert.ToUInt64("10001100011000110101101011101110001",2);
				Bytecode[88] = Convert.ToUInt64("10001100010101000100010101000110001",2);
				Bytecode[89] = Convert.ToUInt64("10001100010101000100001000010000100",2);
				Bytecode[90] = Convert.ToUInt64("11111000010001000100010001000011111",2);
				Bytecode[91] = Convert.ToUInt64("01110010000100001000010000100001110",2);
				Bytecode[92] = Convert.ToUInt64("00000100000100000100000100000100000",2);
				Bytecode[93] = Convert.ToUInt64("01110000100001000010000100001001110",2);
				Bytecode[94] = Convert.ToUInt64("00100010100000000000000000000000000",2);
				Bytecode[95] = Convert.ToUInt64("00000000000000000000000000000011111",2);
				Bytecode[96] = Convert.ToUInt64("01000001000000000000000000000000000",2);
				Bytecode[97] = Convert.ToUInt64("00000000000110110011100011001101101",2);
				Bytecode[98] = Convert.ToUInt64("10000100001011011001100011100110110",2);
				Bytecode[99] = Convert.ToUInt64("00000000000111010001100001000101110",2);
				Bytecode[100] = Convert.ToUInt64("00001000010110110011100011001101101",2);
				Bytecode[101] = Convert.ToUInt64("00000000000111010001111111000001111",2);
				Bytecode[102] = Convert.ToUInt64("00010001000010001110001000010000100",2);
				Bytecode[103] = Convert.ToUInt64("00000011101000110011011010000101110",2);
				Bytecode[104] = Convert.ToUInt64("10000100001011011001100011000110001",2);
				Bytecode[105] = Convert.ToUInt64("00000001000000000100001000010000100",2);
				Bytecode[106] = Convert.ToUInt64("00010000100001000010000100101000100",2);
				Bytecode[107] = Convert.ToUInt64("10000100001000110010101001101010001",2);
				Bytecode[108] = Convert.ToUInt64("00100001000010000100001000010000010",2);
				Bytecode[109] = Convert.ToUInt64("00000000000000011011101011010110101",2);
				Bytecode[110] = Convert.ToUInt64("00000000001011011001100011000110001",2);
				Bytecode[111] = Convert.ToUInt64("00000000000111010001100011000101110",2);
				Bytecode[112] = Convert.ToUInt64("00000101101100111001101101000010000",2);
				Bytecode[113] = Convert.ToUInt64("00000011011001110011011010000100001",2);
				Bytecode[114] = Convert.ToUInt64("00000000001011011000100001000010000",2);
				Bytecode[115] = Convert.ToUInt64("00000000000111110000011100000111110",2);
				Bytecode[116] = Convert.ToUInt64("00100001000010001110001000010000010",2);
				Bytecode[117] = Convert.ToUInt64("00000000001000110001100011001101101",2);
				Bytecode[118] = Convert.ToUInt64("00000000001000110001010100101000100",2);
				Bytecode[119] = Convert.ToUInt64("00000000001000110001101011101110001",2);
				Bytecode[120] = Convert.ToUInt64("00000000001000101010001000101010001",2);
				Bytecode[121] = Convert.ToUInt64("00000100011000110011011010000101110",2);
				Bytecode[122] = Convert.ToUInt64("00000000001111000010001000100011110",2);
				Bytecode[123] = Convert.ToUInt64("00100010000100010000010000100000100",2);
				Bytecode[124] = Convert.ToUInt64("00100001000010000100001000010000100",2);
				Bytecode[125] = Convert.ToUInt64("00100000100001000001000100001000100",2);
				Bytecode[126] = Convert.ToUInt64("01010101000000000000000000000000000",2);
				Bytecode[127] = Convert.ToUInt64("11111111111111111111111111111111111",2);
			}
			catch 
			{
				System.Diagnostics.Debug.WriteLine("Error in InitCharacterTable");
			}
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// 
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
		protected void InitializeComponent()
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


		[Category("Misc")]
		public Color InactiveColor
		{
			get
			{
				return iColorInactive;
			}
			set
			{
				iColorInactive = value;
				ClearBitmapCache();
				this.Invalidate();
			}
		}

		[Category("Misc")]
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


		[Category("Misc")]
		public override Color ForeColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				base.ForeColor = value;
				ClearBitmapCache();
				this.Invalidate();
			}
		}


		[
		 Category("Misc"),
		 Description("Displayed Text")
		]
		public override string Text
		{
			get 
			{
				return iValue;
			}
			
			set 
			{
				
				iValue = value;
				SetCharactersFromValue();				
				this.Invalidate();
			}
		}


		[Category("Misc")]
		[Description("Number of columns")]
		[DefaultValue(15)]
		public int Columns
		{
			get 
			{
				return iColumns; 
			}
			
			set 
			{
				if (value > MaxColumns) value = MaxColumns;
				iColumns = value;
				SetDimensions();
				this.Invalidate();
			}
		}


		[Description("Number of rows")]
		[DefaultValue(1)]
		public int Rows
		{
			get 
			{
				return iRows;
			}
			
			set 
			{
				if (value > MaxRows) value = MaxRows;
				iRows = value;
				this.SetDimensions();
				this.Invalidate();
			}
		}


		[Description("Vertical Style")]
		[DefaultValue(VerticalStyles.Scanlines)]
		public VerticalStyles StyleVertical
		{
			get 
			{
				return iVerticalStyle;
			}
			
			set 
			{
				iVerticalStyle = value;
				SetDimensions();
				ClearBitmapCache();
				this.Invalidate();
			}
		}


		[Description("Horizontal Style")]
		[DefaultValue(HorizontalStyles.Double)]
		public HorizontalStyles StyleHorizontal
		{
			get 
			{
				return iHorizontalStyle;
			}
			
			set 
			{
				iHorizontalStyle = value;
				SetDimensions();
				ClearBitmapCache();
				this.Invalidate();
			}
		}


		[Description("Frame Style")]
		[DefaultValue(FrameStyles.Empty)]
		public FrameStyles FrameStyle
		{
			get 
			{
				return iFrameStyle;
			}
			
			set 
			{
				iFrameStyle = value;
				SetDimensions();
				this.Invalidate();
			}
		}


		[Description("Frame Width")]
		[DefaultValue(5)]
		public int FrameWidth
		{
			get 
			{
				return iFrameWidth;
			}
			
			set 
			{
				iFrameWidth = value;
				SetDimensions();
				this.Invalidate();
			}
		}

        /// <summary>
        /// Scroll up
        /// </summary>
        /// <param name="n">Number of lines to scroll</param>
		public void Scroll(int n)
		{
			for (int i = 1; i <= n ; i++) 
			{
				for (int j = 0; j < iColumns; j++) 
				{
					CharacterCode[i-1,j] = CharacterCode[i,j];
					this.Invalidate(GetCharacterRectangle(i-1,j));
				}
			}
		}

        /// <summary>
        /// Write text and scroll up
        /// </summary>
        /// <param name="text"></param>
		public void WriteLine(string text) 
		{
			SetText(iCurrentRow,0,iColumns,false,text);
			if (iCurrentRow == iRows) Scroll(iCurrentRow);
			if (iCurrentRow < iRows) iCurrentRow++;
		}

        /// <summary>
        /// Write text to character position
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="width"></param>
        /// <param name="alignright"></param>
        /// <param name="text"></param>
        /// <returns></returns>
		public bool SetText(int row, int col, int width, bool alignright, string text)
		{	
			try 
			{
				int max = iColumns - col;

				if (text.Length > max) text = text.Substring(1,max);
				if (width > max) width = max;

				if (text.Length < width) 
				{
					if (alignright) 
					{
						text = text.PadLeft(width);
					} 
					else 
					{
						text = text.PadRight(width);
					}
				}

				for (int i = 0; i < text.Length ; i++) 
				{
					char c = text.ToCharArray()[i];
					SetCharacter(row,i + col,c);
				}
				return true;
			}
			catch 
			{
		   	    System.Diagnostics.Debug.WriteLine("Error in SetText");
				return false;
			}
		}

        /// <summary>
        /// Set character height according to vertical display mode 
        /// </summary>
		protected virtual void SetCharacterDimensions()
		{
			CharacterHeight = 18;
			if (iVerticalStyle == VerticalStyles.Compact) CharacterHeight = 9; 
		}

        /// <summary>
        /// Set dimensions from character position values
        /// </summary>
		protected void SetDimensions()
		{
			try 
			{
				this.SetCharacterDimensions();
				iFrameEffective = iFrameWidth;
				if (iFrameStyle == FrameStyles.None) iFrameEffective = 0;
				if (iFrameStyle == FrameStyles.WOPR) iFrameEffective = 20;
			
				this.Height= CharacterHeight * iRows + iFrameEffective * 2;
				this.Width = CharacterWidth * iColumns + iFrameEffective * 2;

				this.FrameTop = new Rectangle(0,0,this.Width,iFrameEffective);
				this.FrameLeft = new Rectangle(0,iFrameEffective,iFrameEffective,this.Height - iFrameEffective);
				this.FrameRight = new Rectangle(this.Width - iFrameEffective,iFrameEffective,iFrameEffective,this.Height - iFrameEffective);
				this.FrameBottom = new Rectangle(0,this.Height-iFrameEffective,this.Width,iFrameEffective);
			
				SetCharactersFromValue();
			}
			catch 
			{
				System.Diagnostics.Debug.WriteLine("Error in SetDimensions");
			}

		}

        /// <summary>
        /// Clear cached font bitmaps
        /// </summary>
		protected void ClearBitmapCache()
		{
			for (int i = 32; i < MaxCharacter; i++) 
			{
				CharacterBitmap[i] = null;
			}
		}

        /// <summary>
        /// Clear character buffer
        /// </summary>
		public void Clear()
		{
			for (int cy = 0; cy < iRows; cy++) 
			{
				for (int cx = 0; cx < iColumns; cx++) 
				{
					SetCharacter(cy,cx,(char)32 );
				}
			}
			iCurrentRow = 0;

		}

        /// <summary>
        /// 
        /// </summary>
		protected void SetCharactersFromValue()
		{
			try 
			{
				char c;
				char[] CharArray;
				int Source = 0;
				
				if (iAlwaysAlignRight) 
				{
					int maxcount = iColumns;
					if (iIntegrateDecimal && (iValue.IndexOf(",") != -1)) maxcount += 1;
					iValue = iValue.PadLeft(maxcount);
				}

				CharArray = iValue.ToCharArray();
				
				for (int i = 0; (i<iColumns) ; i++) 
				{
					if (Source<iValue.Length) 
					{
						c = CharArray[Source];	

						if (iIntegrateDecimal && (c >= '0') && (c <= '9') && ( (Source+1) < iValue.Length ) ) 
						{
							if (CharArray[Source+1] == ',') 
							{
								c = (char) (c - '0');
								Source++;			
							}
						}
					} 
					else 
					{
						c = (char)32;
					}
					
					SetCharacter(0,i,c);
					Source++;
				}
			}
			catch 
			{
				System.Diagnostics.Debug.WriteLine("Error in SetCharactersFromValue");
			}
			
		}

        /// <summary>
        /// Calculate Rectangle for given character position
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
		private Rectangle GetCharacterRectangle(int row, int col)
		{
			return new Rectangle(col * CharacterWidth + iFrameEffective, row * CharacterHeight + iFrameEffective,CharacterWidth,CharacterHeight);
		} 

        /// <summary>
        /// Return valid character value if out of range
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
		protected virtual int ReplaceByValidCharacter(int c)
		{
			if (c < MinCharacter) c = MinCharacter;
			if (c > MaxCharacter) c = MaxCharacter;
			return c;
		}

        /// <summary>
        /// Set character value
        /// </summary>
        /// <param name="row">Character row</param>
        /// <param name="col">Character column</param>
        /// <param name="c">ASCII code value</param>
		private void SetCharacter(int row, int col, int c)
		{
			try 
			{
			
				c = this.ReplaceByValidCharacter(c);

				if (c != CharacterCode[row,col] ) 
				{
					CharacterCode[row,col] = (char)c;
					base.Invalidate(GetCharacterRectangle(row,col));
				}
			}
			catch 
			{
				System.Diagnostics.Debug.WriteLine("Error in SetCharacter");
			}
		}

	
        /// <summary>
        /// Construct character bitmap for single character
        /// Not really efficient, bitmaps are cached by DrawCharacter
        /// </summary>
        /// <param name="code"></param>
        /// <param name="g"></param>
        /// <returns></returns>
		protected virtual Bitmap MakeCharacterBitmap(int code, System.Drawing.Graphics g)
		{
			try 
			{
				Bitmap bmp = new Bitmap(CharacterWidth,CharacterHeight,g );
				
				int j;
				int ix;
				int iy;

				// clear bitmap with backcolor
				for (iy = 0; iy < CharacterHeight; iy++) 
				{
					for (ix = 0; ix < CharacterWidth; ix++) 
					{
						bmp.SetPixel(ix,iy,this.BackColor);
					}
				}

				int ScanLineMultiplier = 2;
				if (iVerticalStyle == VerticalStyles.Compact) ScanLineMultiplier = 1;
				for (j = 0; j <= 34;j++) 
				{
					ix = 2 + (j % 5) * 2 - 1;
					iy = 2 + j/5 * ScanLineMultiplier ;
					
					if (iColorInactive != base.BackColor) 
					{
						bmp.SetPixel(ix,iy,iColorInactive );
					
						if (iHorizontalStyle >= HorizontalStyles.Double) bmp.SetPixel(ix+1,iy,iColorInactive);
						if (iHorizontalStyle >= HorizontalStyles.Triple) bmp.SetPixel(ix+2,iy,iColorInactive);
					
						if (iVerticalStyle == VerticalStyles.Filled) 
						{
							bmp.SetPixel(ix,iy+1,iColorInactive );
							if (iHorizontalStyle >= HorizontalStyles.Double) bmp.SetPixel(ix+1,iy+1,iColorInactive);
							if (iHorizontalStyle >= HorizontalStyles.Triple) bmp.SetPixel(ix+2,iy+1,iColorInactive);
						}
					}

					ulong cmp = (ulong)1 << (34-j);
					if ((Bytecode[code] & cmp) == cmp) 
					{
						bmp.SetPixel(ix,iy,base.ForeColor );
					
						if (iHorizontalStyle >= HorizontalStyles.Double) bmp.SetPixel(ix+1,iy,base.ForeColor);
						if (iHorizontalStyle >= HorizontalStyles.Triple) bmp.SetPixel(ix+2,iy,base.ForeColor);
					
						if (iVerticalStyle == VerticalStyles.Filled) 
						{
							bmp.SetPixel(ix,iy+1,base.ForeColor );
							if (iHorizontalStyle >= HorizontalStyles.Double) bmp.SetPixel(ix+1,iy+1,base.ForeColor);
							if (iHorizontalStyle >= HorizontalStyles.Triple) bmp.SetPixel(ix+2,iy+1,base.ForeColor);
						}
					} 
						
				}
				return bmp;
			}
			catch 
			{
				System.Diagnostics.Debug.WriteLine("Error in MakeCharacterBitmap");
				return null;
			}
		}


        /// <summary>
        /// Draw single character
        /// Called by onPaint
        /// </summary>
        /// <param name="cx">Horizontal character position</param>
        /// <param name="cy">Vertical character position</param>
        /// <param name="g">Active graphics object</param>
		private void DrawCharacter(int cx, int cy, Graphics g) 
		{
			try 
			{
				int code = CharacterCode[cy,cx];
				if (CharacterBitmap[code] == null)	
				{
					CharacterBitmap[code] = this.MakeCharacterBitmap(code, g);
				}

				if (g.IsVisible(GetCharacterRectangle(cy,cx)))
				{
					// GDI+ Method is definitely TOO SLOW!!!!
					// g.DrawImageUnscaled(CharacterBitmap[code], cx * CharacterWidth + iFrameEffective, cy * CharacterHeight + iFrameEffective);

					// Use old and unmanaged BitBlt instead...
					Win32.TurboBitmapCopy(g,CharacterBitmap[code],cx * CharacterWidth + iFrameEffective,cy * CharacterHeight + iFrameEffective);
				}
			}
			catch 
			{
				System.Diagnostics.Debug.WriteLine("Error in " + Name + " DrawCharacter routine");
			}
		}

        /// <summary>
        /// Draw frame lines without background
        /// </summary>
        /// <param name="g"></param>
		private void DrawFrame(Graphics g)
		{
			try 
			{/*
				SolidBrush BackBrush = new SolidBrush(BackColor);
                
				if (g.IsVisible(FrameTop)) g.FillRectangle( BackBrush,FrameTop);
				if (g.IsVisible(FrameLeft)) g.FillRectangle( BackBrush,FrameLeft);
				if (g.IsVisible(FrameRight)) g.FillRectangle( BackBrush,FrameRight);
				if (g.IsVisible(FrameBottom)) g.FillRectangle( BackBrush,FrameBottom);
			*/
				if (iFrameStyle == FrameStyles.Line) 
				{
					Pen MyPen = new Pen(new SolidBrush(ForeColor),1);
					int FrameWidthHalf = iFrameEffective / 2;
					g.DrawRectangle(MyPen,FrameWidthHalf,FrameWidthHalf,Width - iFrameEffective,Height - iFrameEffective);
				}
                else if (iFrameStyle == FrameStyles.WOPR)
                {
                    Pen MyPen = new Pen(new SolidBrush(ForeColor), 1);
                    int FrameWidthHalf = iFrameEffective / 2;
                    g.DrawRectangle(MyPen, FrameWidthHalf, FrameWidthHalf, Width - iFrameEffective, Height - iFrameEffective);

                }
            }
			catch 
			{
				System.Diagnostics.Debug.WriteLine("Error in " + Name + " DrawFrame routine");
			}
		}

        
        /// <summary>
        /// Paint entire control
        /// </summary>
        /// <param name="e"></param>
		protected override void OnPaint(PaintEventArgs peventargs)
		{
			if (iFrameStyle != FrameStyles.None) this.DrawFrame(peventargs.Graphics);
			for (int cy = 0; cy < iRows; cy++) 
			{
				for (int cx = 0; cx < iColumns; cx++) 
				{
					this.DrawCharacter(cx,cy, peventargs.Graphics );
				}
			}
		}

        /// <summary>
        /// Paint background color over entire control area
        /// </summary>
        /// <param name="peventargs"></param>
		protected override void OnPaintBackground(PaintEventArgs peventargs)
		{
            //NOP
            SolidBrush BackBrush = new SolidBrush(BackColor);
            peventargs.Graphics.FillRectangle(BackBrush, new Rectangle(0, 0, Width, Height));
		}


	
	}  // End Class

    /// <summary>
    /// Vertical display style 
    /// </summary>
	public enum VerticalStyles
	{
        /// <summary>
        /// All font lines are mapped to consecutive display lines
        /// </summary>
		Compact,

        /// <summary>
        /// Font lines are divided by empty scan lines of 1 pixel height
        /// </summary>
		Scanlines,

        /// <summary>
        /// Font lines are doubled
        /// </summary>
		Filled
	}

    /// <summary>
    /// Horizontal display style
    /// </summary>
	public enum HorizontalStyles
	{
        /// <summary>
        /// Every font pixel covers exactly one display pixel
        /// </summary>
		Single,

        /// <summary>
        /// Every font pixel is stretched to two display pixels
        /// </summary>
		Double,

        /// <summary>
        /// Every font pixel is stretched to three display pixels
        /// </summary>
        Triple
    }


	public enum FrameStyles
	{
		None,
		Empty,
		Line,
		WOPR
	}




}
