using Payer.BusinessLayer.Calculation;
using Payer.DataAccessLayer.EntityFramework;
using Payer.Entities;

namespace Payer.BusinessLayer
{
    public class PayComputationManager
    {
        private BusinessLayerResult<PaymentRecord> blResultPaymentRecord = new BusinessLayerResult<PaymentRecord>();
        private Repository<PaymentRecord> repositoryPaymentRecord = new Repository<PaymentRecord>();
        private Repository<Employee> repositoryEmployee = new Repository<Employee>();
        private TaxCalculation taxCalculation = new TaxCalculation();
        private NicCalculation nicCalculation = new NicCalculation();
        private SlcCalculation slcCalculation = new SlcCalculation();
        private UnionFeeCalculation unionFeeCalculation = new UnionFeeCalculation();

        public decimal totalEarnings, totalDeduction, tax, nic, slc, unionfee;

        public BusinessLayerResult<PaymentRecord> CreatePaymentMethod(PaymentRecord paymentRecord)
        {
            if (paymentRecord != null)
            {
                var checkEmployeeIfExists = repositoryEmployee.Find(x => x.Id == paymentRecord.EmployeeId);

                if (checkEmployeeIfExists != null)
                {
                    PaymentRecord newPaymentRecord = new PaymentRecord()
                    {
                        FullName = repositoryEmployee.Find(x => x.Id == paymentRecord.EmployeeId).FullName,
                        NiNo = repositoryEmployee.Find(x => x.Id == paymentRecord.EmployeeId).NationalInsuranceNo,
                        PayDate = paymentRecord.PayDate,
                        EmployeeId = paymentRecord.EmployeeId,
                        TaxYearId = paymentRecord.TaxYearId,
                        TaxCode = paymentRecord.TaxCode,
                        HoursWorked = paymentRecord.HoursWorked,
                        HourlyRate = paymentRecord.HourlyRate,

                        PayMonth = paymentRecord.PayMonth,

                        ContractualHours = paymentRecord.ContractualHours,

                        ContractualEarnings = ContractualEarnings(paymentRecord.ContractualHours, paymentRecord.HoursWorked, paymentRecord.HourlyRate),

                        OvertimeHours = OvertimeHours(paymentRecord.HoursWorked, paymentRecord.ContractualHours),

                        OvertimeEarnings = OvertimeEarnings(OvertimeRate(paymentRecord.HourlyRate), OvertimeHours(paymentRecord.HoursWorked, paymentRecord.ContractualHours)),

                        

                        //TotalEarnings = TotalEarnings(ContractualEarnings(paymentRecord.ContractualHours, paymentRecord.HoursWorked, paymentRecord.HourlyRate), OvertimeEarnings(OvertimeRate(paymentRecord.HourlyRate), paymentRecord.OvertimeHours)),
                        TotalEarnings = totalEarnings = TotalEarnings(OvertimeEarnings(OvertimeRate(paymentRecord.HourlyRate), OvertimeHours(paymentRecord.HoursWorked, paymentRecord.ContractualHours)), ContractualEarnings(paymentRecord.ContractualHours, paymentRecord.HoursWorked, paymentRecord.HourlyRate)),

                        Tax = tax = taxCalculation.TaxAmount(totalEarnings),

                        NIC = nic = nicCalculation.NiContribution(totalEarnings),

                        SLC = slc = slcCalculation.StudentLoanRepaymentAmount(checkEmployeeIfExists.StudentLoan, totalEarnings),

                        UnionFee = unionfee = unionFeeCalculation.UnionFeeRepayment(checkEmployeeIfExists.UnionMember),

                        TotalDeduction = totalDeduction = TotalDeduction(tax, nic, slc, unionfee),

                        NetPayment = NetPayment(totalEarnings, totalDeduction)
                    };

                    blResultPaymentRecord.IsDone = repositoryPaymentRecord.Insert(newPaymentRecord);
                }
            }
            return blResultPaymentRecord;
        }

        public BusinessLayerResult<PaymentRecord> GetAllPayments()
        {
            blResultPaymentRecord.BlResultList = repositoryPaymentRecord.List();

            return blResultPaymentRecord;
        }

        //public BusinessLayerResult<PaymentRecord> GetPaymentRecordById(int id)
        //{
        //}
        //

        public BusinessLayerResult<PaymentRecord> GetPaymentRecordById(int? id)
        {

            if (id != null)
            {
                blResultPaymentRecord.BlResult= repositoryPaymentRecord.Find(x => x.Id == id);
            }

            return blResultPaymentRecord;
        }











        public decimal ContractualEarnings(decimal contractualHours, decimal hoursWorked, decimal hourlyRate)
        {
            decimal contractualEarnings;
            if (hoursWorked < contractualHours)
            {
                contractualEarnings = hoursWorked * hourlyRate;
            }
            else
            {
                contractualEarnings = hourlyRate * contractualHours;
            }

            return contractualEarnings;
        }

        //
        public decimal OvertimeEarnings(decimal overtimeRate, decimal overtimeHours)
        {
            return overtimeHours * overtimeRate;
        }

        //
        public decimal OvertimeHours(decimal hoursWorked, decimal contractualHours)
        {
            decimal overtimeHours;

            if (hoursWorked > contractualHours)
            {
                overtimeHours = hoursWorked - contractualHours;
            }
            else
            {
                overtimeHours = 0.00m;
            }

            return overtimeHours;
        }

        //
        public decimal OvertimeRate(decimal hourlyRate)
        {
            return hourlyRate * 1.5m;
        }

        public decimal TotalDeduction(decimal tax, decimal nic, decimal studentLoanRepayment, decimal unionFees) => tax + nic + studentLoanRepayment + unionFees;

        public decimal TotalEarnings(decimal overtimeEarnings, decimal contractualEarnings) => overtimeEarnings + contractualEarnings;

        public decimal NetPayment(decimal totalEarnings, decimal totalDeduction) => totalEarnings - totalDeduction;

        
    }
}