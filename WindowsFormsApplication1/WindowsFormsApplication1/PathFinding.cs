using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Threading;
using System.Windows.Forms;
using PathfindingLib;
using PathfindingLib.MapSolution;
using PathfindingLib.Algorithms;



namespace WindowsFormsApplication1
{
    public partial class PathFinding : Form
    {

        public const int MAX_MAP_HEIGHT = 15;
        public const int MAX_MAP_LENGHT = 22;
        private bool drawingInProgress = false;

        public const string DEFAULT_MAP_10_10 = 
            "..  XX   .\n" + 
            "*.  *X  *.\n" + 
            " .  XX ...\n" + 
            " .* X *.* \n" + 
            " ...=...  \n" + 
            " .* X     \n" + 
            " .  XXX*  \n" + 
            " .  * =   \n" + 
            " .... XX  \n" + 
            "   *.  X* ";

        public const string DEFAULT_MAP_20_10 = 
            "...*     X .*    *  \n" +
            " *..*   *X .........\n" + 
            "   .     =   *.*  *.\n" + 
            "  *.   * XXXX .    .\n" + 
            "XXX=XX   X *XX=XXX*.\n" + 
            "  *.*X   =  X*.  X  \n" + 
            "   . X * X  X . *X* \n" + 
            "*  .*XX=XX *X . XXXX\n" + 
            " ....  .... X . X   \n" + 
            " . *....* . X*. = * ";

        Graphics graphics;
        private string result;
        public PathFinding() 
        {
            graphics = this.CreateGraphics();
            InitializeComponent();
            this.MinimumSize = new Size(800, 600);
        }

        private void UIWait(int ms)
        {
            var frame = new DispatcherFrame();
            new Thread((ThreadStart)(() =>
            {
                Thread.Sleep(ms);
                frame.Continue = false;
            })).Start();
            Dispatcher.PushFrame(frame);
        }


        private void generateMap(int length, int height, String str)
        {
            if (mapUserInterface != null)
            {
                mapUserInterface.Controls.Clear();
                this.Controls.Remove(this.mapUserInterface);
            }
            if (str == "")
            {
                this.mapUserInterface = new MapUI(this,length, height);
            }
            else
            {
                this.mapUserInterface = new MapUI(this,length, height, str);
            }
            int pos_x = (this.Width - mapUserInterface.Width) / 2;
            this.mapUserInterface.Location = new System.Drawing.Point(pos_x, 100);
            this.mapUserInterface.Name = "mapUserInterface";
            this.mapUserInterface.TabIndex = 2;
            this.mapUserInterface.Visible = true;
            this.label3.Visible = true;
            this.label4.Visible = true;
            this.label5.Visible = true;
            this.label6.Visible = true;
            validate01.Visible = true;
            algorithmChoice.Visible = true;
            this.numericUpDownXStart.Visible = true;
            this.numericUpDownXStart.Value = 1;
            this.numericUpDownYStart.Visible = true;
            this.numericUpDownYStart.Value = 1;
            this.numericUpDownXEnd.Visible = true;
            this.numericUpDownXEnd.Value = length;
            this.numericUpDownYEnd.Visible = true;
            this.numericUpDownYEnd.Value = height;
            this.costLabel.Visible = true;
            mapUserInterface.setStartPoint(0, 0);
            mapUserInterface.setEndPoint(length-1, height -1);
            this.Controls.Add(this.mapUserInterface);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            generateMap(10, 10, PathFinding.DEFAULT_MAP_10_10);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            generateMap(20, 10, PathFinding.DEFAULT_MAP_20_10);
        }


        private void DrawPath(Map map)
        {
            drawingInProgress = true;
            MapButton end = mapUserInterface.getMapButtonsList()[0, 1];
            LinkedList<int[]> list = map.ReconstructPathList();
            if (list.Count == 1)
            {
                costLabel.Text = "Cost : infinity";
                return;
            }
            list.RemoveFirst();
            list.RemoveLast();
            int cost = mapUserInterface.getStartPoint().colorToCost();
            foreach (int[] i in list)
            {
                MapButton tile = mapUserInterface.getMapButtonsList()[i[1], i[0]];
                mapUserInterface.pushTile(tile);
                UIWait(250);
                cost += tile.colorToCost();
                costLabel.Text = "Cost : " + cost;
                this.Refresh();
            }
            UIWait(250);
            cost += mapUserInterface.getEndPoint().colorToCost();
            costLabel.Text = "Cost : " + cost;
            this.Refresh();
            drawingInProgress = false;
        }
        private void validate01_Click(object sender, EventArgs e)
        {
            if (drawingInProgress)
            {
                return;
            }
            Map myMap = new Map(mapUserInterface.getMatrix(), 
                (int)numericUpDownYStart.Value - 1, 
                (int)numericUpDownXStart.Value - 1,
                (int)numericUpDownYEnd.Value - 1,
                (int)numericUpDownXEnd.Value - 1);
            Executor exec = new Executor();
            RadioButton button = algorithmChoice.Controls.OfType<RadioButton>().FirstOrDefault(n => n.Checked);
            mapUserInterface.clearTiles();
            exec.RunAlgorithm(button.Text, myMap);
            result = exec.getResult();
            DrawPath(myMap);
        }

        

        private void generateMapButton_click(object sender, EventArgs e)
        {
            generateMap((int)lengthNumericUpDown.Value, (int)heightNumericUpDown.Value, "");
        }


        private void lengthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = (NumericUpDown)sender;
            if (nud.Value >= MAX_MAP_LENGHT)
            {
                nud.Value = MAX_MAP_LENGHT;
            }
            if (nud.Value <= 1)
            {
                nud.Value = 1;
            }
        }

        private void heightNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = (NumericUpDown)sender;
            if (nud.Value >= MAX_MAP_HEIGHT)
            {
                nud.Value = MAX_MAP_HEIGHT;
            }
            if (nud.Value <= 1)
            {
                nud.Value = 1;
            }
        }

        private void numericUpDownXStart_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = (NumericUpDown)sender;
            if (nud.Value > mapUserInterface.getLength())
            {
                nud.Value = mapUserInterface.getLength();
            }
            else if (nud.Value < 1)
            {
                nud.Value = 1;
            }
            else
            {
                int startX = (int)numericUpDownXStart.Value - 1;
                int startY = (int)numericUpDownYStart.Value - 1;
                MapButton end = mapUserInterface.getEndPoint();
                if (end != null) {
                    if(end.getPosX() != startX || end.getPosY() != startY)
                    {
                        mapUserInterface.setStartPoint(startX, startY);
                        mapUserInterface.clearTiles();
                    }
                
                    else
                    {
                        nud.Value = mapUserInterface.getStartPoint().getPosX() + 1;
                    }
                }
            }
        }

        private void numericUpDownYStart_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = (NumericUpDown)sender;
            if (nud.Value > mapUserInterface.getHeight())
            {
                nud.Value = mapUserInterface.getHeight();
            }
            else if (nud.Value < 1)
            {
                nud.Value = 1;
            }
            else {
                int startX = (int)numericUpDownXStart.Value-1;
                int startY = (int)numericUpDownYStart.Value-1;
                MapButton end = mapUserInterface.getEndPoint();
                if (end != null)
                {
                    if ((end.getPosX() != startX || end.getPosY() != startY))
                    {
                        mapUserInterface.setStartPoint(startX, startY);
                        mapUserInterface.clearTiles();
                    }

                    else
                    {
                        nud.Value = mapUserInterface.getStartPoint().getPosY() + 1;
                    }
                }
            }
        }

        private void numericUpDownXEnd_ValueChanged(object sender, System.EventArgs e)
        {
            NumericUpDown nud = (NumericUpDown)sender;
            if (nud.Value > mapUserInterface.getLength())
            {
                nud.Value = mapUserInterface.getLength();
            }
            else if (nud.Value < 1)
            {
                nud.Value = 1;
            }
            else
            {
                int endX = (int)numericUpDownXEnd.Value - 1;
                int endY = (int)numericUpDownYEnd.Value - 1;
                MapButton start = mapUserInterface.getStartPoint();
                if (start != null)
                {
                    if ((start.getPosX() != endX || start.getPosY() != endY))
                    {
                        mapUserInterface.setEndPoint(endX, endY);
                        mapUserInterface.clearTiles();
                    }

                    else
                    {
                        nud.Value = mapUserInterface.getEndPoint().getPosX() + 1;
                    }
                }
            }
        }

        private void numericUpDownYEnd_ValueChanged(object sender, System.EventArgs e)
        {
            NumericUpDown nud = (NumericUpDown)sender;
            if (nud.Value > mapUserInterface.getHeight())
            {
                nud.Value = mapUserInterface.getHeight();
            }
            else if (nud.Value < 1)
            {
                nud.Value = 1;
            }
            else
            {
                int endX = (int)numericUpDownXEnd.Value - 1;
                int endY = (int)numericUpDownYEnd.Value - 1;
                MapButton start = mapUserInterface.getStartPoint();

                if (start != null)
                {
                    if ((start.getPosX() != endX || start.getPosY() != endY))
                    {
                        mapUserInterface.setEndPoint(endX, endY);
                        mapUserInterface.clearTiles();
                    }
                    else
                    {
                        nud.Value = mapUserInterface.getEndPoint().getPosY() + 1;
                    }
                }
            }
        }

        public void registerMatrix(object sender, MouseEventArgs e)
        {
            if (drawingInProgress)
            {
                return;
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MapButton but = (MapButton)sender;
                
                var c = but.BackColor.ToKnownColor();
                switch (c)
                {
                    case KnownColor.LightGreen:
                        but.BackColor = Color.DarkOrange;
                        break;
                    case KnownColor.DarkOrange:
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

                char butc = but.colorToString();
                mapUserInterface.setMatrixXY(but.getPosY(), but.getPosX(), butc);
                mapUserInterface.clearTiles();
            }
        }

    }
    
}
