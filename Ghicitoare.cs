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
    public partial class Ghicitoare : Form
    {
        public Ghicitoare()
        {
            InitializeComponent();
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void Ghicitoare_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form Labirint = Form.ActiveForm;
            Variables.s = textBox2.Text;
            if (Variables.s == "ecoul" || Variables.s == "ecou" || Variables.s == "Ecou" || Variables.s == "Ecoul")
            {
                Variables.d = Variables.t;
                this.Close();
            }
            else
            {
                Variables.d = Variables.t - 24;
                this.Close();
            }
        }

        private void Ghicitoare_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Form Labirint = Form.ActiveForm;
                Variables.s = textBox2.Text;
                if (Variables.s == "ecoul" || Variables.s == "ecou" || Variables.s == "Ecou" || Variables.s == "Ecoul")
                {
                    Variables.d = Variables.t;
                    this.Close();
                }
                else
                {
                    Variables.d = Variables.t - 24;
                    this.Close();
                }
            }
        }
    }
}
