using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabirintZelda
{
    public partial class Meniu : Form
    {
        public Meniu()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.TopMost = true;  
        }

        private void Meniu_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
            label3.Visible = true;
            label1.Visible = false;
            button3.Enabled = false;
            button2.Enabled = true;
            button2.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Meniu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Labirint Labirint = new Labirint();
                Labirint.Close();
                this.Close();
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
