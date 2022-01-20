using System;
using System.Collections.Generic;

namespace DateTimeInterpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<AbstractExpression> objExpressions = new List<AbstractExpression>();
            Context context = new Context(DateTime.Now);
            Console.WriteLine("Please select the Expression  : MM DD YYYY or YYYY MM DD or DD MM YYYY ");
            context.expression = Console.ReadLine();
            string[] strArray = context.expression.Split(' ');
            foreach (var item in strArray)
            {
                if (item == "DD")
                {
                    objExpressions.Add(new DayExpression());
                }
                else if (item == "MM")
                {
                    objExpressions.Add(new MonthExpression());
                }
                else if (item == "YYYY")
                {
                    objExpressions.Add(new YearExpression());
                }
            }
            objExpressions.Add(new SeparatorExpression());
            foreach (var obj in objExpressions)
            {
                obj.Evaluate(context);
            }
            Console.WriteLine(context.expression);
            Console.Read();
        }
    }
    
    /*
    Create a class file with the name Context.cs and then copy and paste the following code in it.
    This class contains the date (i.e. current date-time) that we want to interpret.
    */
    public class Context
    {
        public string expression { get; set; }
        public DateTime date { get; set; }
        public Context(DateTime date)
        {
            this.date = date;
        }
    }
    /*
    Create an interface with the name AbstractExpression and then copy and paste the following code in it.
    This class defines the method that is going to be implemented by the child classes.
    Moreover, the method takes the Context object as a parameter.
    This context object holds the value that we want to interpret.
     */
    public interface AbstractExpression
    {
        void Evaluate(Context context);
    }
    /*
    Create a class file with the name DayExpression and then copy and paste the following code.
    The evaluate method replaces the expression DD value with the exact Day value
    that is stored in the context object.
     */
    public class DayExpression : AbstractExpression
    {
        public void Evaluate(Context context)
        {
            string expression = context.expression;
            context.expression = expression.Replace("DD", context.date.Day.ToString());
        }
    }
    /*
     Create a class file with the name MonthExpression and then copy and paste the following code.
    The evaluate method replaces the expression MM value with the exact 
    Month value that is stored in the context object.
     */
    public class MonthExpression : AbstractExpression
    {
        public void Evaluate(Context context)
        {
            string expression = context.expression;
            context.expression = expression.Replace("MM", context.date.Month.ToString());
        }
    }
    /*
    Create a class file with the name YearExpression and then copy and paste the following code.
    The evaluate method replaces the expression YYYY value with the exact
    Year value that is stored in the context object.
     */
    public class YearExpression : AbstractExpression
    {
        public void Evaluate(Context context)
        {
            string expression = context.expression;
            context.expression = expression.Replace("YYYY", context.date.Year.ToString());
        }
    }
    /*
     Create a class file with the name YearExpression and then copy and paste the following code.
    The Evaluate method simply replace the space with a hyphen (-) separator.
     */
    class SeparatorExpression : AbstractExpression
    {
        public void Evaluate(Context context)
        {
            string expression = context.expression;
            context.expression = expression.Replace(" ", "-").Replace("&", "-").Replace("  ", "-");
        }
    }
}
