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

        public BusinessLayerResult<Employee> GetEmployeeById(int id)
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
                }
               
            }

            return blResultEmployee;
        }
    }
}