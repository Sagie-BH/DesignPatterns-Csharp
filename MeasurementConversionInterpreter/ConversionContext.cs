using System;
using System.Text;

namespace MeasurementConversionInterpreter
{
    public class ConversionContext
    {
        private String conversionQues = "";
        private String conversionResponse = "";
        private String fromConversion = "";
        private String toConversion = "";
        private double quantity;
        String[] partsOfQues;


        public ConversionContext(String input)
        {
            this.conversionQues = input;
            partsOfQues = GetInput().Split(" ");
            fromConversion = getCapitalized(partsOfQues[1]);
            toConversion = GetLowercase(partsOfQues[3]);
            quantity = Double.Parse(partsOfQues[0]);
            conversionResponse = partsOfQues[0] + " " + partsOfQues[1] + " equals ";

        }

        public String GetInput() { return conversionQues; }
        public String GetFromConversion() { return fromConversion; }
        public String GetToConversion() { return toConversion; }
        public String getResponse() { return conversionResponse; }
        public double GetQuantity() { return quantity; }

        // Make String lowercase
        public String GetLowercase(String wordToLowercase)
        {
            return wordToLowercase.ToLower();
        }

        // Capitalizes the first letter of a word
        public String getCapitalized(String wordToCapitalize)
        {
            // Make characters lower case
            wordToCapitalize = wordToCapitalize.ToLower();

            // Make the first character uppercase
            wordToCapitalize = char.ToUpper(wordToCapitalize[0]) + wordToCapitalize.Substring(1);

            // Put s on the end if not there
            int lengthOfWord = wordToCapitalize.Length;


            if (wordToCapitalize[lengthOfWord - 1] != 's')
            {
                wordToCapitalize = new StringBuilder(wordToCapitalize).Insert(lengthOfWord, "s").ToString();
            }

            return wordToCapitalize;
        }
    }
}
