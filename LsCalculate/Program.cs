using System;
using System.Linq;

namespace LsCalculate
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new int[] { 5, 7, 9, 8, 1, 6, 4 };
            BaseCalculator sum = new SumCalculator(numbers);
            Console.WriteLine($"The sum of all the numbers: {sum.Calculate()}");
            Console.WriteLine();
            BaseCalculator evenSum = new EvenNumbersSumCalculator(numbers);
            Console.WriteLine($"The sum of all the even numbers: {evenSum.Calculate()}");
        }
    }
    public abstract class BaseCalculator
    {
        protected readonly int[] _numbers;
        public BaseCalculator(int[] numbers)
        {
            _numbers = numbers;
        }
        public abstract int Calculate();
    }
    public class SumCalculator : BaseCalculator
    {
        public SumCalculator(int[] numbers)
            : base(numbers)
        {
        }
        public override int Calculate() => _numbers.Sum();
    }
    public class EvenNumbersSumCalculator : BaseCalculator
    {
        public EvenNumbersSumCalculator(int[] numbers)
           : base(numbers)
        {
        }
        public override int Calculate() => _numbers.Where(x => x % 2 == 0).Sum();
    }
}
