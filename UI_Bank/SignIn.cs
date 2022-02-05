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
    public partial class SignIn : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=banque;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets = True;");
        
        public SignIn()
        {
            InitializeComponent();
           
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void SignIn_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(prenombox.Text ==string.Empty || nombox.Text == string.Empty ||telephonebox.Text== string.Empty||cinbox.Text== string.Empty||loginbox.Text== string.Empty||passwordbox.Text== string.Empty||confirmbox.Text== string.Empty)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                if (passwordbox.Text != confirmbox.Text)
                {
                    MessageBox.Show("Incorrect Password");
                }
                else
                {
                    try
                    {
                       // string query = "insert into Clients values ('" + nombox.Text + "','" + prenombox.Text + "','" + cinbox.Text + "','" + telephonebox.Text + "','" + loginbox.Text + "','" + passwordbox.Text+"')";
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "INSERT Clients (nom,prenom,cin,telephone,login,password) values ('" + nombox.Text + "','" + prenombox.Text + "','" + cinbox.Text + "','" + telephonebox.Text + "','" + loginbox.Text + "','" + passwordbox.Text + "')"; 
                        cmd.Connection = cn;
                        cn.Open();
                        // cmd.BeginExecuteNonQuery();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("ajout bien effectuer");
                         // cn.Close();
                        //Form1 form = new Form1();
                        //form.Show();
                        this.Hide();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "erreur");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
