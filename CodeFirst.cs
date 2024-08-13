using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_class3
{
    public class CodeFirst
    {
        public static void insertCustomerDetails()
        {
            using (var context = new BookingContext())
            {
                var booking = new VehicleCustomerDetails
                {
                    //BookingId = 1,
                    CustomerName = "John",
                    PhoneNumber = "12345",
                    Charges = 123
                };
                context.Add(booking);
                context.SaveChanges();
                
            }
        }

        public static void getCustomerDetails()
        {
            using (var context = new BookingContext())
            {
                var cusDetails = context.VehicleCustomerDetails.FirstOrDefault(b => b.BookingId == 1);
                Console.WriteLine(cusDetails.CustomerName);
                Console.WriteLine(cusDetails.Charges);
            }
        }
    }
}
