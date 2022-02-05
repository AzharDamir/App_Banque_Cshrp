using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI_Bank;
namespace App_B_Csh
{
    public class ComptePayant:Compte
    {
        private static double coutop=0.05;
        public ComptePayant(Client client, Devise solde, Devise M) : base(client, solde)
        {
        }
        public new bool debiter(Devise M)
        {
            return base.debiter(M*(1-coutop));
        }
        public new void crediter(Devise M)
        {
            base.crediter(M*(1+coutop));
        }
        public new void consulter() { base.consulter(); }
    }
}
