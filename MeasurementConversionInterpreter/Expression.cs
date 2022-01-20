using System;

namespace MeasurementConversionInterpreter
{
    public abstract class Expression
    {
        public abstract string GallonsM(double quantity); 
        public abstract string Guartsm(double quantity);
        public abstract string PintsM(double quantity);
        public abstract string CupsM(double quantity);
        public abstract string TablespoonsM(double quantity); 
    }
}
