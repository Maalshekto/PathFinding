using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class SwitchButton : Button
    {
        public SwitchButton()
        {
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(switchValue);
        }
        private void switchValue(object sender, MouseEventArgs e)
        {
            Button but = (Button)sender;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                var c = but.BackColor.ToKnownColor();
                switch (c)
                {
                    case KnownColor.LightGreen:
                        but.BackColor = Color.Maroon;
                        break;
                    case KnownColor.Maroon:
                        but.BackColor = Color.Blue;
                        break;
                    case KnownColor.Blue:
                        but.BackColor = Color.Green;
                        break;
                    case KnownColor.Green:
                        but.BackColor = Color.Gray;
                        break;
                    case KnownColor.Gray:
                        but.BackColor = Color.LightGreen;
                        break;

                }
            }
        }
    } 
}
