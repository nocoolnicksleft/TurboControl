using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace TurboControl
{
	/// <summary>
	/// Summary description for Win32.
	/// </summary>
	public class Win32 
	{
		
		[DllImport("gdi32.dll", EntryPoint="BitBlt")]
		public static extern int BitBlt (IntPtr hDestC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);

		[DllImport("gdi32.dll", EntryPoint="CreateCompatibleDC")]
		public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

		[DllImport("gdi32.dll", EntryPoint="DeleteDC")]	
		public static extern int DeleteDC(IntPtr hdc);
		
		[DllImport("gdi32.dll", EntryPoint="SelectObject")]
		public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hObject);
		
		[DllImport("gdi32.dll", EntryPoint="DeleteObject")]
		public static extern int DeleteObject(IntPtr hdc);

		[DllImport("gdi32.dll", EntryPoint="SetBkColor")]
		public static extern int SetBkColor (IntPtr hdc, int crColor);
		
		public const int SRCCOPY = 0xCC0020;		
		public const int SRCAND = 0x8800C6;
		public const int SRCERASE = 0x440328;
		public const int SRCINVERT = 0x660046;
		public const int SRCPAINT = 0xEE0086;
		public const int IMAGE_BITMAP = 0x0;
		public const int LR_LOADFROMFILE = 16;

		public const int WM_WINDOWPOSCHANGING = 0x46;

		public static void TurboBitmapCopy(Graphics g, Bitmap bmp, int targetX, int targetY) 
		{
			IntPtr ptrTargetContext = g.GetHdc();
			IntPtr ptrSourceContext = Win32.CreateCompatibleDC(ptrTargetContext);
		
			// Select the bitmap into the source context, keeping the original object
			IntPtr ptrOriginalObject;
			IntPtr ptrNewObject;

			ptrOriginalObject = Win32.SelectObject(ptrSourceContext, bmp.GetHbitmap());

			// Copy the bitmap from the source to the target
			Win32.BitBlt(ptrTargetContext, targetX, targetY, bmp.Width, bmp.Height, ptrSourceContext, 0, 0, Win32.SRCCOPY);

			// 'Select our bitmap out of the dc and delete it
			ptrNewObject = Win32.SelectObject(ptrSourceContext, ptrOriginalObject);
			Win32.DeleteObject(ptrNewObject);
			
			Win32.DeleteDC(ptrSourceContext);
			g.ReleaseHdc(ptrTargetContext);

		}

	}

	public struct WM_PosChanging 
	{
		public int hWnd, hWndInsertAfter, X, Y, cX, cY, Flags;
	}


}
