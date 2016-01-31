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
using System.Runtime.InteropServices;


namespace TurboControl
{
    /// <summary>
    /// Summary description for CustomControl1.
    /// </summary>
    /// 
    [System.ComponentModel.DesignerCategory("")]
    [ToolboxBitmap(typeof(SegmentDisplay), "Images.Designer.TurboControl.SegmentDisplay.bmp")]
	public class SegmentDisplay : TurboControl.MatrixDisplay
	{

		private char[][][] Mask;
		private SegmentStyle iSegmentStyle = SegmentStyle.SevenUpright;

		[Description("Style of segments to display")]
		public SegmentStyle SegmentStyle
		{
			get 
			{
				return iSegmentStyle;
			}
			
			set 
			{	
				iSegmentStyle = value;
				SetBytecode();
				SetDimensions();
				ClearBitmapCache();
				SetCharactersFromValue();				
				this.Invalidate();
			}
		}

		public SegmentDisplay()
		{
			InitializeComponent();

			Bytecode = new ulong[MaxCharacter];

			base.iFrameStyle = 0;
			base.iFrameWidth= 0;

			this.SetDimensions();

			SetStyle(ControlStyles.UserPaint, true);
			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.ResizeRedraw, true);
			UpdateStyles();

			this.InitCharacterTable();
		}

		
		[Browsable(false)]
		public new VerticalStyles StyleVertical
		{
			get 
			{
				return base.iVerticalStyle;
			}
		}


		[Browsable(false)]
		public new HorizontalStyles StyleHorizontal
		{
			get 
			{
				return base.iHorizontalStyle;
			}
		}

        /*
		[Browsable(false)]
		public new FrameStyles FrameStyle
		{
			get 
			{
				return base.iFrameStyle;
			}
		}


		[Browsable(false)]
		public new int FrameWidth
		{
			get 
			{
				return base.iFrameWidth;
			}
		}
        */
		
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;


		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		protected new void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion


		protected override void InitCharacterTable()
		{
			Mask = new char[4][][];
			Mask[0] = new char[20][];
			Mask[0][0]  = "_______________".ToCharArray();
			Mask[0][1]  = "______AAAAAA___".ToCharArray();
			Mask[0][2]  = "____FFAAAAAABB_".ToCharArray();
			Mask[0][3]  = "____FF______BB_".ToCharArray();
			Mask[0][4]  = "____FF______BB_".ToCharArray();
			Mask[0][5]  = "___FF__KKK_BB__".ToCharArray();
			Mask[0][6]  = "___FF_KKK__BB__".ToCharArray();
			Mask[0][7]  = "___FF_KKK__BB__".ToCharArray();
			Mask[0][8]  = "___FF______BB__".ToCharArray();
			Mask[0][9]  = "__FFGGGGGGBBHHH".ToCharArray();
			Mask[0][10] = "__EEGGGGGGCCHHH".ToCharArray();
			Mask[0][11] = "__EE______CC___".ToCharArray();
			Mask[0][12] = "__EE_KKK__CC___".ToCharArray();
			Mask[0][13] = "__EE_KKK__CC___".ToCharArray();
			Mask[0][14] = "_EE_KKK__CC____".ToCharArray();
			Mask[0][15] = "_EE______CC____".ToCharArray();
			Mask[0][16] = "_EE______CC_PPP".ToCharArray();
			Mask[0][17] = "_EEDDDDDDCC_PPP".ToCharArray();
			Mask[0][18] = "___DDDDDD___PPP".ToCharArray();
			Mask[0][19] = "_______________".ToCharArray();

			Mask[1] = new char[20][];
			Mask[1][0]  = "_______________".ToCharArray();
			Mask[1][1]  = "___AAAAAA______".ToCharArray();
			Mask[1][2]  = "_FFAAAAAABB____".ToCharArray();
			Mask[1][3]  = "_FF______BB____".ToCharArray();
			Mask[1][4]  = "_FF______BB____".ToCharArray();
			Mask[1][5]  = "_FF_KKKK_BB____".ToCharArray();
			Mask[1][6]  = "_FF_KKKK_BB____".ToCharArray();
			Mask[1][7]  = "_FF_KKKK_BB____".ToCharArray();
			Mask[1][8]  = "_FF______BB____".ToCharArray();
			Mask[1][9]  = "_FFGGGGGGBBHHH_".ToCharArray();
			Mask[1][10] = "_EEGGGGGGCCHHH_".ToCharArray();
			Mask[1][11] = "_EE______CC____".ToCharArray();
			Mask[1][12] = "_EE_KKKK_CC____".ToCharArray();
			Mask[1][13] = "_EE_KKKK_CC____".ToCharArray();
			Mask[1][14] = "_EE_KKKK_CC____".ToCharArray();
			Mask[1][15] = "_EE______CC____".ToCharArray();
			Mask[1][16] = "_EE______CC_PPP".ToCharArray();
			Mask[1][17] = "_EEDDDDDDCC_PPP".ToCharArray();
			Mask[1][18] = "___DDDDDD___PPP".ToCharArray();
			Mask[1][19] = "_______________".ToCharArray();

			Mask[2] = new char[20][];
			Mask[2][0] = "___________________".ToCharArray();
			Mask[2][1] = "______AAAAAAAAAA___".ToCharArray();
			Mask[2][2] = "____FFAAAAAAAAAABB_".ToCharArray();
			Mask[2][3] = "____FFKK__II__LLBB_".ToCharArray();
			Mask[2][4] = "____FFKK__II_LL_BB_".ToCharArray();
			Mask[2][5] = "___FF_KK_II__LLBB__".ToCharArray();
			Mask[2][6] = "___FF__KKII_LL_BB__".ToCharArray();
			Mask[2][7] = "___FF__KKII_LL_BB__".ToCharArray();
			Mask[2][8] = "___FF__KKIILL__BB__".ToCharArray();
			Mask[2][9] = "__FFGGGGGHHHHHBB___".ToCharArray();
			Mask[2][10] = "__EEGGGGGHHHHHCC___".ToCharArray();
			Mask[2][11] = "__EE__NNJJMM__CC___".ToCharArray();
			Mask[2][12] = "__EE_NN_JJMM__CC___".ToCharArray();
			Mask[2][13] = "__EE_NN_JJ_MM_CC___".ToCharArray();
			Mask[2][14] = "_EE_NN_JJ__MMCC____".ToCharArray();
			Mask[2][15] = "_EENN__JJ__MMCC____".ToCharArray();
			Mask[2][16] = "_EENN__JJ__MMCC_PPP".ToCharArray();
			Mask[2][17] = "_EEDDDDDDDDDDCC_PPP".ToCharArray();
			Mask[2][18] = "___DDDDDDDDDD___PPP".ToCharArray();
			Mask[2][19] = "___________________".ToCharArray();

			Mask[3] = new char[20][];
			Mask[3][0] = "___________________".ToCharArray();
			Mask[3][1] = "___AAAAAAAAAA______".ToCharArray();
			Mask[3][2] = "_FFAAAAAAAAAABB____".ToCharArray();
			Mask[3][3] = "_FFKK__II__LLBB____".ToCharArray();
			Mask[3][4] = "_FFKK__II__LLBB____".ToCharArray();
			Mask[3][5] = "_FF_KK_II_LL_BB____".ToCharArray();
			Mask[3][6] = "_FF_KK_II_LL_BB____".ToCharArray();
			Mask[3][7] = "_FF__KKIILL__BB____".ToCharArray();
			Mask[3][8] = "_FF__KKIILL__BB____".ToCharArray();
			Mask[3][9]= "_FFGGGGGHHHHHBB____".ToCharArray();
			Mask[3][10]= "_EEGGGGGHHHHHCC____".ToCharArray();
			Mask[3][11]= "_EE__NNJJMM__CC____".ToCharArray();
			Mask[3][12]= "_EE__NNJJMM__CC____".ToCharArray();
			Mask[3][13]= "_EE_NN_JJ_MM_CC____".ToCharArray();
			Mask[3][14]= "_EE_NN_JJ_MM_CC____".ToCharArray();
			Mask[3][15]= "_EENN__JJ__MMCC____".ToCharArray();
			Mask[3][16]= "_EENN__JJ__MMCC_PPP".ToCharArray();
			Mask[3][17]= "_EEDDDDDDDDDDCC_PPP".ToCharArray();
			Mask[3][18]= "___DDDDDDDDDD___PPP".ToCharArray();
			Mask[3][19]= "___________________".ToCharArray();

			SetBytecode();

			iIntegrateDecimal = true;
			iAlwaysAlignRight = false;
		}

		protected void SetBytecode()
		{

			if ((iSegmentStyle == SegmentStyle.SevenSlanted) || (iSegmentStyle == SegmentStyle.SevenUpright )) 
			{
				// Numbers with decimal active
				Bytecode[0] = Convert.ToUInt64("1111110010",2);
				Bytecode[1] = Convert.ToUInt64("0110000010",2);
				Bytecode[2] = Convert.ToUInt64("1101101010",2);
				Bytecode[3] = Convert.ToUInt64("1111001010",2);
				Bytecode[4] = Convert.ToUInt64("0110011010",2);
				Bytecode[5] = Convert.ToUInt64("1011011010",2);
				Bytecode[6] = Convert.ToUInt64("1011111010",2);
				Bytecode[7] = Convert.ToUInt64("1110000010",2);
				Bytecode[8] = Convert.ToUInt64("1111111010",2);
				Bytecode[9] = Convert.ToUInt64("1111011010",2);

				// Space
				Bytecode[32] = Convert.ToUInt64("0000000000",2);

				// Regular characters
				Bytecode[(int) '0'] = Convert.ToUInt64("1111110000",2);
				Bytecode[(int) '1'] = Convert.ToUInt64("0110000000",2);
				Bytecode[(int) '2'] = Convert.ToUInt64("1101101000",2);
				Bytecode[(int) '3'] = Convert.ToUInt64("1111001000",2);
				Bytecode[(int) '4'] = Convert.ToUInt64("0110011000",2);
				Bytecode[(int) '5'] = Convert.ToUInt64("1011011000",2);
				Bytecode[(int) '6'] = Convert.ToUInt64("1011111000",2);
				Bytecode[(int) '7'] = Convert.ToUInt64("1110000000",2);
				Bytecode[(int) '8'] = Convert.ToUInt64("1111111000",2);
				Bytecode[(int) '9'] = Convert.ToUInt64("1111011000",2);

				Bytecode[(int) 'A'] = Convert.ToUInt64("1110111000",2);
				Bytecode[(int) 'b'] = Convert.ToUInt64("0011111000",2);
				Bytecode[(int) 'C'] = Convert.ToUInt64("1001110000",2);
				Bytecode[(int) 'd'] = Convert.ToUInt64("0111101000",2);
				Bytecode[(int) 'E'] = Convert.ToUInt64("1001111000",2);
				Bytecode[(int) 'F'] = Convert.ToUInt64("1000111000",2);
				Bytecode[(int) 'G'] = Convert.ToUInt64("1011110000",2);
				Bytecode[(int) 'H'] = Convert.ToUInt64("0110111000",2);
				Bytecode[(int) 'L'] = Convert.ToUInt64("0001110000",2);
				Bytecode[(int) 'P'] = Convert.ToUInt64("1100111000",2);
				Bytecode[(int) 'o'] = Convert.ToUInt64("0011101000",2);
				Bytecode[(int) 'r'] = Convert.ToUInt64("0000101000",2);
				Bytecode[(int) 'u'] = Convert.ToUInt64("0011100000",2);
				Bytecode[(int) '-'] = Convert.ToUInt64("0000001000",2);
				Bytecode[(int) '.'] = Convert.ToUInt64("0000000010",2);
				Bytecode[(int) ':'] = Convert.ToUInt64("0000000001",2);
				
			} 
			else  // Fourteens 
			{
				// Numbers with decimal active
				Bytecode[0] = Convert.ToUInt64("111111000000001",2);
				Bytecode[1] = Convert.ToUInt64("011000000000001",2);
				Bytecode[2] = Convert.ToUInt64("110110110000001",2);
				Bytecode[3] = Convert.ToUInt64("111100110000001",2);
				Bytecode[4] = Convert.ToUInt64("011001110000001",2);
				Bytecode[5] = Convert.ToUInt64("101101110000001",2);
				Bytecode[6] = Convert.ToUInt64("101111110000001",2);
				Bytecode[7] = Convert.ToUInt64("111001000000001",2);
				Bytecode[8] = Convert.ToUInt64("111111110000001",2);
				Bytecode[9] = Convert.ToUInt64("111101110000001",2);

				// Space
				Bytecode[32] = Convert.ToUInt64("0000000000",2);

				// Regular characters
				Bytecode[(int) '0'] = Convert.ToUInt64("111111000000000",2);
				Bytecode[(int) '1'] = Convert.ToUInt64("011000000000000",2);
				Bytecode[(int) '2'] = Convert.ToUInt64("110110110000000",2);
				Bytecode[(int) '3'] = Convert.ToUInt64("111100110000000",2);
				Bytecode[(int) '4'] = Convert.ToUInt64("011001110000000",2);
				Bytecode[(int) '5'] = Convert.ToUInt64("101101110000000",2);
				Bytecode[(int) '6'] = Convert.ToUInt64("101111110000000",2);
				Bytecode[(int) '7'] = Convert.ToUInt64("111001000000000",2);
				Bytecode[(int) '8'] = Convert.ToUInt64("111111110000000",2);
				Bytecode[(int) '9'] = Convert.ToUInt64("111101110000000",2);
				Bytecode[(int) 'A'] = Convert.ToUInt64("111011110000000",2);
				Bytecode[(int) 'B'] = Convert.ToUInt64("111100011100000",2);
				Bytecode[(int) 'C'] = Convert.ToUInt64("100111000000000",2);
				Bytecode[(int) 'D'] = Convert.ToUInt64("111100001100000",2);
				Bytecode[(int) 'E'] = Convert.ToUInt64("100111110000000",2);
				Bytecode[(int) 'F'] = Convert.ToUInt64("100011110000000",2);
				Bytecode[(int) 'G'] = Convert.ToUInt64("101111010000000",2);
				Bytecode[(int) 'H'] = Convert.ToUInt64("011011110000000",2);
				Bytecode[(int) 'I'] = Convert.ToUInt64("100100001100000",2);
				Bytecode[(int) 'J'] = Convert.ToUInt64("111110000000000",2);
				Bytecode[(int) 'K'] = Convert.ToUInt64("000011100001100",2);
				Bytecode[(int) 'L'] = Convert.ToUInt64("000111000000000",2);
				Bytecode[(int) 'M'] = Convert.ToUInt64("011011000011000",2);
				Bytecode[(int) 'N'] = Convert.ToUInt64("011011000010100",2);
				Bytecode[(int) 'O'] = Convert.ToUInt64("111111000000000",2);
				Bytecode[(int) 'P'] = Convert.ToUInt64("110011110000000",2);
				Bytecode[(int) 'Q'] = Convert.ToUInt64("111111000000100",2);
				Bytecode[(int) 'R'] = Convert.ToUInt64("110011110000100",2);
				Bytecode[(int) 'S'] = Convert.ToUInt64("101101110000000",2);
				Bytecode[(int) 'T'] = Convert.ToUInt64("100000001100000",2);
				Bytecode[(int) 'U'] = Convert.ToUInt64("011111000000000",2);
				Bytecode[(int) 'V'] = Convert.ToUInt64("000011000001010",2);
				Bytecode[(int) 'W'] = Convert.ToUInt64("011011000000110",2);
				Bytecode[(int) 'X'] = Convert.ToUInt64("000000000011110",2);
				Bytecode[(int) 'Y'] = Convert.ToUInt64("000000000111000",2);
				Bytecode[(int) 'Z'] = Convert.ToUInt64("100100000001010",2);
				Bytecode[(int) '/'] = Convert.ToUInt64("000000000001010",2);
				Bytecode[(int) '*'] = Convert.ToUInt64("000000111111110",2);
				Bytecode[(int) '+'] = Convert.ToUInt64("000000111100000",2);
				Bytecode[(int) '-'] = Convert.ToUInt64("000000110000000",2);
				Bytecode[(int) '('] = Convert.ToUInt64("000000000001100",2);
				Bytecode[(int) ')'] = Convert.ToUInt64("000000000010010",2);
				Bytecode[(int) ','] = Convert.ToUInt64("000000000000010",2);
				Bytecode[(int) '.'] = Convert.ToUInt64("000000000000010",2);
				Bytecode[(int) '_'] = Convert.ToUInt64("000100000000000",2);
			}
		}

		protected override Bitmap MakeCharacterBitmap(int code, Graphics g)
		{
			Bitmap bmp = new Bitmap(CharacterWidth,CharacterHeight,g );
				
			ulong bcode = Bytecode[code];

			for (int iy = 0; iy < CharacterHeight; iy++) 
			{
				for (int ix = 0; ix < CharacterWidth; ix++)
				{
					bmp.SetPixel(ix,iy,this.BackColor);

					char fillcode = Mask[(int)iSegmentStyle][iy][ix];
					if ( fillcode != '_') 
					{
						bmp.SetPixel(ix,iy,iColorInactive);
						if ((iSegmentStyle == SegmentStyle.SevenSlanted) || (iSegmentStyle == SegmentStyle.SevenUpright )) 
						{
							if ((fillcode == 'A') && ((Bytecode[code] & (1 << 9)) == (1 << 9) )) bmp.SetPixel(ix,iy,this.ForeColor);
							if ((fillcode == 'B') && ((Bytecode[code] & (1 << 8)) == (1 << 8) )) bmp.SetPixel(ix,iy,this.ForeColor);
							if ((fillcode == 'C') && ((Bytecode[code] & (1 << 7)) == (1 << 7) )) bmp.SetPixel(ix,iy,this.ForeColor);
							if ((fillcode == 'D') && ((Bytecode[code] & (1 << 6)) == (1 << 6) )) bmp.SetPixel(ix,iy,this.ForeColor);
							if ((fillcode == 'E') && ((Bytecode[code] & (1 << 5)) == (1 << 5) )) bmp.SetPixel(ix,iy,this.ForeColor);
							if ((fillcode == 'F') && ((Bytecode[code] & (1 << 4)) == (1 << 4) )) bmp.SetPixel(ix,iy,this.ForeColor);
							if ((fillcode == 'G') && ((Bytecode[code] & (1 << 3)) == (1 << 3) )) bmp.SetPixel(ix,iy,this.ForeColor);
							if ((fillcode == 'H') && ((Bytecode[code] & (1 << 2)) == (1 << 2) )) bmp.SetPixel(ix,iy,this.ForeColor);
							if ((fillcode == 'P') && ((Bytecode[code] & (1 << 1)) == (1 << 1) )) bmp.SetPixel(ix,iy,this.ForeColor);
							if ((fillcode == 'K') && ((Bytecode[code] & (1 << 0)) == (1 << 0) )) bmp.SetPixel(ix,iy,this.ForeColor);
						} 
						else // 14er 
						{
							if ((fillcode == 'A') && ((Bytecode[code] & (1 << 14)) == (1 << 14) )) bmp.SetPixel(ix,iy,this.ForeColor);
							if ((fillcode == 'B') && ((Bytecode[code] & (1 << 13)) == (1 << 13) )) bmp.SetPixel(ix,iy,this.ForeColor);
							if ((fillcode == 'C') && ((Bytecode[code] & (1 << 12)) == (1 << 12) )) bmp.SetPixel(ix,iy,this.ForeColor);
							if ((fillcode == 'D') && ((Bytecode[code] & (1 << 11)) == (1 << 11) )) bmp.SetPixel(ix,iy,this.ForeColor);
							if ((fillcode == 'E') && ((Bytecode[code] & (1 << 10)) == (1 << 10) )) bmp.SetPixel(ix,iy,this.ForeColor);
							if ((fillcode == 'F') && ((Bytecode[code] & (1 << 9)) == (1 << 9) )) bmp.SetPixel(ix,iy,this.ForeColor);
							if ((fillcode == 'G') && ((Bytecode[code] & (1 << 8)) == (1 << 8) )) bmp.SetPixel(ix,iy,this.ForeColor);
							if ((fillcode == 'H') && ((Bytecode[code] & (1 << 7)) == (1 << 7) )) bmp.SetPixel(ix,iy,this.ForeColor);
							if ((fillcode == 'I') && ((Bytecode[code] & (1 << 6)) == (1 << 6) )) bmp.SetPixel(ix,iy,this.ForeColor);
							if ((fillcode == 'J') && ((Bytecode[code] & (1 << 5)) == (1 << 5) )) bmp.SetPixel(ix,iy,this.ForeColor);
							if ((fillcode == 'K') && ((Bytecode[code] & (1 << 4)) == (1 << 4) )) bmp.SetPixel(ix,iy,this.ForeColor);
							if ((fillcode == 'L') && ((Bytecode[code] & (1 << 3)) == (1 << 3) )) bmp.SetPixel(ix,iy,this.ForeColor);
							if ((fillcode == 'M') && ((Bytecode[code] & (1 << 2)) == (1 << 2) )) bmp.SetPixel(ix,iy,this.ForeColor);
							if ((fillcode == 'N') && ((Bytecode[code] & (1 << 1)) == (1 << 1) )) bmp.SetPixel(ix,iy,this.ForeColor);
							if ((fillcode == 'P') && ((Bytecode[code] & (1 << 0)) == (1 << 0) )) bmp.SetPixel(ix,iy,this.ForeColor);
						}
					} 
					else 
					{
						bmp.SetPixel(ix,iy,this.BackColor);
					}
				}
			}
			return bmp;
		}

		protected override int ReplaceByValidCharacter(int c)
		{
			if (c != 32) 
			{
				if (Bytecode[c] == 0) c = 32;
				//if (c < 48) c = 48;
				//if (c > 57) c = 57;
			}
			return c;
		}

		protected override void SetCharacterDimensions()
		{

			CharacterHeight = 20;
			if ((iSegmentStyle == SegmentStyle.SevenSlanted) || (iSegmentStyle == SegmentStyle.SevenUpright )) 
			{
				CharacterWidth = 15;
			} 
			else 
			{
				CharacterWidth = 19;
			}
			
		}

	}


	public enum SegmentStyle
	{
		SevenSlanted = 0,
		SevenUpright,
		FourteenSlanted,
		FourteenUpright
		/*
		SharpFancy,
	    Panaplex,
		Tio,
		RussianNiner
		*/
	}

}
