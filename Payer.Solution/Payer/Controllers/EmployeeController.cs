using Payer.BusinessLayer;
using Payer.Entities;
using Payer.ViewModels;
using System;
using System.Web;
using System.Web.Mvc;
using Payer.Filter;

namespace Payer.Controllers
{
    [AuthAdmin]
    public class EmployeeController : Controller
    {
        private readonly PayComputationManager payComputationManager = new PayComputationManager();
        private readonly EmployeeManager employeeManager = new EmployeeManager();
        private readonly TaxYearsManager taxYearsManager = new TaxYearsManager();
        private BusinessLayerResult<Employee> blResultEmployee;

        private ListPagination<Employee> listPaginationEmployeeRecords;

        public EmployeeController()
        {
            blResultEmployee = new BusinessLayerResult<Employee>();
        }

        // GET: Employee
        public ActionResult Index(int? pageIndex)
        {

            blResultEmployee = employeeManager.GetAllEmployees();


            if (blResultEmployee.BlResultList != null)
            {
                listPaginationEmployeeRecords = ListPagination<Employee>.Create(blResultEmployee.BlResultList, pageIndex ?? 1, 3);
            }

            return View(listPaginationEmployeeRecords);


        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeCreateViewModel employeeCreateViewModel, HttpPostedFileBase profileImage)
        {
            if (ModelState.IsValid)
            {
                if (profileImage != null && (profileImage.ContentType == "image/jpg" ||
                                             profileImage.ContentType == "image/png" ||
                                             profileImage.ContentType == "image/jpeg"))
                {
                    string fileName =
                        $"employee_{employeeCreateViewModel.EmployeeNo}_time_{DateTime.Now.ToShortDateString()}.{profileImage.ContentType.Split('/')[1]}";
                    employeeCreateViewModel.ImageUrl = fileName;
                    profileImage.SaveAs(Server.MapPath($"/Images/employee/{fileName}"));
                }

                var blResultEmployee = new EmployeeManager().AddNewEmployee(employeeCreateViewModel);

                if (blResultEmployee.BlResult != null)
                {
                    //blResultEmployee.ToastrNotificationObject.Title = "Deneme";
                    //blResultEmployee.ToastrNotificationObject.Message = "Employee added succesfully";
                    //blResultEmployee.ToastrNotificationObject.ToastrNotificationType = ToastrNotificationType.Success;

                    //Alert("Başarılı" , NotificationType.success);
                    return RedirectToAction("Index");
                }
            }

            return View(employeeCreateViewModel);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                var employeeManager = new EmployeeManager();
                blResultEmployee = employeeManager.GetEmployeeById(id);
            }

            return View(blResultEmployee.BlResult);
        }

        [HttpPost]
        public ActionResult Edit(Employee updatedEmployee, HttpPostedFileBase profileImage)
        {
            var employeeManager = new EmployeeManager();
            ModelState.Remove("EmployeeNo");
            if (ModelState.IsValid)
            {
                if (profileImage != null && (profileImage.ContentType == "image/jpg" ||
                                             profileImage.ContentType == "image/png" ||
                                             profileImage.ContentType == "image/jpeg"))
                {
                    string fileName =
                        $"employee_{updatedEmployee.EmployeeNo}_time_{DateTime.Now.ToShortDateString()}.{profileImage.ContentType.Split('/')[1]}";
                    updatedEmployee.ImageUrl = fileName;
                    profileImage.SaveAs(Server.MapPath($"/Images/employee/{fileName}"));
                }
                employeeManager.EditEmployee(updatedEmployee);
                return RedirectToAction("Index");
            }

            return View(updatedEmployee);
        }

        public ActionResult Detail(int? id)
        {
            if (id != null)
            {
                var employeeManager = new EmployeeManager();
                blResultEmployee = employeeManager.GetEmployeeById(id);
            }

            return View(blResultEmployee.BlResult);
        }

        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                var employeeManager = new EmployeeManager();
                blResultEmployee = employeeManager.DeleteEmployeeById(id);

                if (blResultEmployee.IsDone > 0)
                {
                    TempData["toastmessage"] = "Deleted";
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }

        //    public void Alert(string message, NotificationType notificationType)
        //    {
        //        var msg = "toastr." + notificationType.ToString().ToLower() + "('" + message + "','" + notificationType + "')" + "";
        //        TempData["notification"] = msg;
        //    }
        //}
        //public enum NotificationType
        //{
        //    error,
        //    success,
        //    warning,
        //    info
        //};
    }
}