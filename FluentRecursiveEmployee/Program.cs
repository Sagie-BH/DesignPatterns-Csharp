using System;

namespace FluentProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            var employee = new EmployeeInfoBuilder();
            //employee.SetName("James").AtPosition();
        }
    }
    public class Employee
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
        public override string ToString()
        {
            return $"Name: {Name}, Position: {Position}, Salary: {Salary}";
        }
    }
    public class EmployeeInfoBuilder
    {
        protected Employee employee = new Employee();
        public EmployeeInfoBuilder SetName(string name)
        {
            employee.Name = name;
            return this;
        }
    }
    public class EmployeePositionBuilder : EmployeeInfoBuilder
    {
        public EmployeePositionBuilder AtPosition(string position)
        {
            employee.Position = position;
            return this;
        }
    }
}
