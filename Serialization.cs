using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_class3
{
    public class Employee
    {
        [JsonProperty("empId")]
        public int EmpId { get; set; }

        [JsonProperty("empName")]
        public string EmpName { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }

        [JsonProperty("salary")]
        public decimal Salary { get; set; }

    }
    public class Serialization
    {
        public static List<Employee> GetEmployeeDetails()
        {
            List<Employee> emp = new List<Employee>()
            {
                new Employee {EmpId=101,EmpName="Ron",Position="HR",Salary=7500.65M},
                new Employee {EmpId=102,EmpName="John",Position="Analyst",Salary=6500.65M},
                new Employee {EmpId=103,EmpName="Amy",Position="SE",Salary=4500.65M},

            };
            return emp;
        }

        public static void serializeEmployee()
        {
            var employee = Serialization.GetEmployeeDetails();

            string jsonString = JsonConvert.SerializeObject(employee);

            Console.WriteLine(jsonString);

            List<Employee> result = JsonConvert.DeserializeObject<List<Employee>>(jsonString);

            foreach(var item in result)
            {
                Console.WriteLine(item.EmpId);
                Console.WriteLine(item.EmpName); 
                Console.WriteLine(item.Salary);
                Console.WriteLine(item.Position); ;
            }

        }

       

    }
}
