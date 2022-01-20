namespace MeasurementConversionInterpreter
{
    public class TableSpoon : Expression
    {

        public override string GallonsM(double quantity)
        {
            return (quantity / 256).ToString();
        }

        public override string Guartsm(double quantity)
        {
            return (quantity / 64).ToString();
        }

        public override string PintsM(double quantity)
        {
            return (quantity / 32).ToString();
        }

        public override string CupsM(double quantity)
        {
            return (quantity / 16).ToString();
        }

        public override string TablespoonsM(double quantity)
        {
            return quantity.ToString();
        }
    }
}
