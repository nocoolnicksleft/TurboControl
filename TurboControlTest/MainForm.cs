using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurboControlTest
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            InitWOPRDisplay();
        }

        private void glowSwitchYES_Click(TurboControl.GlowSwitch sender)
        {
            glowSwitchNO.Active = false;
            glowSwitchYES.Active = true;
        }

        private void glowSwitchNO_Click(TurboControl.GlowSwitch sender)
        {
            glowSwitchNO.Active = true;
            glowSwitchYES.Active = false;
            glowSwitchMasterWarning.Active = true;

        }

        private void glowSwitchOK_Click(TurboControl.GlowSwitch sender)
        {
            glowSwitchERROR.Active = false;
            glowSwitchOK.Active = true;

        }

        private void glowSwitchERROR_Click(TurboControl.GlowSwitch sender)
        {
            glowSwitchERROR.Active = true;
            glowSwitchOK.Active = false;

            glowSwitchMasterWarning.Active = true;

        }

        private void glowSwitchMasterWarning_Click(TurboControl.GlowSwitch sender)
        {
            glowSwitchMasterWarning.Active = false;

        }

        private void digiSwitchClock_Click(TurboControl.DigiSwitch sender)
        {
            digiSwitchClock.StateLED = !digiSwitchClock.StateLED;
        }

        private void digiSwitchCounter_Click(TurboControl.DigiSwitch sender)
        {
            digiSwitchCounter.StateLED = !digiSwitchCounter.StateLED;
        }

        private void digiSwitch1_Click(TurboControl.DigiSwitch sender)
        {
            digiSwitch1.StateLED = true;
            digiSwitch2.StateLED = false;
            digiSwitch3.StateLED = false;
            digiSwitch4.StateLED = false;
        }

        private void digiSwitch2_Click(TurboControl.DigiSwitch sender)
        {
            digiSwitch1.StateLED = false;
            digiSwitch2.StateLED = true;
            digiSwitch3.StateLED = false;
            digiSwitch4.StateLED = false;

        }

        private void digiSwitch3_Click(TurboControl.DigiSwitch sender)
        {
            digiSwitch1.StateLED = false;
            digiSwitch2.StateLED = false;
            digiSwitch3.StateLED = true;
            digiSwitch4.StateLED = false;

        }

        private void digiSwitch4_Click(TurboControl.DigiSwitch sender)
        {
            digiSwitch1.StateLED = false;
            digiSwitch2.StateLED = false;
            digiSwitch3.StateLED = false;
            digiSwitch4.StateLED = true;

        }

        private void digiSwitch_Click(TurboControl.DigiSwitch sender)
        {
            digiSwitch.StateLED = !digiSwitch.StateLED;
        }
        
        private void InitWOPRDisplay()
        {
            matrixDisplayTop.Clear();

            matrixDisplayTop.SetText(0, 5, 4, false, "GAME");
            matrixDisplayTop.SetText(1, 1, 11, false, "TIME ELAPSED");

            matrixDisplayBottom.Clear();

            matrixDisplayBottom.SetText(0, 5, 4, false, "GAME");
            matrixDisplayBottom.SetText(1, 0, 14, false, "TIME REMAINING");

        }

        int countValue = 0;

        private void timer1Sec_Tick(object sender, EventArgs e)
        {
            if (digiSwitchCounter.StateLED)
            {
                segmentDisplayCounter.Text = countValue.ToString();
                countValue++;
            }

            if (digiSwitchClock.StateLED)
            {
                segmentDisplayClock.Text = DateTime.Now.ToLongTimeString().PadLeft(8,'-');
            }
        }
    }
}
