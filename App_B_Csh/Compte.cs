using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI_Bank;

namespace App_B_Csh
{
    public class Compte
    {
        private  int numcompte;
        private static int count=1;
        private Client client;
        private Devise solde;
        
        private static  Devise plafond;
        private  List<Operation> Historique;

        public Compte(Client cl,Devise solde)
        {
            this.client = cl;
            this.solde = solde;
            this.Historique = new List<Operation>();
            this.numcompte=count++;
            plafond = new MAD(2000);
            cl.ajouterCompte(this);
        }
        public Devise convert_to_devise(int solde,string type)
        {
            if (type == "Euro")
            {
                Euro sol=new Euro(solde);
                return sol;
            }else if(type == "Mad")
            {
                MAD sol=new MAD(solde);
                return sol;
            }else if (type == "Dollar")
            {
                Dollar sol=new Dollar(solde);
                return sol;
            }
            else { return null; }
        }
        public string getsolde() { return  this.solde.ToString(); }
        public string gettype() {
            if(this.solde is MAD)
            {
                return "Mad";
            }else if(this.solde is Dollar)
            {
                return "Dollar";
            }else if(this.solde is Euro)
            {
                return "Euro";
            }
            return null;
                }
        public void crediter(Devise devise)
        {
            if ((this.solde is MAD && devise is MAD) || (this.solde is Dollar && devise is Dollar) || (this.solde is Euro && devise is Euro))
            {
                this.solde = this.solde + devise;
            }
            else if(this.solde is MAD && devise is Dollar)
            {    
                this.solde = this.solde + devise.convert_to_mad();
            }
            else if (this.solde is MAD && devise is Euro)
            {
                this.solde = this.solde + devise.convert_to_mad();
            }
            else if (this.solde is Euro && devise is Dollar)
            {
                this.solde = this.solde + devise.convert_to_euro();
            }
            else if (this.solde is Euro && devise is MAD)
            {
                this.solde = this.solde + devise.convert_to_euro();
            }
            else if (this.solde is Dollar && devise is MAD)
            {
                this.solde = this.solde + devise.convert_to_dollar();
            }
            else if (this.solde is Dollar && devise is Euro)
            {
                this.solde = this.solde + devise.convert_to_dollar();
            }
            Operation op = new Operation(devise, this);
            this.Historique.Add(op);
        }
        public bool debiter(Devise devise)
        {
            if(devise.convert_to_mad() <= plafond)
            {
                if ((this.solde is MAD && devise is MAD) || (this.solde is Dollar && devise is Dollar) || (this.solde is Euro && devise is Euro))
                {
                    this.solde = this.solde - devise;
                }
                else if (this.solde is MAD && devise is Dollar)
                {
                    this.solde = this.solde - devise.convert_to_mad();
                }
                else if (this.solde is MAD && devise is Euro)
                {
                    this.solde = this.solde - devise.convert_to_mad();
                }
                else if (this.solde is Euro && devise is Dollar)
                {
                    this.solde = this.solde - devise.convert_to_euro();
                }
                else if (this.solde is Euro && devise is MAD)
                {
                    this.solde = this.solde - devise.convert_to_euro();
                }
                else if (this.solde is Dollar && devise is MAD)
                {
                    this.solde = this.solde - devise.convert_to_dollar();
                }
                else if (this.solde is Dollar && devise is Euro)
                {
                    this.solde = this.solde - devise.convert_to_dollar();
                }
                Operation op = new Operation(devise, this);
                this.Historique.Add(op);
                return true;
            }
            return false;
        }
        public bool verser(Devise devise, Compte c)
        {
            Console.WriteLine("le montant que vous avez : ");
            this.solde.afficher();
            Console.WriteLine("le montant que vous voulez verser : ");
            devise.afficher();
            if (this.debiter(devise) == true)
            {
                Console.WriteLine("l'operation de virement est bien effectue");
                this.solde.afficher();
                c.crediter(devise);
               
                return true;
            }
            Console.WriteLine("l'operation de virement n'est pas effectue");
            return false;
        }
        public void consulter()
        {
            Console.Write("num compte=");
            Console.Write(this.numcompte);
            Console.Write("\n");
            this.solde.afficher();
    
           foreach (Operation op in this.Historique)
            {
                op.afficher_detail();
            }
        }
        public Devise pourcentage(double a)
        {
            return (this.solde) * a;
        }
        public bool checksup(Devise M)
        {
            return (this.solde) >= M;
        }
        public bool comparerSolde(Devise M, Devise N)
        {
            return this.solde.check_solde(M, N); 
        }
        public bool comparer_moitier(Devise devise)
        {
            if(this.solde is MAD)
            {
                return this.solde.check_moitier(devise.convert_to_mad());
            }
            else if (this.solde is Euro)
            {
                return this.solde.check_moitier(devise.convert_to_euro());
            }
               
            else if (this.solde is Dollar)
            {
                return this.solde.check_moitier(devise.convert_to_dollar());
            }
            return false;  
            
        }
    }


}
