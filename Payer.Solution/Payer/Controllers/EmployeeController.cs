using Payer.BusinessLayer;
using Payer.Entities;
using Payer.ViewModels;
using System.Web;
using System.Web.Mvc;

namespace Payer.Controllers
{
    public class EmployeeController : Controller
    {
        private BusinessLayerResult<Employee> blResultEmployee = new BusinessLayerResult<Employee>();

        // GET: Employee
        public ActionResult Index()
        {
            var employeeManager = new EmployeeManager();

            var result = employeeManager.GetAllEmployees();
            return View(result.BlResultList);
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
                        $"employee_{employeeCreateViewModel.EmployeeNo}.{profileImage.ContentType.Split('/')[1]}";
                    employeeCreateViewModel.ImageUrl = fileName;
                    profileImage.SaveAs(Server.MapPath($"/Images/employee/{fileName}"));
                }

                var blResultEmployee = new EmployeeManager().AddNewEmployee(employeeCreateViewModel);

                if (blResultEmployee.BlResult != null)
                {
                    ViewBag.Message = "Message";
                    return RedirectToAction("Index");
                    
                }
                

            }
            return View(employeeCreateViewModel);
            
        }



        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(EmployeeCreateViewModel model)
        {
            return View();
        }
    }
}