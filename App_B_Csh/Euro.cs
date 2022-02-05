using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_B_Csh
{
    public class Euro:Devise
    {
        private static double taux_dechange_mad;
        private static double taux_dechange_dollar;
        public Euro(double val) : base(val)
        {
            taux_dechange_dollar = 1.13;
            taux_dechange_mad = 10.43;
        }
       
        public override void afficher()
        {
            base.afficher();
            Console.WriteLine("Euro");
        }
        override
        public MAD convert_to_mad()
        {
            return new MAD(this.convert_to_double(taux_dechange_mad));
        }
        override
       public Dollar convert_to_dollar()
        {
            return new Dollar(this.convert_to_double(taux_dechange_dollar));
        }
        override
            public Euro convert_to_euro()
        { return this; }
    }
}
