using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int n;
        PictureBox[,] P;
        string color = "r", k = "", B1 = "", B2 = "";
        private void Form1_Load(object sender, EventArgs e)
        {
            n = 8;
            P = new PictureBox[n, n];
            int left = 2, top = 2;
            Color[] colors = new Color[] { Color.Wheat, Color.Sienna };
            for (int i = 0; i < n; i++)
            {
                left = 2;
                if (i % 2 == 0)
                {
                    colors[0] = Color.Sienna;
                    colors[1] = Color.Wheat;
                }
                else
                {
                    colors[0] = Color.Wheat;
                    colors[1] = Color.Sienna;
                }
                for (int j = 0; j < n; j++)
                {
                    P[i, j] = new PictureBox();
                    P[i, j].BackColor = colors[(j % 2 == 0) ? 1 : 0];
                    P[i, j].Location = new Point(left, top);
                    P[i, j].Size = new Size(60, 60);
                    left += 60;
                    P[i, j].Name = i + "" + j;
                    if (i < 3 && P[i, j].BackColor == Color.Sienna)
                    {
                        P[i, j].Image = Properties.Resources.r;
                        P[i, j].Name += "r";
                    }
                    else if (i > 4 && P[i, j].BackColor == Color.Sienna)
                    {
                        P[i, j].Image = Properties.Resources.g;
                        P[i, j].Name += "g";
                    }
                    P[i, j].SizeMode = PictureBoxSizeMode.CenterImage;
                    P[i, j].MouseHover += (sender2, e2) =>
                    {
                        PictureBox p = sender2 as PictureBox;
                        if (p.Image != null)
                            p.BackColor = Color.FromArgb(255, 100, 50, 0);
                    };
                    P[i, j].MouseLeave += (sender2, e2) =>
                    {
                        PictureBox p = sender2 as PictureBox;
                        if (p.Image != null)
                            p.BackColor = Color.Sienna;
                    };

                    P[i, j].Click += (sender3, e3) =>
                    {
                        PictureBox p = sender3 as PictureBox;
                        if (p.Image != null)
                        {
                            int c = -1, x, y;
                            if (p.Name.Split(' ')[2] == color) //ei tööta
                            {
                                x = Convert.ToInt32(p.Name.Split(' ')[0]);
                                y = Convert.ToInt32(p.Name.Split(' ')[1]);
                                k = p.Name;
                                if (p.Name.Split(' ')[2] == "r")
                                {
                                    c = -1;
                                }
                                    if (P[x + c, y + 1].Image == null)
                                    {
                                        P[x + c, y + 1].Image = Properties.Resources.b;
                                        P[x + c, y + 1].Name = (x + c) + "" + (y + 1) + "b";
                                        B1 = (x + c) + "" + (y + 1);
                                    }
                                    if (P[x + c, y - 1].Image == null)
                                    {
                                        P[x + c, y - 1].Image = Properties.Resources.b;
                                        P[x + c, y - 1].Name = (x + c) + "" + (y - 1) + "b";
                                        B2 = (x + c) + "" + (y - 1);
                                    }
                            }
                        }
                    };
                    board.Controls.Add(P[i, j]);
                }
                top += 60;
            }
        }
    }
}