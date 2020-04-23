using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1_Cepik
{
    class Drivers
    {
        [Key]
        public int DriverId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Region { get; set; }
        public int PESEL { get; set; }
        public virtual ICollection<Cars> Cars { get; set; } = new List<Cars>();
        public virtual ICollection<DrivingLicense> DrivingLicenses { get; set; } = new List<DrivingLicense>();
    }
}
