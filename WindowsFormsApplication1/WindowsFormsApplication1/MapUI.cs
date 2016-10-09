using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication1
{
    public class MapUI : FlowLayoutPanel
    {
        int height = 0;
        int length = 0;

        MapButton start;
        MapButton end;

        private MapButton[,] mapButtonsList;
        char[,] matrix;

        public const string CHARACTER_MOBILE = "\u265C";

        public PathFinding mother { get; set; }
        public MapUI(PathFinding mum, int l, int h)
        {
            mother = mum;
            height = h;
            length = l;
            if (h <= 0 || l <= 0)
            {
                return;
            }

            this.Margin = new Padding(0, 0, 0, 0);
            this.Padding = new Padding(0, 0, 0, 0);
            matrix = new char[h, l];
            mapButtonsList = new MapButton[h, l];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    MapButton button = new MapButton(i, j, this);
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderColor = Color.Black;
                    button.FlatAppearance.BorderSize = 0;
                    this.Controls.Add(button);
                    matrix[i,j] = ' ';
                    mapButtonsList[i,j] = button;
                }
            }
            this.Location = new System.Drawing.Point(10, 100);
            this.Name = "flowLayoutPanel2";
            this.Size = new System.Drawing.Size(l * 30, h * 30);
            this.TabIndex = 3;
            this.Visible = false;
        }

        public MapUI(PathFinding mom, int l, int h, string val_init)
        {
            mother = mom;
            height = h;
            length = l;
            if (h <= 0 || l <= 0)
            {
                return;
            }
            String[] mapRows = val_init.Split(new char[] { '\n' });
            int nbRows = mapRows.Length;
            int nbCols = mapRows[0].Length;
            this.Margin = new Padding(0, 0, 0, 0);
            this.Padding = new Padding(0, 0, 0, 0);
            matrix = new char[h, l];
            mapButtonsList = new MapButton[h, l];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    MapButton button = new MapButton(i, j, this);
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderColor = Color.Black;
                    button.FlatAppearance.BorderSize = 0;
                    this.Controls.Add(button);
                    matrix[i, j] = mapRows[i][j];
                    button.BackColor = button.charToColor(mapRows[i][j]);
                    mapButtonsList[i, j] = button;
                }
            }
            this.Location = new System.Drawing.Point(10, 100);
            this.Name = "flowLayoutPanel2";
            this.Size = new System.Drawing.Size(l * 30, h * 30);
            this.TabIndex = 3;
            this.Visible = false;
        }

        public void setMatrixXY(int x, int y, char val) {
            matrix[x, y] = val;
        }

        public char[,] getMatrix()
        {
            return matrix;
        }

        public MapButton[,] getMapButtonsList()
        {
            return mapButtonsList;
        }

        public MapButton getMapButton(int x, int y)
        {
            return mapButtonsList[x, y];
        }

        public int getLength()
        {
            return length;
        }
        public int getHeight()
        {
            return height;
        }

        public void pushTile(MapButton tile)
        {
            start.Text = "";
            tile.Text = CHARACTER_MOBILE;
            start = tile;
        }

        public void clearTiles()
        {
            foreach (MapButton tile in getMapButtonsList())
            {
                if (tile.Text != CHARACTER_MOBILE)
                {
                    tile.Text = "";
                }
            }
        }

        public MapButton getStartPoint()
        {
            return start;
        }

        public MapButton getEndPoint()
        {
            return end;
        }
        public void setStartPoint(int X, int Y)
        {
            if (start != null)
            {
                start.Text = "";
            }
            if (X > mapButtonsList.GetLength(0) || Y > mapButtonsList.GetLength(1))
            {
                return;
            }
            start = getMapButtonsList()[X, Y];
            start.Text = CHARACTER_MOBILE; 
        }
        public void setEndPoint(int X, int Y)
        {
            if (X > mapButtonsList.GetLength(0) || Y > mapButtonsList.GetLength(1))
            {
                return;
            }
            end = getMapButtonsList()[X, Y];
        }
    }
}
