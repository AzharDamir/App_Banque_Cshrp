using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_B_Csh
{
    public class Dollar:Devise
    {
        private static double taux_dechange_euro;
        private static double taux_dechange_mad;
        public Dollar(double val) : base(val)
        {
            taux_dechange_mad = 9.25;
            taux_dechange_euro = 0.89;
        }
        public override void afficher()
        {
            base.afficher();
            Console.WriteLine(" Dollar");
        }
        override
        public MAD convert_to_mad()
        {
            return new MAD(this.convert_to_double(taux_dechange_mad));
        }
        override
        public Euro convert_to_euro()
        {
            return new Euro(this.convert_to_double(taux_dechange_euro));
        }
        override
        public Dollar convert_to_dollar()
        {
            return this;
        }
    }
}
