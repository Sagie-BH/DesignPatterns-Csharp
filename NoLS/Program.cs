using System;
using System.Linq;

namespace NoLS
{
    class Program
    {
        /*
         כאשר אנחנו מרחיבים מחלקה, עלינו לזכור שאנחנו צריכים להיות מסוגלים
         להעביר אובייקטים של התת-מחלקה במקום אובייקטים של מחלקת האב מבלי לשבור את קוד הלקוח.
         המשמעות היא שתת המחלקה צריכה להישאר תואמת להתנהגות של מחלקת האב \ סופר קלאס.
         כאשר אנחנו עושים אוברייד לפונקציה, עלינו להרחיב את ההתנהגות הבסיסית המקום להחליף אותה במשהו אחר לגמרי.

        עקרון ההחלפה הוא קבוצה של בדיקות שעוזרות לחזות האם תת מחלקה נשארת תואמת לקוד
        שהיה מסוגל לעבוד עם אובייקטים של מחלקת האב \ מחלקת העל ולא להשפיע על התוצאות המצופות.
        העיקרון הזה הוא קריטי בעת פיתוח ספריות או פריימוורקס מכיוון שהמחלקות שלנו
        ישמשו אנשים אחרים שאנחנו לא יכולים לגשת ישירות או לשנות את הקוד שלהם.
        בניגוד לעקרונות עיצוב אחרים הפתוחים לפירוש, לעקרון ההחלפה יש מערכת פורמלית למחלקות ובמיוחד לפונקציות.
         */
        static void Main(string[] args)
        {
            var numbers = new int[] { 5, 7, 9, 8, 1, 6, 4 };
            SumCalculator sum = new SumCalculator(numbers);
            Console.WriteLine($"The sum of all the numbers: {sum.Calculate()}");
            Console.WriteLine();
            EvenNumbersSumCalculator evenSum = new EvenNumbersSumCalculator(numbers);
            Console.WriteLine($"The sum of all the even numbers: {evenSum.Calculate()}");


            //evenSum is of type SumCalculator which is a higher order class (a base class).
            //This means that the Count method from the SumCalculator will be executed.
            SumCalculator evenSum2 = new EvenNumbersSumCalculator(numbers);
            Console.WriteLine($"\nThe sum of all the even numbers: {evenSum2.Calculate()}");

            Console.WriteLine($"\nThe sum of all the even numbers with override: {evenSum2.Calculate2()}");
        }
    }
    public class SumCalculator
    {
        protected readonly int[] _numbers;
        public SumCalculator(int[] numbers)
        {
            _numbers = numbers;
        }
        public int Calculate() => _numbers.Sum();
        public virtual int Calculate2() => _numbers.Sum();

    }
    public class EvenNumbersSumCalculator : SumCalculator
    {
        public EvenNumbersSumCalculator(int[] numbers)
            : base(numbers)
        {
        }
        public new int Calculate() => _numbers.Where(x => x % 2 == 0).Sum();

        public override int Calculate2() => _numbers.Where(x => x % 2 == 0).Sum();

    }

}
