using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Payer.BusinessLayer.Calculation
{
    public class TaxCalculation
    {
        private decimal taxRate;
        private decimal tax;
        public decimal TaxAmount(decimal totalAmount)
        {
            
            if (totalAmount <= 1042)
            {
                taxRate = .0m;
                tax = totalAmount * taxRate;
            }
            else if (totalAmount > 1042 && totalAmount <= 3125)
            {
                taxRate = .2m;
                tax = (1042 * .0m )+ ((totalAmount - 1042) * taxRate);
            }
            else if(totalAmount > 3125 && totalAmount<=12500)
            {
                taxRate = .4m;
                tax = (1042 * .0m) + ((3125 - 1042 ) * .20m) +((totalAmount - 3125) * taxRate);
            }else if (totalAmount > 12500)
            {
                taxRate = .45m;
                tax = (1042 * .0m) + ((3125 - 1042) * .20m) + ((12500 - 3125) * .40m) + ((totalAmount -12500)*taxRate);
            }

            return tax;
        }
    }
}
