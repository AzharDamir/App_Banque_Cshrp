using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_B_Csh
{
    public class OperationA: Operation
    {
        private static String libel;
        public OperationA(Devise montant, Compte c): base(montant,c)
        {
            libel = "+";
        }
        public void afficher_op()
        {
            this.afficher_detail();
            Console.Write(libel);
            this.afficher_montant();
        }
    }
}
