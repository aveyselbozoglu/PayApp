using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payer.Entities;

namespace Payer.BusinessLayer.Calculation
{
    public class UnionFeeCalculation
    {
        private decimal unionFeeRepaymentAmount;

        public decimal UnionFeeRepayment(UnionMember unionMember)
        {
            if(unionMember == UnionMember.Yes)
            {
                unionFeeRepaymentAmount = 10m;
            }
            else
            {
                unionFeeRepaymentAmount= 0;
            }

            return unionFeeRepaymentAmount;
        }
        
        
    
    }
}
