using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Payer.BusinessLayer;
using Payer.Entities;
using Payer.Filter;
using Rotativa;


namespace Payer.Controllers
{
    [AuthAdmin]
    public class PayController : Controller
    {
        private readonly PayComputationManager payComputationManager = new PayComputationManager();
        private readonly EmployeeManager employeeManager = new EmployeeManager();
        private readonly TaxYearsManager taxYearsManager= new TaxYearsManager();

        private BusinessLayerResult<PaymentRecord> blResultPaymentRecord;
        public PayController()
        {
            blResultPaymentRecord = new BusinessLayerResult<PaymentRecord>();
        }

        
        
        public ActionResult Index(int? pageIndex)
        {
            blResultPaymentRecord =payComputationManager.GetAllPayments();
            ListPagination<PaymentRecord> listPaginationPaymentRecords = null;

            if (blResultPaymentRecord.BlResultList != null)
            {
                listPaginationPaymentRecords = ListPagination<PaymentRecord>.Create(blResultPaymentRecord.BlResultList, pageIndex ?? 1, 3);
            }

            return View(listPaginationPaymentRecords);
        }

        public ActionResult Create()
        {

            // PAY ATTENTION
            ViewBag.Employees = new SelectList(employeeManager.GetAllEmployees().BlResultList, "Id", "FullName");
            ViewBag.TaxYears = new SelectList(taxYearsManager.GetAllTaxYears().BlResultList, "Id", "YearOfTax");
            
            return View();
        }

        [HttpPost]
        public ActionResult Create(PaymentRecord paymentRecord)
        {
            if (ModelState.IsValid)
            {
                blResultPaymentRecord = payComputationManager.CreatePaymentMethod(paymentRecord);

                if (blResultPaymentRecord.IsDone>0)
                {
                    return RedirectToAction("Index");
                }
            }
            
            return View(paymentRecord);
        }

        public ActionResult Detail(int? id)
        {
            if (id != null)
            {
                blResultPaymentRecord = payComputationManager.GetPaymentRecordById(id);
                return View(blResultPaymentRecord.BlResult);
            }

            return RedirectToAction("Index");

        }

        public ActionResult Payslip(int? id)
        {
            if (id != null)
            {
                blResultPaymentRecord = payComputationManager.GetPaymentRecordById(id);
                return View(blResultPaymentRecord.BlResult);
            }
            return RedirectToAction("Index");
        }

        public ActionResult GeneratePayslipPdf(int? id)
        {
            if (id != null)
            {
                blResultPaymentRecord = payComputationManager.GetPaymentRecordById(id);
                //var payslip =
                //return new ViewAsPdf("Payslip", new {id = id})
                //{
                //    FileName = blResultPaymentRecord.BlResult.EmployeeId+"_"+"_"+DateTime.Now+"_payslip.pdf"
                //};
                // return payslip;
                if (blResultPaymentRecord.BlResult != null)
                {

                    return new ViewAsPdf("GeneratePayslipPdf", blResultPaymentRecord.BlResult)
                    {
                        FileName = blResultPaymentRecord.BlResult.EmployeeId + "_" + DateTime.Now.ToLocalTime() + "_payslip.pdf",
                        
                        PageSize = Rotativa.Options.Size.A4,


                    };
                }
            }

            return RedirectToAction("Index");
        }
    }
}