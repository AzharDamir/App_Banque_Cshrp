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
using App_B_Csh;
namespace UI_Bank
{
    public partial class AjouterCompte : Form
    {
        Client client;
        int id;
        List<Compte> compte_cli;
        SqlDataReader reader;

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=banque;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets = True;");
        public AjouterCompte(Client cl,int id)
        {
            InitializeComponent();
            this.id = id;
            this.client = cl;
            this.compte_cli = new List<Compte>();
        }

        private void AjouterCompte_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Devisecombo_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void soldeBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (conn.State != ConnectionState.Open) conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
          //  "INSERT Clients (nom,prenom,cin,telephone,login,password) values ('" + nombox.Text + "','" + prenombox.Text + "','" + cinbox.Text + "','" + telephonebox.Text + "','" + loginbox.Text + "','" + passwordbox.Text + "')";
            adapter.InsertCommand = new SqlCommand("INSERT into Comptes (id_Client,type,Solde,devise) values ('" + this.id + "','" + comboBox1.SelectedItem.ToString() + "','"+ soldeBox1.Text+ "','" + Devisecombo.SelectedItem.ToString() + "')", conn);
            adapter.InsertCommand.ExecuteNonQuery();
            adapter.InsertCommand.Dispose();
            MessageBox.Show("ajout bien effectuer");
            conn.Close();
        }

      
    }
}
