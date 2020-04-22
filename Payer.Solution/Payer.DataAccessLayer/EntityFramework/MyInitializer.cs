using System;
using Payer.Entities;
using System.Data.Entity;

namespace Payer.DataAccessLayer.EntityFramework
{
    public class MyInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            var employee = new Employee()
            {
                EmployeeNo = "1",
                FirstName = "ali",
                LastName = "boz",
                City = "bursa",
                Address = "adress",
                Postcode = "123"
                ,
                NationalInsuranceNo = "123",
                DOB = DateTime.Now,
                DateJoined = DateTime.Now
            };
            var c = context.Employees.Add(employee);
            var x = context.SaveChanges();
        }
    }
}