using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_class3
{
    public class EventHandling
    {
        public delegate void delAlarm();

        public event delAlarm press;

        public void raiseEvent()
        {
            press();
        }

        public static void alarm()
        {
            Console.WriteLine("ring ring");
        }
    }
}
