// See https://aka.ms/new-console-template for more information




var person = new Person
{
    LastName = "Hunter"
};

Console.WriteLine(person);

class Person
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public void WriteToFile(string filePath)
    => File.WriteAllText(filePath, ToString());
}