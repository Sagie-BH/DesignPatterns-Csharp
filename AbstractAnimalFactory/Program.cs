using System;

namespace AbstractAnimalFactory
{
    class Program
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        public static void Main()
        {
            // Create and run the African animal world
            ContinentFactory africa = new AfricaFactory();
            AnimalWorld world = new AnimalWorld(africa);
            world.RunFoodChain();
            // Create and run the American animal world
            ContinentFactory america = new AmericaFactory();
            world = new AnimalWorld(america);
            world.RunFoodChain();
            // Wait for user input
            Console.ReadKey();
        }
    }
    /// <summary>
    /// מפעל אבסטרקטי - Abstract Factory -  מצהיר על ממשק לפעולות היוצרות מוצרים מופשטים.
    /// </summary>
    abstract class ContinentFactory
    {
        public abstract Herbivore CreateHerbivore();
        public abstract Carnivore CreateCarnivore();
    }
    /// <summary>
    /// מפעל קונקרטי - Concrete Factory - מיישם את הפעולות ליצירת אובייקטים קונקרטים.
    /// </summary>
    class AfricaFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new Wildebeest();
        }
        public override Carnivore CreateCarnivore()
        {
            return new Lion();
        }
    }
    /// <summary>
    /// מפעל קונקרטי 2 - Concrete Factory - מיישם את הפעולות ליצירת אובייקטים קונקרטים.
    /// </summary>
    class AmericaFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new Bison();
        }
        public override Carnivore CreateCarnivore()
        {
            return new Wolf();
        }
    }
    /// <summary>
    /// מוצר אבסטרקטי 1  -  Abstract Product - מכריז על ממשק לסוג של אובייקט מוצר.
    /// </summary>
    abstract class Herbivore
    {
    }
    /// <summary>
    /// מוצר אבסטרקטי 2
    /// </summary>
    abstract class Carnivore
    {
        public abstract void Eat(Herbivore h);
    }
    /// <summary>
    /// מוצר 1 - Product - מגדיר אובייקט מוצר שייווצר על ידי מפעל קונקרטי המתאים המיישם את המפעל האבסטרקטי.
    /// </summary>
    class Wildebeest : Herbivore
    {
    }
    /// <summary>
    /// מוצר 2 - Product - מגדיר אובייקט מוצר שייווצר על ידי מפעל קונקרטי המתאים המיישם את המפעל האבסטרקטי.
    /// </summary>
    class Lion : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            // Eat Wildebeest
            Console.WriteLine(this.GetType().Name +
              " eats " + h.GetType().Name);
        }
    }
    /// <summary>
    /// מוצר 1 - Product - מגדיר אובייקט מוצר שייווצר על ידי מפעל קונקרטי המתאים המיישם את המפעל האבסטרקטי.
    /// </summary>
    class Bison : Herbivore
    {
    }
    /// <summary>
    /// מוצר 2 - Product - מגדיר אובייקט מוצר שייווצר על ידי מפעל קונקרטי המתאים המיישם את המפעל האבסטרקטי.
    /// </summary>
    class Wolf : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            // Eat Bison
            Console.WriteLine(this.GetType().Name +
              " eats " + h.GetType().Name);
        }
    }
    /// <summary>
    /// לקוח - Client - משתמש בממשקים שהוכרזו על ידי מחלקות המפעל המופשט Abstract Factory ומחלקת המוצר האבסטרקטית Abstract Product 
    /// </summary>
    class AnimalWorld
    {
        private Herbivore _herbivore;
        private Carnivore _carnivore;
        // Constructor
        public AnimalWorld(ContinentFactory factory)
        {
            _carnivore = factory.CreateCarnivore();
            _herbivore = factory.CreateHerbivore();
        }
        public void RunFoodChain()
        {
            _carnivore.Eat(_herbivore);
        }
    }
}
