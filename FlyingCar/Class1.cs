using System;

namespace FlyingCar
{
    /*
     אין להכריח לקוחות להיות תלויים בשיטות שהם לא צריכים להשתמש.
     נסו להפוך את הממשקים לצרים מספיק כדי שהצרכן של הקוד לא יצטרך ליישם התנהגויות שהוא לא צריך.
     על פי עקרון הפרדת הממשק, אנחנו צריכים לפרק ממשקים גדולים ליחידות יותר גרעיניות וספציפיות.
     הצרכן של הקוד צריך ליישם רק את השיטות שהוא באמת צריך.
     אחרת כל שינוי לממשק ישבור את קוד הצרכן בשיטות שאינו משתמש.
     אין צורך לדחוס טונות של שיטות לא קשורות לממשק אחד,
    הורשה לא מגבילה את מספר הממשקים שמחלקה יכול ליישם באותו זמן.
     */
    public class Class1
    {
    }
    public interface IVehicle
    {
        void Drive();
        void Fly();
    }
    public class MultiFunctionalCar : IVehicle
    {
        public void Drive()
        {
            //actions to start driving car
            Console.WriteLine("Drive a multifunctional car");
        }
        public void Fly()
        {
            //actions to start flying
            Console.WriteLine("Fly a multifunctional car");
        }
    }
    public class Car : IVehicle
    {
        public void Drive()
        {
            //actions to drive a car
            Console.WriteLine("Driving a car");
        }
        public void Fly()
        {
            throw new NotImplementedException();
        }
    }
    public class Airplane : IVehicle
    {
        public void Drive()
        {
            throw new NotImplementedException();
        }
        public void Fly()
        {
            //actions to fly a plane
            Console.WriteLine("Flying a plane");
        }
    }
}
