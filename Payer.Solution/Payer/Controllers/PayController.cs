using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Payer.BusinessLayer;
using Payer.Entities;


namespace Payer.Controllers
{
    public class PayController : Controller
    {
        private readonly PayComputationManager payComputationManager = new PayComputationManager();
        private readonly EmployeeManager employeeManager = new EmployeeManager();
        private readonly TaxYearsManager taxYearsManager= new TaxYearsManager();

        private BusinessLayerResult<PaymentRecord> blResultPaymentRecord = new BusinessLayerResult<PaymentRecord>();
        // GET: Pay
        public ActionResult Index()
        {
            blResultPaymentRecord =payComputationManager.GetAllPayments();
            return View(blResultPaymentRecord.BlResultList);
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


    }
}