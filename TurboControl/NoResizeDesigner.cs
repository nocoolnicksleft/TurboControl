using System;
using System.Windows.Forms.Design;


namespace TurboControl
{
	/// <summary>
	/// Summary description for NoResizeDesigner.
	/// </summary>
	public class NoResizeDesigner : System.Windows.Forms.Design.ControlDesigner 
	{

		public override SelectionRules SelectionRules
		{
			get
			{
				return SelectionRules.Moveable | SelectionRules.Visible;
			}
		}

	}

}
