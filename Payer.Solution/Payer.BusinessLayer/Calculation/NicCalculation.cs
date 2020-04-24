using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payer.BusinessLayer.Calculation
{
    public class NicCalculation
    {
        private decimal NIRate;
        private decimal NIC;

        public decimal NiContribution(decimal totalAmount)
        {
            if (totalAmount < 719)
            {
                NIC = 0m;
                NIRate = .0m;
            }else if (totalAmount >= 719 && totalAmount<=4167)
            {
                NIRate = .12m;
                NIC = ((totalAmount - 719) * NIRate);
            }else if (totalAmount > 4167)
            {
                NIRate = .02m;
                NIC = ((4167 - 719) * .12m) + ((totalAmount - 4167) * NIRate);
            }

            return NIC;
        }
    }
}
