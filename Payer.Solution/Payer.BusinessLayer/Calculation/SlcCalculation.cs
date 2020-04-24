using Payer.DataAccessLayer.EntityFramework;
using Payer.Entities;

namespace Payer.BusinessLayer.Calculation
{
    public class SlcCalculation
    {
        private Repository<Employee> repoEmployee = new Repository<Employee>();

        private decimal studentLoanRepaymentAmount;

        public decimal StudentLoanRepaymentAmount(StudentLoan studentLoan, decimal totalAmount)
        {
            if (studentLoan == StudentLoan.Yes)
            {
                if (totalAmount > 1750 && totalAmount < 2000)
                {
                    studentLoanRepaymentAmount = 15m;
                }
                else if (totalAmount >= 2000 && totalAmount < 2250)
                {
                    studentLoanRepaymentAmount = 38m;
                }
                else if (totalAmount >= 2250 && totalAmount < 2500)
                {
                    studentLoanRepaymentAmount = 60m;
                }
                else if (totalAmount >= 2500)
                {
                    studentLoanRepaymentAmount = 83m;
                }
                else
                {
                    studentLoanRepaymentAmount = 0;
                }
            }
            else
            {
                studentLoanRepaymentAmount = 0;
            }

            return studentLoanRepaymentAmount;
        }
    }
}