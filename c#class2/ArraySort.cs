using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace c_class2
{
    public class ArraySort
    {
        public static void DoSort()
        {
            string[] values = { "bb", "bbb", "a", "b", "ccc", "ab", "aaaa" };
            for (int i = 0; i < values.Length; i++)
            {
                for (int j = 0; j < values.Length - 1; j++)
                {
                    if (values[i].Length < values[j].Length)
                    {
                        var temp = values[i];
                        values[i] = values[j];
                        values[j] = temp;
                    }
                }
            }

            foreach (var i in values)
            {
                Console.WriteLine(i);
            }

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i].StartsWith("b"))
                {
                    Console.WriteLine(values[i]);
                }

            }
        }


        public static void MultiDimensional()
        {

            //sum of all elements 
            int[,] matrix =
            {
                {1,2,3 },
                {4,5,6 },
                {7,8,9 }
            };

            int sum = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sum += matrix[i, j];
                }
            }

            Console.WriteLine(sum);
        }

        public static void JaggedArray()
        {
            string[][] meetingSchedule = new string[3][]
            {
                new string[]{"1:00","2:00","5:00" },
                new string[]{ "1:00","4:00"},
                new string[]{ "1:00"}
            };

            for(int i=0;i<=meetingSchedule.Length-1;i++)
            {
                Console.WriteLine("Room " + (i + 1 )+ "schedule");
                foreach(var slot in meetingSchedule[i])
                {
                    Console.WriteLine(slot + "");
                }
            }
        }

        public static void showTuples()
        {
            var employees = (name: "John", role: "developer", phone: 123, salary: 12.345);
            var employees2 = ("John", "developer", 123,  12.345);

            Console.WriteLine("NAMED TUPLE");
            Console.WriteLine(employees.name);
            Console.WriteLine(employees.role);
            Console.WriteLine(employees.phone);
            Console.WriteLine(employees.salary);

            Console.WriteLine("UNNAMED TUPLE");
            Console.WriteLine(employees2.Item1);
            Console.WriteLine(employees2.Item2);
            Console.WriteLine(employees2.Item3);
            Console.WriteLine(employees2.Item4);
        }


    }
}

