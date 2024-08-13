using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_class2
{
    public class priceException : System.Exception
    {
        public priceException(string message):base(message)
        {

        }
    }
    public class TestException
    {

        public static void CheckPrice()
        {
            try
            {
                Console.WriteLine("enter price");
                var price = Convert.ToInt32(Console.ReadLine());
                if(price <= 0)
                {
                    throw new priceException("Price cannot be zero");
                }
            }

            catch (priceException ex1)
            {
                Console.WriteLine(ex1.Message);
            }
        
        }
        public static void Test()
        {
            try
            {
                Console.WriteLine("enter denominator");
                var den = Convert.ToInt32(Console.ReadLine());
                int a = 1 / den;
            }
         
            catch(ArithmeticException ex1)
            {
                Console.WriteLine("catch Arithmetic exception" + ex1.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("catch base exception" + ex.Message);
            }
        }
    }
}
