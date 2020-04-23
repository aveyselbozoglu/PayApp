using Payer.DataAccessLayer.EntityFramework;
using Payer.Entities;
using Payer.ViewModels;
using System;

namespace Payer.BusinessLayer
{
    public class EmployeeManager
    {
        private BusinessLayerResult<Employee> blResultEmployee = new BusinessLayerResult<Employee>();
        private Repository<Employee> repositoryEmployee = new Repository<Employee>();

        public BusinessLayerResult<Employee> GetEmployeeById(int? id)
        {
            var resultDb = repositoryEmployee.Find(x => x.Id == id);

            if (resultDb != null)
            {
                blResultEmployee.BlResult = resultDb;
            }

            return blResultEmployee;
        }

        public BusinessLayerResult<Employee> GetAllEmployees()
        {
            var resultDb = repositoryEmployee.List();

            if (resultDb.Count > 0)
            {
                blResultEmployee.BlResultList = resultDb;
            }

            return blResultEmployee;
        }

        public BusinessLayerResult<Employee> AddNewEmployee(EmployeeCreateViewModel employeeCreateViewModel)
        {
            if (employeeCreateViewModel != null)
            {
                if (repositoryEmployee.Find(x => x.EmployeeNo == employeeCreateViewModel.EmployeeNo) != null)
                {
                    // error
                    return null;
                }
                Employee newEmployee = new Employee()
                {
                    Address = employeeCreateViewModel.Address,
                    City = employeeCreateViewModel.City,
                    DateJoined = DateTime.Now.Date,
                    Designation = employeeCreateViewModel.Designation,
                    DOB = employeeCreateViewModel.DOB,
                    Email = employeeCreateViewModel.Email,
                    EmployeeNo = employeeCreateViewModel.EmployeeNo,
                    FirstName = employeeCreateViewModel.FirstName,
                    MiddleName = employeeCreateViewModel.MiddleName,
                    LastName = employeeCreateViewModel.LastName,
                    //FullName = employeeCreateViewModel.FirstName + " " + employeeCreateViewModel.MiddleName[0] + " " + employeeCreateViewModel.LastName,
                    FullName = employeeCreateViewModel.FullName,
                    PaymentMethod = employeeCreateViewModel.PaymentMethod,
                    StudentLoan = employeeCreateViewModel.StudentLoan,
                    UnionMember = employeeCreateViewModel.UnionMember,
                    Phone = employeeCreateViewModel.Phone,
                    Postcode = employeeCreateViewModel.Postcode,
                    ImageUrl = employeeCreateViewModel.ImageUrl,
                    Gender = employeeCreateViewModel.Gender,
                    NationalInsuranceNo = employeeCreateViewModel.NationalInsuranceNo
                };
                var checkIsEmployeeInserted = repositoryEmployee.Insert(newEmployee);
                if (checkIsEmployeeInserted > 0)
                {
                    blResultEmployee.BlResult = newEmployee;
                    //blResultEmployee.ToastrNotificationObject.Title = "Deneme";
                    //blResultEmployee.ToastrNotificationObject.Message = "Employee added succesfully";
                    //blResultEmployee.ToastrNotificationObject.ToastrNotificationType = ToastrNotificationType.Success;
                }
            }

            return blResultEmployee;
        }

        public BusinessLayerResult<Employee> EditEmployee(Employee employee)
        {
            if (employee != null)
            {
                blResultEmployee = GetEmployeeById(employee.Id);
                if (blResultEmployee.BlResult != null)
                {
                    blResultEmployee.BlResult.City = employee.City;
                    //blResultEmployee.BlResult.DateJoined = DateTime.Now.Date;
                    blResultEmployee.BlResult.Designation = employee.Designation;
                    blResultEmployee.BlResult.DOB = employee.DOB;
                    blResultEmployee.BlResult.Email = employee.Email;
                    //blResultEmployee.BlResult.EmployeeNo = employeeEditViewModel.EmployeeNo;
                    blResultEmployee.BlResult.FirstName = employee.FirstName;
                    blResultEmployee.BlResult.MiddleName = employee.MiddleName;
                    blResultEmployee.BlResult.LastName = employee.LastName;
                    blResultEmployee.BlResult.FullName =
                        employee.FirstName + " " + employee.MiddleName[0] + " " + employee.LastName;

                    blResultEmployee.BlResult.PaymentMethod = employee.PaymentMethod;
                    blResultEmployee.BlResult.StudentLoan = employee.StudentLoan;
                    blResultEmployee.BlResult.UnionMember = employee.UnionMember;
                    blResultEmployee.BlResult.Phone = employee.Phone;
                    blResultEmployee.BlResult.Postcode = employee.Postcode;
                    blResultEmployee.BlResult.ImageUrl = employee.ImageUrl;
                    blResultEmployee.BlResult.Gender = employee.Gender;
                    blResultEmployee.BlResult.NationalInsuranceNo = employee.NationalInsuranceNo;
                }
            }

            return blResultEmployee;
        }

        public BusinessLayerResult<Employee> DeleteEmployeeById(int? id)
        {
            blResultEmployee.BlResult = repositoryEmployee.Find(x => x.Id == id);

            if (blResultEmployee.BlResult != null)
            {
                blResultEmployee.IsDone = repositoryEmployee.Delete(blResultEmployee.BlResult);
            }
            return blResultEmployee;
        }
    }
}