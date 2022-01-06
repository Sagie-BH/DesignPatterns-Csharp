using System;

namespace InnerFactory
{
    public class Term
    {
        //Properties
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        //Static factory methods
        public static Term CreateNewBetweenDefaultDates()
            => new Term(new DateTime(2000, 1, 1), DateTime.UtcNow);

        public static Term CreateNewBetweenDates(DateTime startDate, DateTime endDate)
            => new Term(startDate, endDate);

        //Private constructor
        private Term(DateTime startDate, DateTime endDate)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
        }
    }
}
