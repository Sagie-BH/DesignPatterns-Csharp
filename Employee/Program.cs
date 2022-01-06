using System;
using System.Collections.Generic;
using System.Linq;

namespace Employee
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public enum Gender
    {
        Male,
        Female
    }
    public enum Position
    {
        Administrator,
        Manager,
        Executive
    }
    public class Employee
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public Position Position { get; set; }
    }
    public class EmployeeManager
    {
        private readonly List<Employee> _employees;
        public EmployeeManager()
        {
            _employees = new List<Employee>();
        }
        public void AddEmployee(Employee employee)
        {
            _employees.Add(employee);
        }
        // Using the public property from the low-level class inside the high-level class.
        // By doing so, our low-level class can’t change its way of keeping track of employees.
        public List<Employee> Employees => _employees;

    }
    // EmployeeStatistics class has a strong relation (coupled) to the EmployeeManager class and we can’t
    // send any other object in the EmployeeStatistics constructor except the EmployeeManager object.
    public class EmployeeStatistics
    {
        private readonly EmployeeManager _empManager;
        public EmployeeStatistics(EmployeeManager empManager)
        {
            _empManager = empManager;
        }
        public int CountFemaleManagers() => 
            _empManager.Employees.Count(emp => emp.Gender == Gender.Female && emp.Position == Position.Manager);

    }
}
