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
        string värv = "v", p1 = "", p2 = "", variant1 = "", variant2 = "";

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=titCc4zkhPo");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("https://www.vint.ee/et-ee/games/#kabe");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("http://kabeliit.ee/kohtunikekogu/koodeks/EKL64_2016.pdf");
        }

        int valge = 0, must = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            n = 8;
            P = new PictureBox[n, n];
            int vasakult = 2, ülevalt = 2, kontroll = 1;
            Color[] colors = new Color[] { Color.Wheat, Color.Sienna };
            for (int i = 0; i < n; i++)
            {
                vasakult = 2;
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
                    P[i, j].Location = new Point(vasakult, ülevalt);
                    P[i, j].Size = new Size(60, 60);
                    vasakult += 60;
                    P[i, j].Name = i + " " + j;
                    if (i < 3 && P[i, j].BackColor == Color.Sienna)
                    {
                        P[i, j].Image = Properties.Resources.m;
                        P[i, j].Name += " m";
                    }
                    else if (i > 4 && P[i, j].BackColor == Color.Sienna)
                    {
                        P[i, j].Image = Properties.Resources.v;
                        P[i, j].Name += " v";
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
                            int t = -1, x, y;
                            EemaldabVariandid();
                            if (p.Name.Split(' ')[2] == "b") 
                            {
                                if (värv == "v")
                                {
                                    värv = "m";
                                }
                                else
                                {
                                    värv = "v";
                                }
                                x = Convert.ToInt32(p1.Split(' ')[0]);
                                y = Convert.ToInt32(p1.Split(' ')[1]);
                                variant1 = "";
                                variant2 = "";
                                if(p1.Split(' ')[2] == "m")
                                {
                                    p.Image = Properties.Resources.m;
                                    p.Name = p.Name.Replace("b", "m");
                                }
                                else if (p1.Split(' ')[2] == "v")
                                {
                                    p.Image = Properties.Resources.v;
                                    p.Name = p.Name.Replace("b", "v");
                                }
                                P[x, y].Image = null;
                                if(p2 != "" && kontroll == 0 )
                                {
                                    x = Convert.ToInt32(p2.Split(' ')[0]);
                                    y = Convert.ToInt32(p2.Split(' ')[1]);
                                    P[x, y].Image = null;
                                    if(p2.Split(' ')[2] == "m")
                                    {
                                        must++;
                                    }
                                    else
                                    {
                                        valge++;
                                    }
                                    label17.Text = valge + "";
                                    label18.Text = must + "";
                                    p2 = "";
                                    kontroll = 1;
                                }
                            }
                            else if (p.Name.Split(' ')[2] == värv)
                            {
                                x = Convert.ToInt32(p.Name.Split(' ')[0]);
                                y = Convert.ToInt32(p.Name.Split(' ')[1]);
                                p1 = p.Name;
                                if (p.Name.Split(' ')[2] == "m")
                                {
                                    t = 1;
                                }
                                try
                                {
                                   if (P[x + t, y + 1].Image != null && P[x + t, y + 1].Name.Split(' ')[2] != p.Name.Split(' ')[2] && P[x + (t * 2), y + 2].Image == null)
                                    {
                                        P[x + (t * 2), y + 2].Image = Properties.Resources.b;
                                        P[x + (t * 2), y + 2].Name = (x + (t * 2)) + " " + (y + 2) + " b";
                                        variant1 = (x + (t * 2)) + " " + (y + 2);
                                        p2 = (x + t) + " " + (y + 1) + " " + P[x + t, y + 1].Name.Split(' ')[2];
                                        kontroll = 0;
                                    }
                                    else if (kontroll == 1 && P[x + t, y + 1].Image == null)
                                    {
                                        P[x + t, y + 1].Image = Properties.Resources.b;
                                        P[x + t, y + 1].Name = (x + t) + " " + (y + 1) + " b";
                                        variant1 = (x + t) + " " + (y + 1);
                                    }
                                }
                                catch { }
                                try
                                {
                                    if (P[x + t, y - 1].Image != null && P[x + t, y - 1].Name.Split(' ')[2] != p.Name.Split(' ')[2] && P[x + (t * 2), y - 2].Image == null)
                                    {
                                        P[x + (t * 2), y - 2].Image = Properties.Resources.b;
                                        P[x + (t * 2), y - 2].Name = (x + (t * 2)) + " " + (y - 2) + " b";
                                        variant2 = (x + (t * 2)) + " " + (y - 2);
                                        p2 = (x + t) + " " + (y - 1) + " " + P[x + t, y - 1].Name.Split(' ')[2];
                                        kontroll = 0;
                                    }
                                    else if (kontroll == 1 && P[x + t, y - 1].Image == null)
                                    {
                                        P[x + t, y - 1].Image = Properties.Resources.b;
                                        P[x + t, y - 1].Name = (x + t) + " " + (y - 1) + " b";
                                        variant2 = (x + t) + " " + (y - 1);
                                    }
                                }
                                catch { }
                            }
                        }
                    };
                    board.Controls.Add(P[i, j]);
                }
                ülevalt += 60;
            }
        }
        public void EemaldabVariandid()
        {
            if (variant1 != "")
            {
                int x, y;
                x = Convert.ToInt32(variant1.Split(' ')[0]);
                y = Convert.ToInt32(variant1.Split(' ')[1]);
                P[x, y].Image = null;
            }
            if (variant2 != "")
            {
                int x, y;
                x = Convert.ToInt32(variant2.Split(' ')[0]);
                y = Convert.ToInt32(variant2.Split(' ')[1]);
                P[x, y].Image = null;
            }
        }
    }
}