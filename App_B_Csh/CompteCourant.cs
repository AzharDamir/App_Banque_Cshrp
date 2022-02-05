using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI_Bank;
namespace App_B_Csh
{
    public class CompteCourant:Compte
    {
        private Devise decouverte;
        public CompteCourant(Client client,Devise solde,Devise decou):base(client,solde)
        {
            if(solde >= decou)
            {
                this.decouverte = decou;
            }
        }
        public bool debiter(Devise montant)
        {
            bool val = false;
            if(this.decouverte is MAD)
            {
                val = this.comparerSolde(montant.convert_to_mad(), this.decouverte);
            }
            else if (this.decouverte is Euro)
            {
                val = this.comparerSolde(montant.convert_to_euro(), this.decouverte);
            }
            else if (this.decouverte is Dollar)
            {
                val = this.comparerSolde(montant.convert_to_dollar(), this.decouverte);
            }
            if(val == true)
            {
                base.debiter(montant);
                return true;
            }
            return false;
        }
        public new void consulter()
        {
            base.consulter();
        }
    }
}
