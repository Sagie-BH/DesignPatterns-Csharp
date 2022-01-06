using System;

namespace NoLsFruits
{
    class Program
    {
        // Once the child object is replaced, Apple storing the Orange object, the behavior is also changed.
        //The Liskov Substitution Principle in C# states that even the child object is replaced with the parent,
        //the behavior should not be changed. So, in this case, if we are getting the color of Apple instead of Orange,
        //then it follows the Liskov Substitution Principle
        static void Main(string[] args)
        {
            Apple apple = new Orange();
            Console.WriteLine(apple.GetColor());
        }
    }
    public class Apple
    {
        public virtual string GetColor()
        {
            return "Red";
        }

    }
    public class Orange : Apple
    {
        //*****סוגי פרמטרים בפונקציה של תת-מחלקה צריכים להתאים או להיות מופשטים יותר מסוגי הפרמטרים בפונקציה של מחלקת העל*****//
        //*****סוג ההחזרה בפונקציה של ​​תת מחלקה צריך להתאים או להיות תת-סוג של סוג החזרה בשיטה של ​​מחלקת העל*****//
        //*****פונקציה בתת מחלקה לא צריכה לזרוק אקספשנים ששיטת הבסיס לא צפויה לזרוק*****//
        public override string GetColor()
        {
            return "Orange";
        }
    }
}
