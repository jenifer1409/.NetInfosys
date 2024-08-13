using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_class3
{
    public class VehicleCustomerDetails
    {
        [Key]
        public int BookingId { get; set; }

        [Required(ErrorMessage ="Customer Name is Required")]
        public string CustomerName { get; set; }

        [Phone(ErrorMessage ="Phone Number Invalid")]
        public string PhoneNumber { get; set; }

        [Range (100,1000,ErrorMessage ="Minimum charges is 100")]
        public int Charges { get; set; }

    }
}
