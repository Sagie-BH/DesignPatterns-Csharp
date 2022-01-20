using System;

namespace RecursiveGenericsFluent
{
    class Program
    {
        static void Main(string[] args)
        {
            var emp = EmployeeBuilderDirector.NewEmployee
                        .SetName("Maks")
                        .AtPosition("Software Developer")
                        .WithSalary(3500)
                        .Build();
            Console.WriteLine(emp);

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

    public static class Ex
    {
        public static Employee GetSteamSomtimes(this Employee employee)
        {
            // Do somthing
            return employee;
        }
    }

    public abstract class EmployeeBuilder
    {
        protected Employee employee;
        public EmployeeBuilder()
        {
            employee = new Employee();
        }
        public Employee Build() => employee;
    }
    public class EmployeeInfoBuilder<T> : EmployeeBuilder where T : EmployeeInfoBuilder<T>
    {
        public T SetName(string name)
        {
            employee.Name = name;
            return (T)this;
        }
    }
    public class EmployeePositionBuilder<T> : EmployeeInfoBuilder<EmployeePositionBuilder<T>> where T : EmployeePositionBuilder<T>
    {
        public T AtPosition(string position)
        {
            employee.Position = position;
            return (T)this;
        }
    }
    public class EmployeeSalaryBuilder<T> : EmployeePositionBuilder<EmployeeSalaryBuilder<T>> where T : EmployeeSalaryBuilder<T>
    {
        public T WithSalary(double salary)
        {
            employee.Salary = salary;
            return (T)this;
        }
    }

    public class EmployeeBuilderDirector : EmployeeSalaryBuilder<EmployeeBuilderDirector>
    {
        public static EmployeeBuilderDirector NewEmployee => new EmployeeBuilderDirector();
    }
}
