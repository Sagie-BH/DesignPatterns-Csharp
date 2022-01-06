// See https://aka.ms/new-console-template for more information


global using System.Text.Json;

using static System.Console;

Person p1 = new Person();
p1.Age = 42;
p1.BirthDate = Convert.ToDateTime("1977-01-01");
p1.Name = "Jack Daniels";
p1.IdInfo = new IdInfo(666);

// Perform a shallow copy of p1 and assign it to p2.
Person p2 = p1.ShallowCopy();
// Make a deep copy of p1 and assign it to p3.
Person p3 = p1.DeepCopy();

// Display values of p1, p2 and p3.
WriteLine("Original values of p1, p2, p3:");
WriteLine("   p1 instance values: ");
DisplayValues(p1);
WriteLine("   p2 instance values:");
DisplayValues(p2);
WriteLine("   p3 instance values:");
DisplayValues(p3);

// Change the value of p1 properties and display the values of p1,
// p2 and p3.
p1.Age = 32;
p1.BirthDate = Convert.ToDateTime("1900-01-01");
p1.Name = "Frank";
p1.IdInfo.IdNumber = 7878;
WriteLine("\nValues of p1, p2 and p3 after changes to p1:");
WriteLine("   p1 instance values: ");
DisplayValues(p1);
WriteLine("   p2 instance values (reference values have changed):");
DisplayValues(p2);
WriteLine("   p3 instance values (everything was kept the same):");
DisplayValues(p3);
WriteLine("\n\n\n");

Person sP = SerializePerson.DeepCopySerialize(p1);
sP.Age = 999;
Console.WriteLine(sP.Age);
Console.WriteLine(p1.Age);

var emp = new Employee { FirstName = "Sagie", LastName = "Bar" };

var empTwo = emp with { LastName = "Bond" };

emp = empTwo with { FirstName = "James" };

WriteLine(emp);
WriteLine(empTwo);

WriteLine($"Equls: {Equals(emp, empTwo)}");
WriteLine($"== operator: {emp == empTwo}");

var c = new Car("Red", 2000);
(var color, var year) = c;

WriteLine("\nColor: " + color + "\tYear: " + year);





static void DisplayValues(Person p)
{
    Console.WriteLine("      Name: {0:s}, Age: {1:d}, BirthDate: {2:MM/dd/yy}",
        p.Name, p.Age, p.BirthDate);
    Console.WriteLine("      ID#: {0:d}", p.IdInfo?.IdNumber);
}


public class Person
{
    public int Age;
    public DateTime BirthDate;
    public string? Name;
    public IdInfo? IdInfo;

    public Person ShallowCopy()
    {
        return (Person)this.MemberwiseClone();
    }

    public Person DeepCopy()
    {
        Person clone = (Person)this.MemberwiseClone();
        clone.IdInfo = new IdInfo(IdInfo.IdNumber);
        clone.Name = new string(Name);
        return clone;
    }
}
static class SerializePerson
{
    public static T DeepCopySerialize<T>(this T self)
    {
        string jsonString = JsonSerializer.Serialize(self);
        return JsonSerializer.Deserialize<T>(jsonString);
    }
}

public class IdInfo
{
    public int IdNumber;

    public IdInfo(int idNumber)
    {
        this.IdNumber = idNumber;
    }
}

record Employee
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public void WriteToFConsole()
        => WriteLine(this);
}

record struct Car(string Color, int Year);



