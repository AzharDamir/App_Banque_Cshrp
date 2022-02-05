using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_B_Csh
{
    public class MAD: Devise
    {
        private static double taux_dechange_euro;
		private static double taux_dechange_dollar;
        public MAD(double val):base(val)
        {
            taux_dechange_dollar = 0.11;
            taux_dechange_euro = 0.096;
        }
        public  override void afficher()
        {
            base.afficher();
            Console.WriteLine("MAD");
        }
        override
       public Euro convert_to_euro()
        {
            return new Euro(this.convert_to_double(taux_dechange_euro));
        }
        override
       public Dollar convert_to_dollar()
        {
            return new Dollar(this.convert_to_double(taux_dechange_dollar));
        }
        override
       public MAD convert_to_mad() { return this; }

    }
}
