using Payer.Entities;
using System;
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
                Postcode = "123",
                NationalInsuranceNo = "123",
                DOB = DateTime.Now,
                DateJoined = DateTime.Now
            };
            var c = context.Employees.Add(employee);
            var x = context.SaveChanges();

            var taxyears = new TaxYear()
            {
                YearOfTax = "2020"
            };
            var taxyears2 = new TaxYear()
            {
                YearOfTax = "2022"
            };

            var t = context.TaxYears.Add(taxyears);
            var t2 = context.TaxYears.Add(taxyears2);
            var y = context.SaveChanges();
        }
    }
}