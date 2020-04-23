using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1_Cepik
{
    class CarDocsAndInfo
    {
        [Key]
        public int VinNumber { get; set; }
        public string CarCardNumber { get; set; }
        public DateTime FirstRegistrationDate { get; set; }
        public virtual Cars Car { get; set; }
    }
}
