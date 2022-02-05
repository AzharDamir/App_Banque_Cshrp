using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App_B_Csh;
namespace UI_Bank
{
    public partial class Menu : Form
    {
        private Client client;
        private int id;
        private int id_compte;
        Compte compte;
        public Menu()
        {
            InitializeComponent();
        }
        public Menu(Client cl,int id)
        {
            InitializeComponent();
            this.client = cl;
            this.id = id;
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Comptes comptes = new Comptes(client,id);
            comptes.Show();
            this.Hide();
        }

    
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            EffectuerOper effectuerOper = new EffectuerOper(client,compte,id_compte);
           // effectuerOper.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Profil profil = new Profil(client,id);
            profil.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
           // Transactions transactions = new Transactions(Client cl, Comptes c);
           // transactions.Show();
            this.Hide();
        }
    }
}
