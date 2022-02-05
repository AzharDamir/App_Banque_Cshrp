using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_B_Csh
{
    public class Operation
    {
        private  int num;
        private static int cpt=0;
        private Devise montant;
        private DateTime date;
        private Compte c;
        public Operation(Devise montant, Compte c)
        {
            this.montant = montant;
            this.c = c;
            date = DateTime.Now;
            this.num = cpt++;
        }
        public void afficher_detail()
        {
            Console.Write("-------------Detail De l'operation numero "+ this.num+ "------------------\n");
            Console.Write(" la date : "+ this.date.ToString("dddd, dd MMMM yyyy")+"\t\t\t");
            Console.Write("le solde est: ");
            this.montant.afficher();
        }
        public void afficher_montant()
        {
            this.montant.afficher();
        }
    }
}
