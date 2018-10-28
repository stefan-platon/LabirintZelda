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
    public partial class MoarteF : Form
    {
        public MoarteF()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;  
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MoarteF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void MoarteF_Load(object sender, EventArgs e)
        {

        }
    }
}
