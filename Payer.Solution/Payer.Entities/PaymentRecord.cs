using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Payer.Entities
{
    public class PaymentRecord
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100)] public string FullName { get; set; }
        public string NiNo { get; set; }

        public DateTime PayDate { get; set; } = DateTime.Now;

        public string PayMonth { get; set; }
        
        public string TaxCode { get; set; }

        [Column(TypeName = "money")]
        public decimal HourlyRate { get; set; }
        public decimal HoursWorked { get; set; }
        public decimal ContractualHours { get; set; }
        public decimal OvertimeHours { get; set; }

        [Column(TypeName = "money")] public decimal ContractualEarnings { get; set; }
        [Column(TypeName = "money")] public decimal OvertimeEarnings { get; set; }
        [Column(TypeName = "money")] public decimal Tax { get; set; }
        [Column(TypeName = "money")] public decimal NIC { get; set; }
        [Column(TypeName = "money")] public decimal? UnionFee { get; set; }
        [Column(TypeName = "money")] public decimal? SLC { get; set; }
        [Column(TypeName = "money")] public decimal TotalEarnings { get; set; }
        [Column(TypeName = "money")] public decimal TotalDeduction { get; set; }
        [Column(TypeName = "money")] public decimal NetPayment { get; set; }


        
        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        
        public int TaxYearId { get; set; }

        [ForeignKey("TaxYearId")]
        public virtual TaxYear TaxYear { get; set; }
    }
}