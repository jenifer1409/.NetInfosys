using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_class3
{
    //create a delegate
    public delegate void myVehicle();
    public class VehicleDelegate
    {
        


        public static void getVehicleDetails()
        {
            Console.WriteLine("FORD - MX123 ");
        }

        public static void getTruckDetails()
        {
            Console.WriteLine("Truck1 - xyz1243");
        }

        public static void anonymous()
        {
            Action<string> greet = delegate (string message)
            {
                Console.WriteLine("Hello" + message);
            };

            greet("Jeni");
        }

        public static void sortByLambda()
        {
            string[] a = { "aaa", "bb", "a", "cccc" };

            var sortedArray = a.OrderBy(a => a.Length);

            foreach(var i in sortedArray)
            {
                Console.WriteLine(i);
            }
        }

    }
}
