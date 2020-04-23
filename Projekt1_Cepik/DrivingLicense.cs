﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1_Cepik
{
    class DrivingLicense
    {
        [Key]
        public string DrivingLicenseNumber { get; set; }
        public string DrivingLicenseCategory { get; set; }
        public string DrivingLicenseStatus { get; set; }
        public DateTime DrivingLicenseIssueDate { get; set; }
        public DateTime DrivingLicenseExpiryDate { get; set; }
        public DateTime DrivingLicenseRemovalDate { get; set; }
        public virtual Drivers Driver { get; set; }
    }
}
