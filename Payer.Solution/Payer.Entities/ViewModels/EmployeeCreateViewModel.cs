using Payer.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Payer.ViewModels
{
    public class EmployeeCreateViewModel
    {
        [Required(ErrorMessage = "Employee Number is required"),
            //RegularExpression(@"^[A-Z]{3,3}[0-9]{3}$")
            ]
        public string EmployeeNo { get; set; }


        //[RegularExpression(@"^[A-Z][a-zA-Z""'\s-]*$"),
        [Required(ErrorMessage = "First Name is required"),
         StringLength(50, MinimumLength = 2),
        Display(Name = "First Name")]

        public string FirstName { get; set; }

        [StringLength(50), Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        //[RegularExpression(@"^[A-Z][a-zA-Z""'\s-]*$")
        [Required(ErrorMessage = "Last Name is required"), StringLength(50, MinimumLength = 2)
        , Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + (string.IsNullOrEmpty(MiddleName) ? " " : (" " + (char?)MiddleName[0] + ". ").ToUpper()) + LastName;
            }
        }

        public string Gender { get; set; }

        [Display(Name = "Photo")]
        public string ImageUrl { get; set; }

        [DataType(DataType.Date), Display(Name = "Date Of Birth")]
        public DateTime DOB { get; set; }

        [DataType(DataType.Date), Display(Name = "Date Joined")]
        public DateTime DateJoined { get; set; } = DateTime.UtcNow;

        public string Phone { get; set; }

        [Required(ErrorMessage = "Job Role is required"), StringLength(100)]
        public string Designation { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //[RegularExpression(@"^[A-CEGHJ-PR-TW-Z]{1}[A-CEGHJ-NPR-TW-Z]{1}[0-9]{6}[A-D\s]$")]
        [Required, StringLength(50), Display(Name = "NI No.")]
        public string NationalInsuranceNo { get; set; }

        [Display(Name = "Payment Method")]
        public PaymentMethod PaymentMethod { get; set; }

        [Display(Name = "Student Loan")]
        public StudentLoan StudentLoan { get; set; }

        [Display(Name = "Union Member")]
        public UnionMember UnionMember { get; set; }

        [Required(ErrorMessage = "Address is required"), StringLength(150)]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required"), StringLength(50)]
        public string City { get; set; }

        [Required(ErrorMessage = "Postcode is required"), StringLength(50)]
        public string Postcode { get; set; }
    }
}