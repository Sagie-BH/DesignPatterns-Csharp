using System;

namespace ProductFactory
{
    /*
     דפוס עיצוב יצירתי המספק ממשק ליצירת אובייקטים ב-superclass אבל מאפשר לתת מחלקות לשנות את סוג האובייקטים.

    הוספת מחלקה חדשה לתוכנית היא לא כל כך פשוטה אם שאר הקוד כבר מוצמד למחלקות הקיימות.
    יצירת האובייקטים מפוזרת ברחבי הקוד ולפעמים לא נרצה שהצרכן יהיה מודע לכל סוגי האובייקטים.

    תבנית העיצוב משמשת להחלפת בוני המחלקות והפשטת תהליך יצירת האובייקטים
    כך שגם נוכל לקבוע את סוג האובייקט הנוצר בזמן הריצה.

    כדי להשיג זאת ה Factory משתמשת בתבנית שכוללת 4 מרכיבים עיקריים.
    המוצר - Product
    ממשק זה מגדיר את המוצר שהמפעל ייצר.
    מוצר קונקרטי - Concrete Product 
    מחלקה שמיישמת את ממשק המוצר.
    יוצר - Creator
    מחלקה אבסטרקטית שמגדירה את פונקציות המפעל.
    לא ממשק בכדי לאפשר לנו להשתמש בנתונים לטובת תנאים או דיפולטיבים וגם בכדי לאפשר פונקציה לאובייקט דיפולטיבי. 
    יוצר קונקרטי - Concrete Creator 
    מחלקה אשר מיישמת את מחלקת ה"יוצר" ועוקפת overrides את פונקציית המפעל כדי להחזיר אובייקט קונקרטי


     */
    class Program
    {
        static void Main(string[] args)
        {
            // An array of creators
            Creator[] creators = new Creator[2];
            creators[0] = new ConcreteCreatorA();
            creators[1] = new ConcreteCreatorB();
            // Iterate over creators and create products
            foreach (Creator creator in creators)
            {
                Product product = creator.FactoryMethod();
                Console.WriteLine("Created {0}",
                  product.GetType().Name);
            }
            // Wait for user
            Console.ReadKey();
        }
    }
    /// <summary>
    /// The 'Product' abstract class
    /// </summary>
    abstract class Product
    {
    }
    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class ConcreteProductA : Product
    {
    }
    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class ConcreteProductB : Product
    {
    }
    /// <summary>
    /// The 'Creator' abstract class
    /// </summary>
    abstract class Creator
    {
        public abstract Product FactoryMethod();
    }
    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    class ConcreteCreatorA : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductA();
        }
    }
    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    class ConcreteCreatorB : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductB();
        }
    }
}
