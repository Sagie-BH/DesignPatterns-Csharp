using System;
using System.Collections.Generic;
using System.Linq;

namespace DIEmployee
{
    class Program
    {
        static void Main(string[] args)
        {
            var empManager = new EmployeeManager();
            empManager.AddEmployee(new Employee { Name = "Leen", Gender = Gender.Female, Position = Position.Manager });
            empManager.AddEmployee(new Employee { Name = "Mike", Gender = Gender.Male, Position = Position.Administrator });
            var stats = new EmployeeStatistics(empManager);
            Console.WriteLine($"Number of female managers in our company is: {stats.CountFemaleManagers()}");
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
    public interface IEmployeeSearchable
    {
        IEnumerable<Employee> GetEmployeesByGenderAndPosition(Gender gender, Position position);
    }

    public class EmployeeManager : IEmployeeSearchable
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
        public IEnumerable<Employee> GetEmployeesByGenderAndPosition(Gender gender, Position position)
            => _employees.Where(emp => emp.Gender == gender && emp.Position == position);
    }

    // Now, our EmployeeStatistics class is not dependent on the lower-level class and the EmployeeManager class
    // can change its behavior about storing employees as well.
    public class EmployeeStatistics
    {
        private readonly IEmployeeSearchable _emp;
        public EmployeeStatistics(IEmployeeSearchable emp)
        {
            _emp = emp;
        }
        public int CountFemaleManagers() =>
        _emp.GetEmployeesByGenderAndPosition(Gender.Female, Position.Manager).Count();
    }
}
