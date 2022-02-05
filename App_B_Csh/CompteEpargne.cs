using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI_Bank;
namespace App_B_Csh
{
    public class CompteEpargne:Compte
    {
        private double tauxInter;
        public CompteEpargne(Client c, Devise solde, double T) : base(c, solde)
        {
            if(T>0 && T <= 100) { tauxInter = T; }
        }
        public void calculInteret()
        {
            double a = this.tauxInter / 100;
            base.crediter(base.pourcentage(a));
        }
        public new void consulter()
        {
            base.consulter();
        } 
    }
}
