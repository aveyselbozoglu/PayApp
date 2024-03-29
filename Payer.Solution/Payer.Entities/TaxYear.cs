﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payer.Entities
{
    public class TaxYear
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string YearOfTax { get; set; }


        public virtual List<PaymentRecord> PaymentRecords { get; set; }

        public TaxYear()
        {
            PaymentRecords = new List<PaymentRecord>();
        }

       
    }
}
