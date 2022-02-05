using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_B_Csh
{
    public abstract class Devise
    {
        private double val;
        public Devise(double valeur) { this.val = valeur; }
        public virtual void afficher()
        {
            Console.Write(this.val + " ");
        }
        public abstract  MAD convert_to_mad();
        public abstract Euro convert_to_euro();
        public abstract Dollar convert_to_dollar();
        public static Devise operator +( Devise devise, Devise dev)
            {
               devise.val = devise.val+dev.val;
                return devise;
        }
        public static Devise operator -(Devise devise, Devise dev)
        {
            devise.val = devise.val - dev.val;
            return devise;
        }
        public static Devise operator *(Devise devise, Devise dev)
        {
            devise.val = devise.val * dev.val;
            return devise;
        }
        public static Devise operator /(Devise devise, Devise dev)
        {
            try
            {
                devise.val = devise.val / dev.val;
                return devise;

            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e);
            }
            return null;

        }
        public static Devise operator +(Devise devise, double dev)
        {
            devise.val = devise.val + dev;
            return devise;
        }
        public static Devise operator -(Devise devise,double dev)
        {
            devise.val = devise.val - dev;
            return devise;
        }
        public static Devise operator *(Devise devise,double dev)
        {
            devise.val = devise.val * dev;
            return devise;
        }
        public static Devise operator /(Devise devise,double dev)
        {
            try
            {
                devise.val = devise.val / dev;
                return devise;

            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e);
            }
            return null;
        }
        public static bool operator<(Devise devise,Devise dev)
        {
            return devise.val < dev.val;
        }
        public static bool operator >(Devise devise, Devise dev)
        {
            return devise.val > dev.val;
        }
        public static bool operator <=(Devise devise, Devise dev)
        {
            return devise.val <= dev.val;
        }
        public static bool operator >=(Devise devise, Devise dev)
        {
            return devise.val >= dev.val;
        }
        public  double convert_to_double(double taux)
        {
            return this.val * taux;
        } 
        public bool check_moitier(Devise D)
        {
            return this.val/2 <= D.val;
            
        }
        public bool check_solde(Devise dev, Devise devise)
        {
            return this.val >= (devise.val + dev.val);
        }
    }
}
