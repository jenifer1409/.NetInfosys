

using c_class3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_class3
{
    public class DatabaseFirst
    {
        public static void CancelBooking()
        {
            using (var context = new VehicleBookingContext())
            {
                Guid id = new Guid("F791B7C8-5D7C-4E7A-AF64-22A0C4975E24");
                var bookingId = context.Checkdbfirsts.FirstOrDefault(b => b.Id == id);
                context.Checkdbfirsts.Remove(bookingId);
                context.SaveChanges();
            }



        }
        public static void RescheduleBooking()
        {
            using (var context = new VehicleBookingContext())
            {
                Guid id = new Guid("BFE566FA-8D51-4435-8788-6D98C42C4FA2");
                var bookingId = context.Checkdbfirsts.FirstOrDefault(b => b.Id == id);
                if (bookingId != null)
                {
                    bookingId.Vehiclestatus = "running";
                    bookingId.Charges = 100;
                }
                context.Checkdbfirsts.Update(bookingId);
                context.SaveChanges();
            }
        }
    }
}

