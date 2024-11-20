using System;
using System.Collections.Generic;

namespace Patterns.Adapter
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public Employee(int id, string name, decimal salary)
        {
            ID = id;
            Name = name;
            Salary = salary;
        }
    }

    public class ThirdPartyBillingSystem
    {
        public void ProcessSalary(List<Employee> listEmployee)
        {
            foreach (Employee employee in listEmployee)
            {
                Console.WriteLine(employee.Salary + " Salary Credited to " + employee.Name + " Account");
            }
        }
    }

    public interface ITarget
    {
        void ProcessCompanySalary(string[,] employeesArray);
    }

    public class EmployeeAdapter : ITarget
    {
        ThirdPartyBillingSystem thirdPartyBillingSystem = new ThirdPartyBillingSystem();
        public void ProcessCompanySalary(string[,] employeesArray)
        {
            string? Id = null;
            string? Name = null;
            string? Salary = null;
            List<Employee> listEmployee = new List<Employee>();
            for (int i = 0; i < employeesArray.GetLength(0); i++)
            {
                for (int j = 0; j < employeesArray.GetLength(1); j++)
                {
                    if (j == 0)
                    {
                        Id = employeesArray[i, j];
                    }
                    else if (j == 1)
                    {
                        Name = employeesArray[i, j];
                    }
                    else
                    {
                        Salary = employeesArray[i, j];
                    }
                }
                listEmployee.Add(new Employee(Convert.ToInt32(Id), Name, Convert.ToDecimal(Salary)));
            }
            thirdPartyBillingSystem.ProcessSalary(listEmployee);
        }
    }

    class Program
    {
        //static void Main(string[] args)
        //{
        //    string[,] employeesArray = new string[5, 3]
        //    {
        //        {"101","John","10000"},
        //        {"102","Alex","20000"},
        //        {"103","David","30000"},
        //        {"104","Max","40000"},
        //        {"105","Robert","50000"}
        //    };
        //    ITarget target = new EmployeeAdapter();
        //    target.ProcessCompanySalary(employeesArray);
        //    Console.Read();
        //}
    }
}