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
using System.IO;
using PathfindingLib;
using PathfindingLib.MapSolution;
using PathfindingLib.Algorithms;
using System.Media;
using System.Diagnostics;



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

        private void playYesSound()
        {
            string[] soundsList = {
                                      @"\sound\FootmanYes1.wav",
                                      @"\sound\FootmanYes2.wav",
                                      @"\sound\FootmanYes3.wav",
                                      @"\sound\FootmanYes4.wav"
                                  };
            Random rnd = new Random();
            string sound = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName)  + soundsList[rnd.Next(4)];
            SoundPlayer simpleSound = new SoundPlayer(sound);
            simpleSound.Play();
        }

        private void playErrorSound()
        {
            string errorSound = @"\sound\error.wav";
                                  
            Random rnd = new Random();
            string sound = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + errorSound;
            SoundPlayer simpleSound = new SoundPlayer(sound);
            simpleSound.Play();
        }

        private void playReadySound()
        {
            string errorSound = @"\sound\FootmanReady1.wav";

            Random rnd = new Random();
            string sound = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + errorSound;
            SoundPlayer simpleSound = new SoundPlayer(sound);
            simpleSound.Play();
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
            algorithmChoice.Visible = true;
            this.numericUpDownXStart.Visible = true;
            this.numericUpDownXStart.Value = 1;
            this.numericUpDownYStart.Visible = true;
            this.numericUpDownYStart.Value = 1;
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
            
            MapButton end = mapUserInterface.getMapButtonsList()[0, 1];
            LinkedList<int[]> list = map.ReconstructPathList();
            if (list.Count == 1)
            {
                playErrorSound();
                costLabel.Text = "Cost : infinity";
                return;
            }
            playYesSound();
            drawingInProgress = true;
            list.RemoveFirst();
            
            int cost = mapUserInterface.getStartPoint().colorToCost();
            foreach (int[] i in list)
            {
                MapButton tile = mapUserInterface.getMapButtonsList()[i[1], i[0]];
                mapUserInterface.pushTile(tile);
                
                
                cost += tile.colorToCost();
                UIWait(250 * tile.colorToCost());
                costLabel.Text = "Cost : " + cost;
                this.Refresh();
                
            }
            playReadySound();
            drawingInProgress = false;
        }

        private void startPathFind()
        {
            MapButton start = mapUserInterface.getStartPoint();
            MapButton end = mapUserInterface.getEndPoint();
            Map myMap = new Map(mapUserInterface.getMatrix(),
                start.getPosY(), start.getPosX(),
                end.getPosY(), end.getPosX());
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
                mapUserInterface.setStartPoint(startY, startX);
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
                mapUserInterface.setStartPoint(startY, startX);
            }
        }

        public void registerMatrix(object sender, MouseEventArgs e)
        {
            
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (drawingInProgress)
                {
                    return;
                }
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
            else if(e.Button == System.Windows.Forms.MouseButtons.Right)
            {
              
                if (drawingInProgress)
                {
                    drawingInProgress = false;
                }
                
                MapButton but = (MapButton)sender;
                mapUserInterface.setEndPoint(but.getPosY(), but.getPosX());
                startPathFind();
            }
        }

    }
    
}
