using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pikachu
{
    public partial class Form1 : Form
    {
        int rows = 9;
        int cols = 16;
        int tileSize = 35;
        Image[] congiapImages;
        PictureBox[,] congiappictureBox;
        Random random = new Random();

        int[,] boardMap;

        PictureBox selected1 = null;
        PictureBox selected2 = null;
        bool isProcessing = false;
        public Form1()
        {
            InitializeComponent();
            LoadConGiapImage();
            Initializeboard();
        }
        private void LoadConGiapImage()
        {
            // Load the Pikachu image from the resources
            congiapImages = new Image[]
            {
                Properties.Resources.conchuot,
                Properties.Resources.contrau,
                Properties.Resources.conho,
                Properties.Resources.contho,
                Properties.Resources.conrong,
                Properties.Resources.conran,
                Properties.Resources.conngua,
                Properties.Resources.concuu,
                Properties.Resources.conkhi,
                Properties.Resources.conga,
                Properties.Resources.concho,
                Properties.Resources.conheo,
            };
        }
        private void Initializeboard()
        {
            congiappictureBox = new PictureBox[rows, cols];
            boardMap = new int[rows, cols];

            List<int> congiapIndexes = new List<int>();
            for(int i = 0; i < (rows * cols)/2 ; i++)
            {
                int index = i % congiapImages.Length;
                congiapIndexes.Add(index);
                congiapIndexes.Add(index);
            }

            for(int i = 0; i < congiapIndexes.Count; i++)
            {
                int j = random.Next(i, congiapIndexes.Count);
                int temp = congiapIndexes[j];
                congiapIndexes[i] = congiapIndexes[j];
                congiapIndexes[j] = temp;
            }

            int k = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    PictureBox pb = new PictureBox();
                    pb.Width = tileSize;
                    pb.Height = tileSize;
                    pb.Left = j * tileSize;
                    pb.Top = i * tileSize;

                    pb.SizeMode = PictureBoxSizeMode.StretchImage;

                    pb.BorderStyle = BorderStyle.FixedSingle;

                    int imangeIndex = congiapIndexes[k++];

                    pb.Image = congiapImages[imangeIndex];
                    
                    boardMap[i, j] = imangeIndex;

                    panelMiddle.Controls.Add(pb);
                    congiappictureBox[i, j] = pb;

                    pb.Click += picturebox_Click;
                }
            }
        }
        private async Task ResetSelectionAsync()
        {
            // Đợi nửa giây để người chơi nhận ra mình chọn sai
            await Task.Delay(500);

            if (selected1 != null) selected1.BorderStyle = BorderStyle.FixedSingle;
            if (selected2 != null) selected2.BorderStyle = BorderStyle.FixedSingle;

            selected1 = null;
            selected2 = null;
        }
        private async void picturebox_Click(object sender, EventArgs e)
        {
            if (isProcessing) return;

            PictureBox selected = sender as PictureBox;

            if (selected.Image == null)
            {
                return;
            }
            if (selected1 == selected)
            {
                selected1.BorderStyle = BorderStyle.FixedSingle;
                selected1 = null;
                return;
            } 

            if (selected1 == null)
            {
                selected1 = selected;
                selected1.BorderStyle = BorderStyle.Fixed3D;
                return;
            }
            if (selected2 == null && selected != selected1)
            {
                selected2 = selected;
                selected2.BorderStyle = BorderStyle.Fixed3D;

                isProcessing = true;

                Point pos1 = GetPictureBoxPosition(selected1);  
                Point pos2 = GetPictureBoxPosition(selected2);

                if (boardMap[pos1.X, pos1.Y] == boardMap[pos2.X, pos2.Y])
                {
                    if(ConnectStraight(pos1, pos2) || ConnectL(pos1,pos2) || Connect3Line(pos1,pos2))
                    {
                        boardMap[pos1.X, pos1.Y] = -1;
                        boardMap[pos2.X, pos2.Y] = -1;

                        selected1.Image = null;
                        selected2.Image = null;

                        selected1.BorderStyle = BorderStyle.FixedSingle;
                        selected2.BorderStyle = BorderStyle.FixedSingle;

                        selected1 = null;
                        selected2 = null;

                        if (IsBoardCleaned())
                        {
                            MessageBox.Show("You Win!");
                        }
                    }
                    else
                    {
                        // Chọn sai 2 hình khác nhau
                        await ResetSelectionAsync();
                    }
                }
                else
                {
                    await ResetSelectionAsync();
                }
                isProcessing = false;
            }
        }
        private int GetBoardValue(int x, int y)
        {
            if(x == -1 || y == -1 || x == rows || y == cols)
            {
                return -1;
            }
            if(x < -1 || x > rows || y < -1 || y > cols)
            {
                return -2;
            }
            return  boardMap[x, y];
        }
        private bool ConnectStraight(Point a, Point b)
        {
            if (a.X == b.X)
            {
                int minY = Math.Min(a.Y, b.Y);
                int maxY = Math.Max(a.Y, b.Y);
                for (int y = minY + 1; y < maxY; y++)
                {
                    if (GetBoardValue(a.X, y) != -1) 
                    {
                        return false;
                    }
                }
                return true;
            }
            else if (a.Y == b.Y)
            {
                int minX = Math.Min(a.X, b.X);
                int maxX = Math.Max(a.X, b.X);
                for (int x = minX + 1; x < maxX; x++)
                {
                    if (GetBoardValue(x, a.Y) != -1)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
        private Point GetPictureBoxPosition(PictureBox pb)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (congiappictureBox[i, j] == pb)
                    {
                        return new Point(i, j);
                    }
                }
            }
            return Point.Empty;
        }
        private bool ConnectL(Point a, Point b)
        {
            Point c1 = new Point(a.X, b.Y);
            if (Isempty(c1) && ConnectStraight(a, c1) && ConnectStraight(c1, b))
            {
                return true;
            }
            Point c2 = new Point(b.X, a.Y);
            if (Isempty(c2) && ConnectStraight(a, c2) && ConnectStraight(c2, b))
            {
                return true;
            }
            return false;
        }
        private bool Isempty(Point p)
        {
            return GetBoardValue(p.X, p.Y) == -1;
        }

        private bool Connect3Line(Point a, Point b)
        {
            for (int i = -1; i <= rows; i++)
            {
               for(int j = -1; j <= cols; j++)
               {
                    Point mid = new Point(i, j);
                    if(!Isempty(mid) || mid == a || mid == b)
                    {
                        continue;
                    }
                    if ((ConnectStraight(a, mid) && ConnectL(mid, b)) || (ConnectL(a, mid) && ConnectStraight(mid, b)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private bool IsBoardCleaned()
        {
            for(int i = 0; i < rows; i++)
            {
                for(int j=0; j < cols; j++)
                {
                    if (boardMap[i, j] != -1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
