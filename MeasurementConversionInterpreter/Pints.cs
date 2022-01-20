namespace MeasurementConversionInterpreter
{
    public class Pints : Expression
    { 

        public override string GallonsM(double quantity)
        {
            return (quantity / 8).ToString();
        }

        public override string Guartsm(double quantity)
        {
            return (quantity / 2).ToString();
        }

        public override string PintsM(double quantity)
        {
            return quantity.ToString();
        }

        public override string CupsM(double quantity)
        {
            return (quantity * 2).ToString();
        }

        public override string TablespoonsM(double quantity)
        {
            return (quantity * 32).ToString();
        }
    }
}
