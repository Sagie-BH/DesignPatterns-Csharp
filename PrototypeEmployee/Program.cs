using System;

namespace PrototypeEmployee
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp1 = new Employee();
            emp1.Name = "Anurag";
            emp1.Department = "IT";
            Employee emp2 = emp1.GetClone();
            emp2.Name = "Pranaya";

            Console.WriteLine("Emplpyee 1: ");
            Console.WriteLine("Name: " + emp1.Name + ", Department: " + emp1.Department);
            Console.WriteLine("Emplpyee 2: ");
            Console.WriteLine("Name: " + emp2.Name + ", Department: " + emp2.Department);
            Console.Read();

        }
    }
    public class Employee
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public Employee GetClone()
        {
            return (Employee)this.MemberwiseClone();
        }
    }
    /*
    The MemberwiseClone method is part of the System.Object class and creates a shallow copy of the given object. 
    MemberwiseClone Method only copies the non-static fields of the object to the new object
    In the process of copying, if a field is a value type, a bit by bit copy of the field is performed.
    If a field is a reference type, the reference is copied but the referenced object is not.
     */
}
