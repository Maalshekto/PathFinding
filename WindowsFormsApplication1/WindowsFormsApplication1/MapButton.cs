using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public class MapButton : Button
    {
        private int pos_x;
        private int pos_y;
        private MapUI motherMap;
       
        public MapButton(MapUI maman)
        {
            motherMap = maman;
            pos_x = 0;
            pos_y = 0;
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(motherMap.mother.registerMatrix);
        }
        public MapButton(int x, int y, MapUI maman)
        {
            this.Padding = new System.Windows.Forms.Padding(0,0,0,0);
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Size = new System.Drawing.Size(30, 30);
            this.Text = "";
            this.BackColor = Color.LightGreen;
            pos_x = x;
            pos_y = y;

            motherMap = maman;
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(motherMap.mother.registerMatrix);
            
            
        }


        public Color charToColor(char col)
        {
            switch (col)
            {
                case ' ':
                    return Color.LightGreen;
                case '.':
                    return Color.DarkOrange;
                case 'X':
                    return Color.Blue;
                case '*':
                    return Color.Green;
                case '=':
                    return Color.Gray;
            }
            return Color.LightGreen;
        }
        public char colorToString()
        {
            var c = this.BackColor.ToKnownColor();
            switch (c)
            {
                case KnownColor.LightGreen:
                    return ' ';
                case KnownColor.DarkOrange:
                    return '.';

                case KnownColor.Blue:
                    return 'X';
                    
                case KnownColor.Green:
                    return '*';
                    
                case KnownColor.Gray:
                    return '=';
            }
            return ' ';
        }

        public int colorToCost()
        {
            var c = this.BackColor.ToKnownColor();
            switch (c)
            {
                case KnownColor.LightGreen:
                    return 2;
                case KnownColor.DarkOrange:
                    return 1;

                case KnownColor.Blue:
                    return 0xFFFFFF;

                case KnownColor.Green:
                    return 0xFFFFFF;

                case KnownColor.Gray:
                    return 2;
            }
            return 0xFFFFFF;
        }

        
        public int getPosX()
        {
            return pos_y;
        }
        public int getPosY()
        {
            return pos_x;
        }
    }
}
