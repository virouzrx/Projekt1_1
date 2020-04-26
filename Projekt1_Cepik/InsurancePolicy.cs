﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1_Cepik
{
    class InsurancePolicy
    {
        [Key]
        public int InsuranceId { get; set; }
        public DateTime PolicyStartDay { get; set; }
        public DateTime PolicyExpiryDate { get; set; } 
        public int CarId { get; set; }
        public virtual Cars Car { get; set; }

    }
}
