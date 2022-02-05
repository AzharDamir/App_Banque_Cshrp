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
    public partial class Form1 : Form
    {
        List<Client> clients = new List<Client>();

       // Client c1 = new Client("rochdi","youssra", "le2578", "ilisi2", "password");
       // Client c2 = new Client("damir","azhar", "LE2514", "azhar", "damir");

       // MAD s1;//=new MAD(5000);

       // Compte comptes1;//= new Compte(c1,s1);
        static public Client Client_auth;

        SqlConnection cn;
        SqlCommand cmd;
        public Form1()
        {
            InitializeComponent();
            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=banque;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets = True;");
            cn.Open();
           /* s1 =new MAD(5000);

            comptes1= new Compte(c1,s1);
            
            clients.Add(c1);
            clients.Add(c2);
           */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != string.Empty || textBox2.Text != string.Empty)
                {

                    cmd = new SqlCommand("select * from Clients where login='" + textBox1.Text + "' and password='" + textBox2.Text + "'", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        Client_auth = new Client(dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetString(5), dr.GetString(6), dr.GetString(4));
                       // dr.Close();
                       
                        MessageBox.Show("Hello " + Client_auth.getnom());
                        Menu menu= new Menu(Client_auth, Int32.Parse(dr["id"].ToString()));
                        String s = dr["id"].ToString();
                        menu.Show();
                        this.Hide();
                    }
                    else
                    {
                        dr.Close();
                        MessageBox.Show("No Account avilable with this username and password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("L'erreur suivante a été rencontrée :" + exp.Message);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SignIn effectuerOper = new SignIn();
            effectuerOper.Show();
            this.Hide();
        }
    }
}
