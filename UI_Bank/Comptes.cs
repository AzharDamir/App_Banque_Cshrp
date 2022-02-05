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
    public partial class Comptes : Form
    {
        SqlDataReader reader;

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=banque;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets = True;");
      
        SqlCommand cmd;
        int id;
        Client client;
        List<Compte> compte_cli;
        public Comptes(Client cl,int id)
        {
            InitializeComponent();
            this.client = cl;
            this.compte_cli = new List<Compte>();
            this.id = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu(client, id);
            menu.Show();
            this.Hide();
        }
        public List<int> Request_Result_Compte(int Id, SqlConnection conn)
        {
            SqlDataReader reader;
            List<int> lst = new List<int>();
            SqlCommand cmd = new SqlCommand("Select * from Comptes where Comptes.id_client=" + Id, conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lst.Add(Int32.Parse(reader.GetValue(0).ToString()));
            }
            return lst;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
         
        }

        private void Comptes_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from Comptes where Comptes.id_client=" + this.id, conn);
            conn.Open();
            reader = cmd.ExecuteReader();
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Add("type de compte", "type");
            dataGridView1.Columns.Add("solde", "solde");
            dataGridView1.Columns.Add("devise", "devise");
           
            int j = 0;
            while (reader.Read())
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[j].Cells[0].Value = reader["type"];
                dataGridView1.Rows[j].Cells[1].Value = reader["Solde"];
                dataGridView1.Rows[j].Cells[2].Value = reader["devise"];
                j++;
            }
            conn.Close();
        }
    }
}
