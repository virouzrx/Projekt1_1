using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt1_Cepik
{
    class Cars
    {
        [Key]
        public int CarId { get; set; }
        public string LicensePlateNumber { get; set; }
        public string CarModel { get; set; }
        public string CarCompany { get; set; }
        [ForeignKey("Driver")]
        public int DriverId { get; set; }
        public virtual Drivers Driver { get; set; }
        public virtual ICollection<TechnicalReview> TechnicalReviews { get; set; } = new List<TechnicalReview>();
        public virtual ICollection<CarDocsAndInfo> CarDocsAndInfos { get; set; } = new List<CarDocsAndInfo>();
    }
}
