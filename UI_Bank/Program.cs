using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using App_B_Csh;
namespace UI_Bank
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           // MAD s1 = new MAD(5000);

           // Compte comptes1= new Compte(c1,s1);
            Application.Run(new Form1());
            /***********test code************
            Client client = new Client("azhar", "damir", "login", "password");
            Devise solde = new MAD(10000);
            Devise dec = new Dollar(3000);
            Devise s2 = new MAD(50000);
            Devise s3 = new Euro(6000);
            Devise s4 = new MAD(100);

            Compte compte1 = new Compte(client,solde);
            Compte compte2=new Compte(client, dec);
            //compte1.consulter();
            // compte1.crediter(dec);
            //compte1.consulter();
            // compte1.verser(s4, compte2);
            //compte2.consulter();
            client.afficher();
            *************/

        }
    }
}
