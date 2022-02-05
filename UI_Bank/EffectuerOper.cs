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
    public partial class EffectuerOper : Form
    {
        Client client;
        Compte compte;
        int id_compte;
        
        public EffectuerOper(Client cl,Compte compte,int id)
        {
            InitializeComponent();
            this.compte = compte;
            this.client = cl;
            labelsolde.Text = compte.getsolde();
            labeldevise.Text = compte.gettype();
            this.id_compte = id;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=banque;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets = True;");
            cn.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT Depot (id_compte,solde,devise) values ('" +this.id_compte + "','" + soldedepose.Text + "','" + deviseBox3.SelectedItem.ToString() + "')";
            cmd.Connection = cn;
            cn.Open();
            cmd.ExecuteNonQuery();
            bool res;
            res=this.compte.debiter(this.compte.convert_to_devise(int.Parse(compte.getsolde()), deviseBox3.SelectedItem.ToString()));
            if(res==true)
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update Compte (solde) values ('" +int.Parse(compte.getsolde()) + "')+where id="+id_compte;
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Operation bien effectuer");
            }
            else { MessageBox.Show("Operation echoué"); }
            // cmd.BeginExecuteNonQuery();
            
           // MessageBox.Show("Operation bien effectuer");
        }
    }
}
