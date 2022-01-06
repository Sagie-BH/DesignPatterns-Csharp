using SRP.SRP;
using System;

namespace SRP
{
    /* 
     כל מחלקה צריכה להיות אחראית על חלק בודד של הפונקציונליות המסופקת על ידי התוכנה,
     האחריות הזאת צריכה להיות מובלעת על ידי אותה מחלקה. 
     Encapsulated 
    המטרה העיקרית של עיקרון זה היא הפחתת המורכבות
    אתה לא צריך להמציא עיצוב מתוחכם לתוכנית שיש בו רק כ-200 שורות קוד
    תעשה 10 שיטות יפות, ואתה תהיה בסדר.

     */
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person
            {
                FirstName = "John",
                LastName = "Deo",
                Email = "2603sagie@gmail.com"
            };
            PersonService employeeService = new PersonService();
            employeeService.EmployeeRegistration(person);
            Console.ReadKey();
        }
    }
}

