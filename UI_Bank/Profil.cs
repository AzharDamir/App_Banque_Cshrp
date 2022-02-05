using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace UI_Bank
{
    public partial class Profil : Form
    {
        private Client client;
        private int id;
      
        public Profil(Client cl,int id)
        {
            InitializeComponent();
            this.client = cl;
            prenomlbl.Text = cl.getprenom();
            nomlbl.Text = cl.getnom();
            cinlbl.Text = cl.getcin();
            telelbl.Text=cl.gettelephone();
            this.id = id;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void retourbtn_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu(client,id);
            menu.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AjouterCompte ajout = new AjouterCompte(client, id);
            ajout.Show();
            this.Hide();
        }
    }
}
