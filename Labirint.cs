using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LabirintZelda
{
    public partial class Labirint : Form
    {
        int i, j, n, m, x, nr, q = 2, ok, ok1, ok2, c, ordine, o, p;                // i , j coordonate jucator
        Button[,] b = new Button[25, 25];                                           // o , p retin pozitia jucatorului                                                                            
        string[] sir;                                                               // t timpul in secunde                                                                                    
        StreamReader f;                                                             // x caracterul din fisier
        Random r;                                                                   // q pozitia lui x in fisier
        private Ghicitoare Ghicitoare;                                              // nr numarul de pasi facuti
                                                                                    // n , m numar linii si coloane
        public Labirint()                                                           // ok contor pentru Random si pentru gasirea cheii
        {                                                                           // ok1 contor pentru deschiderea usii ( eroare la deplasare ) 
            InitializeComponent();                                                  // ok2 contor pentru terminarea jocului                                                                                                                                                             // d activare animatii in functie de t
            this.FormBorderStyle = FormBorderStyle.None;                            // c numarul labirintului    
            this.Bounds = Screen.PrimaryScreen.Bounds;                              // ordine ordinea la afisarea mesajelor in labirint2 
        }                                                                           
                                                                                    
        private void Form1_Load(object sender, EventArgs e)
        {
            Meniu Meniu = new Meniu();
            Meniu.Show();
            System.Drawing.Rectangle workingRectangle = Screen.PrimaryScreen.WorkingArea;
            f = File.OpenText("Labirint.txt");
            Variables.s = f.ReadLine();
            sir = Variables.s.Split(' ');
            n = Int32.Parse(sir[0]);
            m = Int32.Parse(sir[1]);
            for (i = 1; i <= n; i++)
                for (j = 1; j <= m; j++)
                {
                    b[i, j] = new Button();
                    b[i, j].Width = 40;
                    b[i, j].Height = 55;
                    b[i, j].Top = workingRectangle.Height / 20 + 55 * i;
                    b[i, j].Left = 0 + 40 * j;
                    b[i, j].Enabled = false;
                    b[i, j].FlatStyle = FlatStyle.Flat;
                    b[i, j].FlatAppearance.BorderSize = 0;
                    Controls.Add(b[i, j]);
                }
            for (i = 1; i <= n; i++)
                for (j = 1; j <= m; j++)
                {
                    x = Int32.Parse(sir[q++]);
                    b[i, j].Name = Convert.ToString(x);
                    b[i, j].BackColor = Color.Black;
                }
            r = new Random();
            while (ok == 0)
            {
                i = r.Next(2, n - 1);
                j = r.Next(2, m - 1);
                if (b[i, j].Name == "0")
                {
                    b[i, j].BackgroundImage = Properties.Resources.Jos;
                    b[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    ok = 1;
                    lumina(sender, e);
                }
            }
            o = i; p = j;
        }

        private void lumina(object sender, EventArgs e)
        {
            if ( c == 0 )
            {
                if (b[i - 1, j - 1].Name == "0")
                {
                    System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#474749");
                    b[i - 1, j - 1].BackColor = col;
                }
                else
                {
                    b[i - 1, j - 1].BackgroundImage = Properties.Resources.Zid;
                    b[i - 1, j - 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (b[i - 1, j].Name == "0")
                {
                    System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#474749");
                    b[i - 1, j].BackColor = col;
                }
                else
                {
                    b[i - 1, j].BackgroundImage = Properties.Resources.Zid;
                    b[i - 1, j].BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (b[i - 1, j + 1].Name == "0")
                {
                    System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#474749");
                    b[i - 1, j + 1].BackColor = col;
                }
                else
                {
                    b[i - 1, j + 1].BackgroundImage = Properties.Resources.Zid;
                    b[i - 1, j + 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (b[i, j - 1].Name == "0")
                {
                    System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#474749");
                    b[i, j - 1].BackColor = col;
                }
                else
                {
                    b[i, j - 1].BackgroundImage = Properties.Resources.Zid;
                    b[i, j - 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (b[i, j + 1].Name == "0")
                {
                    System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#474749");
                    b[i, j + 1].BackColor = col;
                }
                else
                {
                    b[i, j + 1].BackgroundImage = Properties.Resources.Zid;
                    b[i, j + 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (b[i + 1, j - 1].Name == "0")
                {
                    System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#474749");
                    b[i + 1, j - 1].BackColor = col;
                }
                else
                {
                    b[i + 1, j - 1].BackgroundImage = Properties.Resources.Zid;
                    b[i + 1, j - 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (b[i + 1, j].Name == "0")
                {
                    System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#474749");
                    b[i + 1, j].BackColor = col;
                }
                else
                {

                    b[i + 1, j].BackgroundImage = Properties.Resources.Zid;
                    b[i + 1, j].BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (b[i + 1, j + 1].Name == "0")
                {
                    System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#474749");
                    b[i + 1, j + 1].BackColor = col;
                }
                else
                {

                    b[i + 1, j + 1].BackgroundImage = Properties.Resources.Zid;
                    b[i + 1, j + 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
            if(c == 1)
            {
                if (b[i - 1, j - 1].Name == "0")
                {
                    System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#474749");
                    b[i - 1, j - 1].BackColor = col;
                }
                if (b[i - 1, j - 1].Name == "1")
                {
                    b[i - 1, j - 1].BackgroundImage = Properties.Resources.Zid;
                    b[i - 1, j - 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (b[i - 1, j - 1].Name == "sc")
                {
                    b[i - 1, j - 1].BackgroundImage = Properties.Resources.Scarabeu;
                    b[i - 1, j - 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (b[i - 1, j - 1].Name == "usa")
                {
                    b[i - 1, j - 1].BackgroundImage = Properties.Resources.Poarta;
                    b[i - 1, j - 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
                //////////////////////////////////////////////////////////////////////////////////
                if (b[i - 1, j].Name == "0")
                {
                    System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#474749");
                    b[i - 1, j].BackColor = col;
                }
                if (b[i - 1, j].Name == "1")
                {
                    b[i - 1, j].BackgroundImage = Properties.Resources.Zid;
                    b[i - 1, j].BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (b[i - 1, j].Name == "sc")
                {
                    b[i - 1, j].BackgroundImage = Properties.Resources.Scarabeu;
                    b[i - 1, j].BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (b[i - 1, j].Name == "usa")
                {
                    b[i - 1, j].BackgroundImage = Properties.Resources.Poarta;
                    b[i - 1, j].BackgroundImageLayout = ImageLayout.Stretch;
                }
                //////////////////////////////////////////////////////////////////////////////////
                if (b[i - 1, j + 1].Name == "0")
                {
                    System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#474749");
                    b[i - 1, j + 1].BackColor = col;
                }
                if (b[i - 1, j + 1].Name == "1")
                {
                    b[i - 1, j + 1].BackgroundImage = Properties.Resources.Zid;
                    b[i - 1, j + 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (b[i - 1, j + 1].Name == "sc")
                {
                    b[i - 1, j + 1].BackgroundImage = Properties.Resources.Scarabeu;
                    b[i - 1, j + 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (b[i - 1, j + 1].Name == "usa")
                {
                    b[i - 1, j + 1].BackgroundImage = Properties.Resources.Poarta;
                    b[i - 1, j + 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
                //////////////////////////////////////////////////////////////////////////////////
                if (b[i, j - 1].Name == "0")
                {
                    System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#474749");
                    b[i, j - 1].BackColor = col;
                }
                if (b[i, j - 1].Name == "1")
                {
                    b[i, j - 1].BackgroundImage = Properties.Resources.Zid;
                    b[i, j - 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (b[i, j - 1].Name == "sc")
                {
                    b[i, j - 1].BackgroundImage = Properties.Resources.Scarabeu;
                    b[i, j - 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (b[i, j - 1].Name == "usa")
                {
                    b[i, j - 1].BackgroundImage = Properties.Resources.Poarta;
                    b[i, j - 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
                //////////////////////////////////////////////////////////////////////////////////
                if (b[i, j + 1].Name == "0")
                {
                    System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#474749");
                    b[i, j + 1].BackColor = col;
                }
                if (b[i, j + 1].Name == "1")
                {
                    b[i, j + 1].BackgroundImage = Properties.Resources.Zid;
                    b[i, j + 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (b[i, j + 1].Name == "sc")
                {
                    b[i, j + 1].BackgroundImage = Properties.Resources.Scarabeu;
                    b[i, j + 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (b[i, j + 1].Name == "usa")
                {
                    b[i, j + 1].BackgroundImage = Properties.Resources.Poarta;
                    b[i, j + 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
                //////////////////////////////////////////////////////////////////////////////////
                if (b[i + 1, j - 1].Name == "0")
                {
                    System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#474749");
                    b[i + 1, j - 1].BackColor = col;
                }
                if (b[i + 1, j - 1].Name == "1")
                {
                    b[i + 1, j - 1].BackgroundImage = Properties.Resources.Zid;
                    b[i + 1, j - 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (b[i + 1, j - 1].Name == "sc")
                {
                    b[i + 1, j - 1].BackgroundImage = Properties.Resources.Scarabeu;
                    b[i + 1, j - 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (b[i + 1, j - 1].Name == "usa")
                {
                    b[i + 1, j - 1].BackgroundImage = Properties.Resources.Poarta;
                    b[i + 1, j - 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
                //////////////////////////////////////////////////////////////////////////////////
                if (b[i + 1, j].Name == "0")
                {
                    System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#474749");
                    b[i + 1, j].BackColor = col;
                }
                if (b[i + 1, j].Name == "1")
                {
                    b[i + 1, j].BackgroundImage = Properties.Resources.Zid;
                    b[i + 1, j].BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (b[i + 1, j].Name == "sc")
                {
                    b[i + 1, j].BackgroundImage = Properties.Resources.Scarabeu;
                    b[i + 1, j].BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (b[i + 1, j].Name == "usa")
                {
                    b[i + 1, j].BackgroundImage = Properties.Resources.Poarta;
                    b[i + 1, j].BackgroundImageLayout = ImageLayout.Stretch;
                }
                //////////////////////////////////////////////////////////////////////////////////
                if (b[i + 1, j + 1].Name == "0")
                {
                    System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#474749");
                    b[i + 1, j + 1].BackColor = col;
                }
                if (b[i + 1, j + 1].Name == "1")
                {
                    b[i + 1, j + 1].BackgroundImage = Properties.Resources.Zid;
                    b[i + 1, j + 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (b[i + 1, j + 1].Name == "sc")
                {
                    b[i + 1, j + 1].BackgroundImage = Properties.Resources.Scarabeu;
                    b[i + 1, j + 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (b[i + 1, j + 1].Name == "usa")
                {
                    b[i + 1, j + 1].BackgroundImage = Properties.Resources.Poarta;
                    b[i + 1, j + 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
        }

        private void luminaW(object sender, EventArgs e)
        {
            System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#474749");
            b[i + 2, j - 1].BackgroundImage = b[i + 2, j].BackgroundImage = b[i + 2, j + 1].BackgroundImage = null;
            b[i + 2, j - 1].BackColor = b[i + 2, j].BackColor = b[i + 2, j + 1].BackColor = Color.Black;
                if (b[i - 1, j - 1].Name == "0")
                {
                    b[i - 1, j - 1].BackColor = col;
                }
                if (b[i - 1, j - 1].Name == "1")
                {
                    b[i - 1, j - 1].BackgroundImage = Properties.Resources.Zid;
                    b[i - 1, j - 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (b[i - 1, j].Name == "0")
                {
                    b[i - 1, j].BackColor = col;
                }
                if (b[i - 1, j].Name == "1")
                {
                    b[i - 1, j].BackgroundImage = Properties.Resources.Zid;
                    b[i - 1, j].BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (b[i - 1, j + 1].Name == "0")
                {
                    b[i - 1, j + 1].BackColor = col;
                }
                if (b[i - 1, j + 1].Name == "1")
                {
                    b[i - 1, j + 1].BackgroundImage = Properties.Resources.Zid;
                    b[i - 1, j + 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
            if ( c == 1 )
            {
                if (b[i - 1, j - 1].Name == "usa")
                {
                    b[i - 1, j - 1].BackgroundImage = Properties.Resources.Poarta;
                    b[i - 1, j - 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (b[i - 1, j].Name == "usa")
                {
                    b[i - 1, j].BackgroundImage = Properties.Resources.Poarta;
                    b[i - 1, j].BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (b[i - 1, j + 1].Name == "usa")
                {
                    b[i - 1, j + 1].BackgroundImage = Properties.Resources.Poarta;
                    b[i - 1, j + 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (b[i - 1, j - 1].Name == "sc")
                {
                    b[i - 1, j - 1].BackgroundImage = Properties.Resources.Scarabeu;
                    b[i - 1, j - 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (b[i - 1, j].Name == "sc")
                {
                    b[i - 1, j].BackgroundImage = Properties.Resources.Scarabeu;
                    b[i - 1, j].BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (b[i - 1, j + 1].Name == "sc")
                {
                    b[i - 1, j + 1].BackgroundImage = Properties.Resources.Scarabeu;
                    b[i - 1, j + 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
        }

        private void luminaA(object sender, EventArgs e)
        {
            System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#474749");
            b[i + 1, j + 2].BackgroundImage = b[i, j + 2].BackgroundImage = b[i - 1, j + 2].BackgroundImage = null;
            b[i + 1, j + 2].BackColor = b[i, j + 2].BackColor = b[i - 1, j + 2].BackColor = Color.Black;
                if (b[i - 1, j - 1].Name == "0")
                {
                    b[i - 1, j - 1].BackColor = col;
                }
                if (b[i - 1, j - 1].Name == "1")
                {
                    b[i - 1, j - 1].BackgroundImage = Properties.Resources.Zid;
                    b[i - 1, j - 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (b[i, j - 1].Name == "0")
                {
                    b[i, j - 1].BackColor = col;
                }
                if (b[i, j - 1].Name == "1")
                {
                    b[i, j - 1].BackgroundImage = Properties.Resources.Zid;
                    b[i, j - 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (b[i + 1, j - 1].Name == "0")
                {
                    b[i + 1, j - 1].BackColor = col;
                }
                if (b[i + 1, j - 1].Name == "1")
                {
                    b[i + 1, j - 1].BackgroundImage = Properties.Resources.Zid;
                    b[i + 1, j - 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
            if (c == 1)
            {
                if (b[i - 1, j - 1].Name == "usa")
                {
                    b[i - 1, j - 1].BackgroundImage = Properties.Resources.Poarta;
                    b[i - 1, j - 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (b[i, j - 1].Name == "usa")
                {
                    b[i, j - 1].BackgroundImage = Properties.Resources.Poarta;
                    b[i, j - 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (b[i + 1, j - 1].Name == "usa")
                {
                    b[i + 1, j - 1].BackgroundImage = Properties.Resources.Poarta;
                    b[i + 1, j - 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (b[i - 1, j - 1].Name == "sc")
                {
                    b[i - 1, j - 1].BackgroundImage = Properties.Resources.Scarabeu;
                    b[i - 1, j - 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (b[i, j - 1].Name == "sc")
                {
                    b[i, j - 1].BackgroundImage = Properties.Resources.Scarabeu;
                    b[i, j - 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (b[i + 1, j - 1].Name == "sc")
                {
                    b[i + 1, j - 1].BackgroundImage = Properties.Resources.Scarabeu;
                    b[i + 1, j - 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
        }

        private void luminaD(object sender, EventArgs e)
        {
            System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#474749");
            b[i - 1, j - 2].BackgroundImage = b[i, j - 2].BackgroundImage = b[i + 1, j - 2].BackgroundImage = null;
            b[i - 1, j - 2].BackColor = b[i, j - 2].BackColor = b[i + 1, j - 2].BackColor = Color.Black;
                if (b[i - 1, j + 1].Name == "0")
                {
                    b[i - 1, j + 1].BackColor = col;
                }
                if (b[i - 1, j + 1].Name == "1")
                {
                    b[i - 1, j + 1].BackgroundImage = Properties.Resources.Zid;
                    b[i - 1, j + 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (b[i, j + 1].Name == "0")
                {
                    b[i, j + 1].BackColor = col;
                }
                if (b[i, j + 1].Name == "1")
                {
                    b[i, j + 1].BackgroundImage = Properties.Resources.Zid;
                    b[i, j + 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (b[i + 1, j + 1].Name == "0")
                {
                    b[i + 1, j + 1].BackColor = col;
                }
                if (b[i + 1, j + 1].Name == "1")
                {
                    b[i + 1, j + 1].BackgroundImage = Properties.Resources.Zid;
                    b[i + 1, j + 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
            if (c == 1)
            {
                if (b[i - 1, j + 1].Name == "usa")
                {
                    b[i - 1, j + 1].BackgroundImage = Properties.Resources.Poarta;
                    b[i - 1, j + 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (b[i, j + 1].Name == "usa")
                {
                    b[i, j + 1].BackgroundImage = Properties.Resources.Poarta;
                    b[i, j + 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (b[i + 1, j + 1].Name == "usa")
                {
                    b[i + 1, j + 1].BackgroundImage = Properties.Resources.Poarta;
                    b[i + 1, j + 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (b[i - 1, j + 1].Name == "sc")
                {
                    b[i - 1, j + 1].BackgroundImage = Properties.Resources.Scarabeu;
                    b[i - 1, j + 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (b[i, j + 1].Name == "sc")
                {
                    b[i, j + 1].BackgroundImage = Properties.Resources.Scarabeu;
                    b[i, j + 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (b[i + 1, j + 1].Name == "sc")
                {
                    b[i + 1, j + 1].BackgroundImage = Properties.Resources.Scarabeu;
                    b[i + 1, j + 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
        }

        private void luminaS(object sender, EventArgs e)
        {
            System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#474749");
            b[i - 2, j - 1].BackgroundImage = b[i - 2, j].BackgroundImage = b[i - 2, j + 1].BackgroundImage = null;
            b[i - 2, j - 1].BackColor = b[i - 2, j].BackColor = b[i - 2, j + 1].BackColor = Color.Black;
                if (b[i + 1, j + 1].Name == "0")
                {
                    b[i + 1, j + 1].BackColor = col;
                }
                if (b[i + 1, j + 1].Name == "1")
                {
                    b[i + 1, j + 1].BackgroundImage = Properties.Resources.Zid;
                    b[i + 1, j + 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (b[i + 1, j].Name == "0")
                {
                    b[i + 1, j].BackColor = col;
                }
                if (b[i + 1, j].Name == "1")
                {
                    b[i + 1, j].BackgroundImage = Properties.Resources.Zid;
                    b[i + 1, j].BackgroundImageLayout = ImageLayout.Stretch;
                }
                if (b[i + 1, j - 1].Name == "0")
                {
                    b[i + 1, j - 1].BackColor = col;
                }
                if (b[i + 1, j - 1].Name == "1")
                {
                    b[i + 1, j - 1].BackgroundImage = Properties.Resources.Zid;
                    b[i + 1, j - 1].BackgroundImageLayout = ImageLayout.Stretch;
                }
                if ( c == 1 )
                {
                    if (b[i + 1, j + 1].Name == "usa")
                    {
                        b[i + 1, j + 1].BackgroundImage = Properties.Resources.Poarta;
                        b[i + 1, j + 1].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    if (b[i + 1, j].Name == "usa")
                    {
                        b[i + 1, j].BackgroundImage = Properties.Resources.Poarta;
                        b[i + 1, j].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    if (b[i + 1, j - 1].Name == "usa")
                    {
                        b[i + 1, j - 1].BackgroundImage = Properties.Resources.Poarta;
                        b[i + 1, j - 1].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    if (b[i + 1, j + 1].Name == "sc")
                    {
                        b[i + 1, j + 1].BackgroundImage = Properties.Resources.Scarabeu;
                        b[i + 1, j + 1].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    if (b[i + 1, j].Name == "sc")
                    {
                        b[i + 1, j].BackgroundImage = Properties.Resources.Scarabeu;
                        b[i + 1, j].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    if (b[i + 1, j - 1].Name == "sc")
                    {
                        b[i + 1, j - 1].BackgroundImage = Properties.Resources.Scarabeu;
                        b[i + 1, j - 1].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                } 
        }

        public void timer1_Tick(object sender, EventArgs e)
        {
            System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#474749");
            Variables.t++;
            label3.Text = "" + Variables.t;
            if (Variables.t > 1200)
            {
                timer1.Stop();
                Moarte Moarte = new Moarte();
                Moarte.Show();
            }
            if (i == 1 || i == n || j == 1 || j == m)
            {
                if (c == 0)
                    if (Variables.s != "ecoul" && Variables.s != "ecou" && Variables.s != "Ecou" && Variables.s != "Ecoul")
                    {
                        if (Variables.d + 2 == Variables.t)
                    {
                        if ( i == 1 )
                        {
                            b[i, j].BackgroundImage = Properties.Resources.VJos;
                            b[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                            b[i, j].Name = "2";
                        }
                        if (i == n)
                        {
                            b[i, j].BackgroundImage = Properties.Resources.VSus;
                            b[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                            b[i, j].Name = "2";
                        }
                        if (j == 1)
                        {
                            b[i, j].BackgroundImage = Properties.Resources.VDreapta;
                            b[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                            b[i, j].Name = "2";
                        }
                        if (j == n)
                        {
                            b[i, j].BackgroundImage = Properties.Resources.VStanga;
                            b[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                            b[i, j].Name = "2";
                        }
                        }
                    if (Variables.d + 3 == Variables.t)
                    {
                        Ghicitoare = new Ghicitoare();
                        Ghicitoare.Show();
                    }
                    if (Variables.d + 28 == Variables.t && x != 5)
                    {
                        Ghicitoare.Close();
                    }
                    if (Variables.d + 29 == Variables.t && x != 5)
                            {
                                b[i, j].BackgroundImage = Properties.Resources.Portal;
                                b[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                                b[i, j].Name = "2";
                            }
                    if (Variables.d + 30 == Variables.t && x != 5)
                            {
                                b[i, j].BackColor = col;
                                b[i, j].BackgroundImage = null;
                                b[i, j].Name = "0";
                            }
                    if (Variables.d + 31 == Variables.t && x != 5)
                            {
                                MessageBox.Show(" Creatura a dispărut și poarta din fața ta s-a dechis. Ai hotărât să treci prin ea. ", " Mesaj ", MessageBoxButtons.OK, MessageBoxIcon.Information);                              
                            }
                    if (Variables.d + 34 == Variables.t && x != 5)
                    {
                        if (o + 1 == i)
                        {
                            b[i - 1, j].BackgroundImage = null;
                            b[i - 1, j].BackColor = col;
                            b[i, j].BackgroundImage = Properties.Resources.Jos;
                            b[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                        }
                        if (o - 1 == i)
                        {
                            b[i + 1, j].BackgroundImage = null;
                            b[i + 1, j].BackColor = col;
                            b[i, j].BackgroundImage = Properties.Resources.Sus;
                            b[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                        }
                        if (p + 1 == j)
                        {
                            b[i, j - 1].BackgroundImage = null;
                            b[i, j - 1].BackColor = col;
                            b[i, j].BackgroundImage = Properties.Resources.Dreapta;
                            b[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                        }
                        if (p - 1 == j)
                        {
                            b[i, j + 1].BackgroundImage = null;
                            b[i, j + 1].BackColor = col;
                            b[i, j].BackgroundImage = Properties.Resources.Stanga;
                            b[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                        }
                    }
                    if (Variables.d + 35 == Variables.t && x != 5)
                    {
                        b[i, j].BackgroundImage = null;
                        b[i, j].BackColor = col;
                    }
                    if (Variables.d + 36 == Variables.t && x != 5)
                    {
                        Variables.d = 0;
                        c = 1;
                        Ascensiune Ascensiue = new Ascensiune();
                        Ascensiue.Show();
                        for (i = 1; i <= n; i++)
                            for (j = 1; j <= m; j++)
                            {
                                if (b[i, j].Name == "0")
                                {
                                    b[i, j].BackgroundImage = null;
                                    b[i, j].BackColor = col;
                                }
                                if (b[i, j].Name == "1")
                                {
                                    b[i, j].BackgroundImage = Properties.Resources.Zid;
                                    b[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                                }
                            }
                        Labirint2(sender, e);     
                    }
                }
                if (Variables.s == "ecoul" || Variables.s == "ecou" || Variables.s == "Ecou" || Variables.s == "Ecoul")
                {
                    if (Variables.d + 1 == Variables.t)
                    {
                        b[i, j].BackgroundImage = Properties.Resources.Portal;
                        b[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                        b[i, j].Name = "2";
                    }
                    if (Variables.d + 2 == Variables.t)
                    {
                        b[i, j].BackColor = col;
                        b[i, j].BackgroundImage = null;
                        b[i, j].Name = "0";
                    }
                    if (Variables.d + 3 == Variables.t)
                    {
                        if (i == 1)
                        {
                            b[i + 1, j].BackColor = col;
                            b[i + 1, j].BackgroundImage = null;
                            b[i, j].BackgroundImage = Properties.Resources.Sus;
                            b[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                        }
                        if (i == n)
                        {
                            b[i - 1, j].BackColor = col;
                            b[i - 1, j].BackgroundImage = null;
                            b[i, j].BackgroundImage = Properties.Resources.Jos;
                            b[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                        }
                        if (j == 1)
                        {
                            b[i, j + 1].BackColor = col;
                            b[i, j + 1].BackgroundImage = null;
                            b[i, j].BackgroundImage = Properties.Resources.Stanga;
                            b[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                        }
                        if (j == n)
                        {
                            b[i, j - 1].BackColor = col;
                            b[i, j - 1].BackgroundImage = null;
                            b[i, j].BackgroundImage = Properties.Resources.Dreapta;
                            b[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                        }
                    }
                    if (Variables.d + 4 == Variables.t)
                    {
                        MessageBox.Show(" Creatura a dispărut și poarta din fața ta s-a dechis. Ai hotărât să treci prin ea. ", " Mesaj ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        b[i, j].BackColor = col;
                        b[i, j].BackgroundImage = null;                       
                    }
                    if (Variables.d + 7 == Variables.t)
                    {
                        MessageBox.Show(" Te afli într-o peșteră imensă. La capătul ei vezi o deschizătură uriașă, iar de partea cealaltă se întinde o pădure. ", " Mesaj ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (Variables.d + 10 == Variables.t)
                    {
                        Victorie Victorie = new Victorie();
                        Victorie.Show();
                        ok2 = 1;
                        for (i = 1; i <= n; i++)
                            for (j = 1; j <= n; j++)
                            {
                                if (b[i, j].Name == "1")
                                {
                                    b[i, j].BackgroundImage = Properties.Resources.Zid;
                                    b[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                                }
                                else
                                    b[i, j].BackColor = col;
                            }
                        timer1.Stop();
                        Variables.d = 0;
                    }
                }
            }
        }

        public void Labirint2(object sender, EventArgs e)
        {
            System.Drawing.Rectangle workingRectangle = Screen.PrimaryScreen.WorkingArea;
            q = 2; Variables.d = 0; ok = 0;
            f = File.OpenText("Labirint2.txt");
            Variables.s = f.ReadLine();
            sir = Variables.s.Split(' ');
            n = Int32.Parse(sir[0]);
            m = Int32.Parse(sir[1]);
            for (i = 1; i <= n; i++)
                for (j = 1; j <= m; j++)
                {
                    b[i, j] = new Button();
                    b[i, j].Width = 40;
                    b[i, j].Height = 55;
                    b[i, j].Top = workingRectangle.Height / 20 + 55 * i;
                    b[i, j].Left = ( workingRectangle.Width - 60 - 40 * m ) + 40 * j;
                    b[i, j].Enabled = false;
                    b[i, j].FlatStyle = FlatStyle.Flat;
                    b[i, j].FlatAppearance.BorderSize = 0;
                    Controls.Add(b[i, j]);
                }
            for (i = 1; i <= n; i++)
                for (j = 1; j <= m; j++)
                {
                    x = Int32.Parse(sir[q++]);
                    b[i, j].Name = Convert.ToString(x);
                    b[i, j].BackColor = Color.Black;
                    if (x == 0)                                                         
                        if (i == 1 || j == 1 || i == n || j == m)
                        {
                            b[i, j].Name = "usa";
                        }
                }
            r = new Random();
            while (ok == 0)
            {
                i = r.Next(2, n - 1);
                j = r.Next(2, m - 1);
                if (b[i, j].Name == "0")
                {
                    b[i, j].Name = "sc";
                    ok = 1;
                }
            }
            ok = 0;
            while (ok == 0)
            {
                i = r.Next(2, n - 1);
                j = r.Next(2, m - 1);
                if (b[i, j].Name == "0")
                {
                    b[i, j].BackgroundImage = Properties.Resources.Jos;
                    b[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    lumina(sender, e);
                    ok = 1;
                }
            }
        }

        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
            timer1.Start();  
            System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#474749");
            if (e.KeyCode == Keys.Up && i != 1 && b[i - 1, j].Name == "0" && Variables.d == 0 && ok2 == 0)
            {
                b[i, j].BackColor = col;
                b[i, j].BackgroundImage = null;
                i = i - 1;
                b[i, j].BackgroundImage = Properties.Resources.Sus;
                b[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                nr++;
                label1.Text = "" + nr;
                if (i > 1)
                    luminaW(sender, e);
                if (c == 1 && ok1 == 0 )
                {
                    if (b[i, j - 1].Name == "sc")
                    {
                        MessageBox.Show(" Ai găsit o statuietă ciudată în formă de scarabeu. Ai decis să o iei cu tine. ", " Mesaj ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ok = 0;
                        b[i, j - 1].Name = "0";
                        b[i, j - 1].BackColor = col;
                        b[i, j - 1].BackgroundImage = null;
                    }
                    if (b[i - 1, j].Name == "sc")
                    {
                        MessageBox.Show(" Ai găsit o statuietă ciudată în formă de scarabeu. Ai decis să o iei cu tine. ", " Mesaj ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ok = 0;
                        b[i - 1, j].Name = "0";
                        b[i - 1, j].BackColor = col;
                        b[i - 1, j].BackgroundImage = null;
                    }
                    if (b[i, j + 1].Name == "sc")
                    {
                        MessageBox.Show(" Ai găsit o statuietă ciudată în formă de scarabeu. Ai decis să o iei cu tine. ", " Mesaj ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ok = 0;
                        b[i, j + 1].Name = "0";
                        b[i, j + 1].BackColor = col;
                        b[i, j + 1].BackgroundImage = null;
                    }
                    if (b[i, j - 1].Name == "usa" || b[i - 1, j].Name == "usa" || b[i, j + 1].Name == "usa")
                        if (ok == 1)
                        {
                            MessageBox.Show(" O poartă masivă iți blochează calea. Uităndu-te mai atent, vezi o scobitură într-o formă ciudată. ", " Mesaj ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ordine = 1;
                        }
                    if (b[i, j - 1].Name == "usa" && ok == 0)
                    {
                        if (ordine == 0)
                            MessageBox.Show(" O poartă masivă iți blochează calea. Uităndu-te mai atent, vezi o scobitură într-o formă ciudată. ", " Mesaj ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show(" Ai așezat cu grijă scarabeul în gaura din poartă și aceasta s-a deschis. ", " Mesaj ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        b[i, j - 1].Name = "0";
                        b[i, j - 1].BackColor = col;
                        b[i, j - 1].BackgroundImage = null;
                        ok1 = 1;
                    }
                    if (b[i - 1, j].Name == "usa" && ok == 0)
                    {
                        if (ordine == 0)
                            MessageBox.Show(" O poartă masivă iți blochează calea. Uităndu-te mai atent, vezi o scobitură într-o formă ciudată. ", " Mesaj ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show(" Ai așezat cu grijă scarabeul în gaura din poartă și aceasta s-a deschis. ", " Mesaj ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        b[i - 1, j].Name = "0";
                        b[i - 1, j].BackColor = col;
                        b[i - 1, j].BackgroundImage = null;
                        ok1 = 1;
                    }
                    if (b[i, j + 1].Name == "usa" && ok == 0)
                    {
                        if (ordine == 0)
                            MessageBox.Show(" O poartă masivă iți blochează calea. Uităndu-te mai atent, vezi o scobitură într-o formă ciudată. ", " Mesaj ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show(" Ai așezat cu grijă scarabeul în gaura din poartă și aceasta s-a deschis. ", " Mesaj ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        b[i, j + 1].Name = "0";
                        b[i, j + 1].BackColor = col;
                        b[i, j + 1].BackgroundImage = null;
                        ok1 = 1;
                    }
                }
                if (i == 1)
                {
                    if (c == 0 && Variables.s != "ecoul" && Variables.s != "ecou" && Variables.s != "Ecou" && Variables.s != "Ecoul")
                    {
                        b[i + 1, j].BackgroundImage = Properties.Resources.Sus;
                        b[i + 1, j].BackgroundImageLayout = ImageLayout.Stretch;
                        o = i + 1;
                        b[i, j].BackgroundImage = Properties.Resources.Portal;
                        b[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                        b[i, j].Name = "2";
                        if (b[i + 2, j].Name == "0")
                        {
                            b[i + 2, j].BackgroundImage = Properties.Resources.Bariera;
                            b[i + 2, j].BackgroundImageLayout = ImageLayout.Stretch;
                            b[i + 2, j].Name = "2";
                        }
                        if (b[i + 1, j - 1].Name == "0")
                        {
                            b[i + 1, j - 1].BackgroundImage = Properties.Resources.Bariera;
                            b[i + 1, j - 1].BackgroundImageLayout = ImageLayout.Stretch;
                            b[i + 1, j - 1].Name = "2";
                        }
                        if (b[i + 1, j + 1].Name == "0")
                        {
                            b[i + 1, j + 1].BackgroundImage = Properties.Resources.Bariera;
                            b[i + 1, j + 1].BackgroundImageLayout = ImageLayout.Stretch;
                            b[i + 1, j + 1].Name = "2";
                        }
                        Variables.d = Variables.t;
                    }
                    if (c == 1 || Variables.s == "ecoul" || Variables.s == "ecou" || Variables.s == "Ecou" || Variables.s == "Ecoul")
                    {
                        Tunel Tunel = new Tunel();
                        Tunel.Show();
                        b[i, j].BackColor = col;
                        b[i, j].BackgroundImage = null;
                        ok2 = 1;
                        for (i = 1; i <= n; i++)
                            for (j = 1; j <= n; j++)
                            {
                                if (b[i, j].Name == "1")
                                {
                                    b[i, j].BackgroundImage = Properties.Resources.Zid;
                                    b[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                                }
                                else
                                    b[i, j].BackColor = col;
                            }
                        timer1.Stop();
                    }
                }
            }

            if (e.KeyCode == Keys.Left && j != 1 && b[i, j - 1].Name == "0" && Variables.d == 0 && ok2 == 0)
            {
                b[i, j].BackColor = col;
                b[i, j].BackgroundImage = null;
                j = j - 1;
                b[i, j].BackgroundImage = Properties.Resources.Stanga;
                b[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                nr++;
                label1.Text = "" + nr;
                if (j > 1)
                    luminaA(sender, e);
                if (c == 1 && ok1 == 0)
                {
                    if (b[i, j - 1].Name == "sc")
                    {
                        MessageBox.Show(" Ai găsit o statuietă ciudată în formă de scarabeu. Ai decis să o iei cu tine. ", " Mesaj ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ok = 0;
                        b[i, j - 1].Name = "0";
                        b[i, j - 1].BackColor = col;
                        b[i, j - 1].BackgroundImage = null;
                    }
                    if (b[i - 1, j].Name == "sc")
                    {
                        MessageBox.Show(" Ai găsit o statuietă ciudată în formă de scarabeu. Ai decis să o iei cu tine. ", " Mesaj ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ok = 0;
                        b[i - 1, j].Name = "0";
                        b[i - 1, j].BackColor = col;
                        b[i - 1, j].BackgroundImage = null;
                    }
                    if (b[i + 1, j].Name == "sc")
                    {
                        MessageBox.Show(" Ai găsit o statuietă ciudată în formă de scarabeu. Ai decis să o iei cu tine. ", " Mesaj ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ok = 0;
                        b[i + 1, j].Name = "0";
                        b[i + 1, j].BackColor = col;
                        b[i + 1, j].BackgroundImage = null;
                    }
                    if (b[i, j - 1].Name == "usa" || b[i - 1, j].Name == "usa" || b[i + 1, j].Name == "usa")
                        if (ok == 1)
                        {
                            MessageBox.Show(" O poartă masivă iți blochează calea. Uităndu-te mai atent, vezi o scobitură într-o formă ciudată. ", " Mesaj ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ordine = 1;
                        }
                    if (b[i, j - 1].Name == "usa" && ok == 0)
                    {
                        if (ordine == 0)
                            MessageBox.Show(" O poartă masivă iți blochează calea. Uităndu-te mai atent, vezi o scobitură într-o formă ciudată. ", " Mesaj ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show(" Ai așezat cu grijă scarabeul în gaura din poartă și aceasta s-a deschis. ", " Mesaj ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        b[i, j - 1].Name = "0";
                        b[i, j - 1].BackColor = col;
                        b[i, j - 1].BackgroundImage = null;
                        ok1 = 1;
                    }
                    if (b[i - 1, j].Name == "usa" && ok == 0)
                    {
                        if (ordine == 0)
                            MessageBox.Show(" O poartă masivă iți blochează calea. Uităndu-te mai atent, vezi o scobitură într-o formă ciudată. ", " Mesaj ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show(" Ai așezat cu grijă scarabeul în gaura din poartă și aceasta s-a deschis. ", " Mesaj ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        b[i - 1, j].Name = "0";
                        b[i - 1, j].BackColor = col;
                        b[i - 1, j].BackgroundImage = null;
                    }
                    if (b[i + 1, j].Name == "usa" && ok == 0)
                    {
                        if (ordine == 0)
                            MessageBox.Show(" O poartă masivă iți blochează calea. Uităndu-te mai atent, vezi o scobitură într-o formă ciudată. ", " Mesaj ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show(" Ai așezat cu grijă scarabeul în gaura din poartă și aceasta s-a deschis. ", " Mesaj ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        b[i + 1, j].Name = "0";
                        b[i + 1, j].BackColor = col;
                        b[i + 1, j].BackgroundImage = null;
                        ok1 = 1;
                    }
                }
                if (j == 1)
                {
                    if (c == 0)
                        if (Variables.s != "ecoul" && Variables.s != "ecou" && Variables.s != "Ecou" && Variables.s != "Ecoul")
                    {
                        b[i, j + 1].BackgroundImage = Properties.Resources.Stanga;
                        b[i, j + 1].BackgroundImageLayout = ImageLayout.Stretch;
                        p = j + 1;
                        b[i, j].BackgroundImage = Properties.Resources.Portal;
                        b[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                        b[i, j].Name = "2";
                        if (b[i - 1, j + 1].Name == "0")
                        {
                            b[i - 1, j + 1].BackgroundImage = Properties.Resources.Bariera;
                            b[i - 1, j + 1].BackgroundImageLayout = ImageLayout.Stretch;
                            b[i - 1, j + 1].Name = "2";
                        }
                        if (b[i + 1, j + 1].Name == "0")
                        {
                            b[i + 1, j + 1].BackgroundImage = Properties.Resources.Bariera;
                            b[i + 1, j + 1].BackgroundImageLayout = ImageLayout.Stretch;
                            b[i + 1, j + 1].Name = "2";
                        }
                        if (b[i, j + 2].Name == "0")
                        {
                            b[i, j + 2].BackgroundImage = Properties.Resources.Bariera;
                            b[i, j + 2].BackgroundImageLayout = ImageLayout.Stretch;
                            b[i, j + 2].Name = "2";
                        }
                        Variables.d = Variables.t;
                    }
                    if (c == 1 || Variables.s == "ecoul" || Variables.s == "ecou" || Variables.s == "Ecou" || Variables.s == "Ecoul")
                    {
                        Tunel Tunel = new Tunel();
                        Tunel.Show();
                        b[i, j].BackColor = col;
                        b[i, j].BackgroundImage = null;
                        ok2 = 1;
                        for (i = 1; i <= n; i++)
                            for (j = 1; j <= n; j++)
                            {
                                if (b[i, j].Name == "1")
                                {
                                    b[i, j].BackgroundImage = Properties.Resources.Zid;
                                    b[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                                }
                                else
                                    b[i, j].BackColor = col;
                            }
                        timer1.Stop();
                    }
                }
            }

            if (e.KeyCode == Keys.Down && i != n && b[i + 1, j].Name == "0" && Variables.d == 0 && ok2 == 0)
            {
                b[i, j].BackColor = col;
                b[i, j].BackgroundImage = null;
                i = i + 1;
                b[i, j].BackgroundImage = Properties.Resources.Jos;
                b[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                nr++;
                label1.Text = "" + nr;
                if (i < n)
                    luminaS(sender, e);
                if (c == 1 && ok1 == 0)
                {
                    if (b[i, j - 1].Name == "sc")
                    {
                        MessageBox.Show(" Ai găsit o statuietă ciudată în formă de scarabeu. Ai decis să o iei cu tine. ", " Mesaj ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ok = 0;
                        b[i, j - 1].Name = "0";
                        b[i, j - 1].BackColor = col;
                        b[i, j - 1].BackgroundImage = null;
                    }
                    if (b[i + 1, j].Name == "sc")
                    {
                        MessageBox.Show(" Ai găsit o statuietă ciudată în formă de scarabeu. Ai decis să o iei cu tine. ", " Mesaj ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ok = 0;
                        b[i + 1, j].Name = "0";
                        b[i + 1, j].BackColor = col;
                        b[i + 1, j].BackgroundImage = null;
                    }
                    if (b[i, j + 1].Name == "sc")
                    {
                        MessageBox.Show(" Ai găsit o statuietă ciudată în formă de scarabeu. Ai decis să o iei cu tine. ", " Mesaj ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ok = 0;
                        b[i, j + 1].Name = "0";
                        b[i, j + 1].BackColor = col;
                        b[i, j + 1].BackgroundImage = null;
                    }
                    if (b[i, j - 1].Name == "usa" || b[i + 1, j].Name == "usa" || b[i, j + 1].Name == "usa")
                        if (ok == 1)
                        {
                            MessageBox.Show(" O poartă masivă iți blochează calea. Uităndu-te mai atent, vezi o scobitură într-o formă ciudată. ", " Mesaj ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ordine = 1;
                        }
                    if (b[i, j - 1].Name == "usa" && ok == 0)
                    {
                        if (ordine == 0)
                            MessageBox.Show(" O poartă masivă iți blochează calea. Uităndu-te mai atent, vezi o scobitură într-o formă ciudată. ", " Mesaj ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show(" Ai așezat cu grijă scarabeul în gaura din poartă și aceasta s-a deschis. ", " Mesaj ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        b[i, j - 1].Name = "0";
                        b[i, j - 1].BackColor = col;
                        b[i, j - 1].BackgroundImage = null;
                        ok1 = 1;
                    }
                    if (b[i + 1, j].Name == "usa" && ok == 0)
                    {
                        if (ordine == 0)
                            MessageBox.Show(" O poartă masivă iți blochează calea. Uităndu-te mai atent, vezi o scobitură într-o formă ciudată. ", " Mesaj ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show(" Ai așezat cu grijă scarabeul în gaura din poartă și aceasta s-a deschis. ", " Mesaj ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        b[i + 1, j].Name = "0";
                        b[i + 1, j].BackColor = col;
                        b[i + 1, j].BackgroundImage = null;
                        ok1 = 1;
                    }
                    if (b[i, j + 1].Name == "usa" && ok == 0)
                    {
                        if (ordine == 0)
                            MessageBox.Show(" O poartă masivă iți blochează calea. Uităndu-te mai atent, vezi o scobitură într-o formă ciudată. ", " Mesaj ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show(" Ai așezat cu grijă scarabeul în gaura din poartă și aceasta s-a deschis. ", " Mesaj ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        b[i, j + 1].BackColor = col;
                        b[i, j + 1].BackgroundImage = null;
                        ok1 = 1;
                    }
                }
                if (i == n)
                {
                    if (c == 0)
                        if (Variables.s != "ecoul" && Variables.s != "ecou" && Variables.s != "Ecou" && Variables.s != "Ecoul")
                    {
                        b[i - 1, j].BackgroundImage = Properties.Resources.Jos;
                        b[i - 1, j].BackgroundImageLayout = ImageLayout.Stretch;
                        o = i - 1;
                        b[i, j].BackgroundImage = Properties.Resources.Portal;
                        b[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                        b[i, j].Name = "2";
                        if (b[i - 2, j].Name == "0")
                        {
                            b[i - 2, j].BackgroundImage = Properties.Resources.Bariera;
                            b[i - 2, j].BackgroundImageLayout = ImageLayout.Stretch;
                            b[i - 2, j].Name = "2";
                        }
                        if (b[i - 1, j + 1].Name == "0")
                        {
                            b[i - 1, j + 1].BackgroundImage = Properties.Resources.Bariera;
                            b[i - 1, j + 1].BackgroundImageLayout = ImageLayout.Stretch;
                            b[i - 1, j + 1].Name = "2";
                        }
                        if (b[i - 1, j - 1].Name == "0")
                        {
                            b[i - 1, j - 1].BackgroundImage = Properties.Resources.Bariera;
                            b[i - 1, j - 1].BackgroundImageLayout = ImageLayout.Stretch;
                            b[i - 1, j - 1].Name = "2";
                        }
                        Variables.d = Variables.t;
                    }
                    if (c == 1 || Variables.s == "ecoul" || Variables.s == "ecou" || Variables.s == "Ecou" || Variables.s == "Ecoul")
                    {
                        Tunel Tunel = new Tunel();
                        Tunel.Show();
                        b[i, j].BackColor = col;
                        b[i, j].BackgroundImage = null;
                        ok2 = 1;
                        for (i = 1; i <= n; i++)
                            for (j = 1; j <= n; j++)
                            {
                                if (b[i, j].Name == "1")
                                {
                                    b[i, j].BackgroundImage = Properties.Resources.Zid;
                                    b[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                                }
                                else
                                    b[i, j].BackColor = col;
                            }
                        timer1.Stop();
                    }
                }
            }

            if (e.KeyCode == Keys.Right && j != m && b[i, j + 1].Name == "0" && Variables.d == 0 && ok2 == 0)
            {
                b[i, j].BackColor = col;
                b[i, j].BackgroundImage = null;
                j = j + 1;
                b[i, j].BackgroundImage = Properties.Resources.Dreapta;
                b[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                nr++;
                label1.Text = "" + nr;
                if (j < m)
                    luminaD(sender, e);
                if (c == 1 && ok1 == 0)
                {
                    if (b[i, j + 1].Name == "sc")
                    {
                        MessageBox.Show(" Ai găsit o statuietă ciudată în formă de scarabeu. Ai decis să o iei cu tine. ", " Mesaj ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ok = 0;
                        b[i, j + 1].Name = "0";
                        b[i, j + 1].BackColor = col;
                        b[i, j + 1].BackgroundImage = null;

                    }
                    if (b[i - 1, j].Name == "sc")
                    {
                        MessageBox.Show(" Ai găsit o statuietă ciudată în formă de scarabeu. Ai decis să o iei cu tine. ", " Mesaj ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ok = 0;
                        b[i - 1, j].Name = "0";
                        b[i - 1, j].BackColor = col;
                        b[i - 1, j].BackgroundImage = null;
                    }
                    if (b[i + 1, j].Name == "sc")
                    {
                        MessageBox.Show(" Ai găsit o statuietă ciudată în formă de scarabeu. Ai decis să o iei cu tine. ", " Mesaj ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ok = 0;
                        b[i + 1, j].Name = "0";
                        b[i + 1, j].BackColor = col;
                        b[i + 1, j].BackgroundImage = null;
                    }
                    if (b[i + 1, j].Name == "usa" || b[i - 1, j].Name == "usa" || b[i, j + 1].Name == "usa")
                        if (ok == 1)
                        {
                            MessageBox.Show(" O poartă masivă iți blochează calea. Uităndu-te mai atent, vezi o scobitură într-o formă ciudată. ", " Mesaj ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ordine = 1;
                        }
                    if (b[i, j + 1].Name == "usa" && ok == 0)
                    {
                        if ( ordine == 0 )
                            MessageBox.Show(" O poartă masivă iți blochează calea. Uităndu-te mai atent, vezi o scobitură într-o formă ciudată. ", " Mesaj ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show(" Ai așezat cu grijă scarabeul în gaura din poartă și aceasta s-a deschis. ", " Mesaj ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        b[i, j + 1].BackColor = col;
                        b[i, j + 1].BackgroundImage = null;
                        ok1 = 1;
                    }
                    if (b[i - 1, j].Name == "usa" && ok == 0)
                    {
                        if (ordine == 0)
                            MessageBox.Show(" O poartă masivă iți blochează calea. Uităndu-te mai atent, vezi o scobitură într-o formă ciudată. ", " Mesaj ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show(" Ai așezat cu grijă scarabeul în gaura din poartă și aceasta s-a deschis. ", " Mesaj ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        b[i - 1, j].Name = "0";
                        b[i - 1, j].BackColor = col;
                        b[i - 1, j].BackgroundImage = null;
                        ok1 = 1;
                    }
                    if (b[i + 1, j].Name == "usa" && ok == 0)
                    {
                        if (ordine == 0)
                            MessageBox.Show(" O poartă masivă iți blochează calea. Uităndu-te mai atent, vezi o scobitură într-o formă ciudată. ", " Mesaj ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show(" Ai așezat cu grijă scarabeul în gaura din poartă și aceasta s-a deschis. ", " Mesaj ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        b[i + 1, j].Name = "0";
                        b[i + 1, j].BackColor = col;
                        b[i + 1, j].BackgroundImage = null;
                        ok1 = 1;
                    }
                }
                if (j == m)
                {
                    if (c == 0)
                        if (Variables.s != "ecoul" && Variables.s != "ecou" && Variables.s != "Ecou" && Variables.s != "Ecoul")
                    {
                        b[i, j - 1].BackgroundImage = Properties.Resources.Dreapta;
                        b[i, j - 1].BackgroundImageLayout = ImageLayout.Stretch;
                        p = j - 1;
                        b[i, j].BackgroundImage = Properties.Resources.Portal;
                        b[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                        b[i, j].Name = "2";
                        if (b[i - 1, j - 1].Name == "0")
                        {
                            b[i - 1, j - 1].BackgroundImage = Properties.Resources.Bariera;
                            b[i - 1, j - 1].BackgroundImageLayout = ImageLayout.Stretch;
                            b[i - 1, j - 1].Name = "2";
                        }
                        if (b[i + 1, j - 1].Name == "0")
                        {
                            b[i + 1, j - 1].BackgroundImage = Properties.Resources.Bariera;
                            b[i + 1, j - 1].BackgroundImageLayout = ImageLayout.Stretch;
                            b[i + 1, j - 1].Name = "2";
                        }
                        if (b[i, j - 2].Name == "0")
                        {
                            b[i, j - 2].BackgroundImage = Properties.Resources.Bariera;
                            b[i, j - 2].BackgroundImageLayout = ImageLayout.Stretch;
                            b[i, j - 2].Name = "2";
                        }
                        Variables.d = Variables.t;
                    }
                    if (c == 1 || Variables.s == "ecoul" || Variables.s == "ecou" || Variables.s == "Ecou" || Variables.s == "Ecoul")
                    {
                        Tunel Tunel = new Tunel();
                        Tunel.Show();
                        b[i, j].BackColor = col;
                        b[i, j].BackgroundImage = null;
                        ok2 = 1;
                        for (i = 1; i <= n; i++)
                            for (j = 1; j <= n; j++)
                            {
                                if (b[i, j].Name == "1")
                                {
                                    b[i, j].BackgroundImage = Properties.Resources.Zid;
                                    b[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                                }
                                else
                                    b[i, j].BackColor = col;
                            }
                        timer1.Stop();
                    }
                }
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }
    }
}
