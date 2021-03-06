using System;

namespace BadBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
			new CarBuilder()
				.setMake("lada")
				.setColour("red")
				.setManifactureDate("01/01/1980")
				.Build();

			// Same thing as if we create a constractor and give it arguments 
        }
    }
	public class Car
	{
		public string Make { get; set; }
		public string Colour { get; set; }
		public string ManifactureDate { get; set; }

	}

	public class CarBuilder
	{
		private Car _car = new Car();

		public CarBuilder setMake(string make)
		{
			_car.Make = make;
			return this;
		}

		public CarBuilder setColour(string colour)
		{
			_car.Colour = colour;
			return this;
		}

		public CarBuilder setManifactureDate(string date)
		{
			_car.ManifactureDate = date;
			return this;
		}

		public Car Build() => _car;
	}
}
