using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payer.DataAccessLayer.EntityFramework;
using Payer.Entities;


namespace Payer.BusinessLayer
{
    public class PayComputationManager
    {
        private BusinessLayerResult<PaymentRecord> blResultPaymentRecord = new BusinessLayerResult<PaymentRecord>();
        private Repository<PaymentRecord> repositoryPaymentRecord = new Repository<PaymentRecord>();
        private Repository<Employee> repositoryEmployee = new Repository<Employee>();
        
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
                        NiNo = paymentRecord.NiNo,
                        PayDate = paymentRecord.PayDate,
                        EmployeeId = paymentRecord.EmployeeId,
                        TaxYearId = paymentRecord.TaxYearId,
                        TaxCode = paymentRecord.TaxCode,
                        HoursWorked = paymentRecord.HoursWorked,
                        HourlyRate = paymentRecord.HourlyRate,
                        ContractualEarnings = paymentRecord.ContractualEarnings,
                        OvertimeHours = paymentRecord.OvertimeHours,
                        OvertimeEarnings = paymentRecord.OvertimeEarnings,
                        Tax = paymentRecord.Tax,
                        NIC = paymentRecord.NIC,
                        SLC = paymentRecord.SLC,
                        TotalDeduction = paymentRecord.TotalDeduction,
                        NetPayment = paymentRecord.NetPayment,
                        PayMonth = paymentRecord.PayMonth
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

        //public BusinessLayerResult<PaymentRecord> ContractualEarnings()
        //{


        //}
        


    }
}
