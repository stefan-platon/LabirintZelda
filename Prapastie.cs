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
    public partial class Prapastie : Form
    {
        public Prapastie()
        {
            InitializeComponent();
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            MessageBox.Show("Începi să te cațeri pe stâncă. Înaintezi, însă foarte încet. Deodată vezi cum pietrele de deasupra ta încep să cadă. Încerci să te ferești dar o piatră te lovește la cap. Te desprinzi de stâncă și cazi liber spre pământ, nefiind nimic între tine și el. În ultimele clipe, cu vederea încețoșată, observi cum turnul din vârful muntelui se depărtează rapid. Apoi, încet, în lumina lunii, îți închizi ochii și devii inconștient. Înălțimea este mult prea mare pentru a putea supraviețui căderii.", " Mesaj ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MoarteF MoarteF = new MoarteF();
            MoarteF.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            MessageBox.Show(" Te grăbești să inspectezi piatra din spatele tău. Începi să o împingi din toate părțile, însă fără succes. Este clar că nu poți trece pe aici. Dezamăgit, te îndrepți din nou spre prăpastie.", " Mesaj ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            MessageBox.Show("În timp ce dormi, tunelul în care stai începe să se fisureze. Sunetul este de ajuns să te trezească, dar era deja este târziu. În doar căteva momente întreg tavanul a căzut, atât în jurul tău, cât și pe tine, astupând aproape complet calea către prăpastie. Cu ambele ieșiri blocate și fiind rănit grav, știi că nu vei mai supraviețui mult. În ultimele clipe, vezi din nou creatura ce ți-a spus ghicitoarea stând în fața ta, fără a spune sau face nimic. Apoi, încet, îți închizi ochii pentru ultima dată.", " Mesaj ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MoarteF MoarteF = new MoarteF();
            MoarteF.Show();
            this.Close();
        }

        private void Prapastie_Load(object sender, EventArgs e)
        {
            
        }
    }
}
