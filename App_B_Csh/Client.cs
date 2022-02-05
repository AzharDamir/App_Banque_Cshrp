using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App_B_Csh;
namespace UI_Bank
{
    public class Client
    {
        private string nom;
        private string prenom;
        private string cin;
        private string login;
        private string password;
        private string telephone;
        private List<Compte> list_compt;

        public Client(string n, String pre,string c, string l, string p,string tel)
        {
            nom = n;
            prenom = pre;
            cin = c;
            login = l;
            password = p;
            telephone =tel;
            this.list_compt= new List<Compte>();
        }
       public string getprenom() { return prenom; }
        public string getcin() { return cin; }
        public string gettelephone() { return telephone; }
        public string getnom()
        {
            return nom;

        }
        public Client() { }
        public void ajouterCompte(Compte compte)
        {
            if (list_compt.Contains(compte)) return;
            list_compt.Add(compte);
        }
        public void afficher()
        {
            string s = "Le nom:" + nom +"\n le prenom: "+prenom+ "\n le cin: " + cin + "\n login: " + login + "\n password: " + password;
            Console.WriteLine(s);
            Console.WriteLine("Les comptes");
            foreach(Compte compte in this.list_compt)
            {
                compte.consulter();
            }
          
        }
       
        public bool auth(string L, string p)
        {
            return (this.login == L && this.password == p);
           
        }
    }
}
