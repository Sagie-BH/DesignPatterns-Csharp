using System;

namespace NullPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    //public class Customer
    //{
    //    private int OrderCount;
    //    private string TotalSales;
    //    public static Customer NotFound =
    //       new Customer() { OrderCount = 0, TotalSales = "0m" };
    //    // other properties and behavior
    //    public Customer GetByPhoneNumber(string phoneNumber)
    //    {
    //        return _customerRepository
    //               .List(c => c.PhoneNumber == phoneNumber)
    //               .FirstOrDefault();
    //    }
    //    var customer = GetByPhoneNumber(phone);

    //    int orderCount = customer != null ? customer.OrderCount : 0;
    //    decimal totalPurchase = customer != null ? customer.TotalPurchase : 0m;
    //}
}
