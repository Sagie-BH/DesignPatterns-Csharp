using System;

namespace MeasurementConversionInterpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            string questionAsked = "";
            ConversionContext question = new ConversionContext(questionAsked);


            String fromConversion = question.GetFromConversion();

            String toConversion = question.GetToConversion();

            double quantity = question.GetQuantity();

            try
            {
            // Get class based on the from conversion string
            var tempClass = typeof(fromConversion);

            // Get the constructor dynamically for the conversion string




            Constructor con = tempClass.getConstructor();
                35


36
            // Create a new instance of the object you want to convert from
37


38
            Object convertFrom = (Expression)con.newInstance();
                39


40
            // Define the method parameters expected by the method that
41
            // will convert to your chosen unit of measure
42


43
            Class[] methodParams = new Class[] { Double.TYPE };
                44


45
            // Get the method dynamically that will be needed to convert
46
            // into your chosen unit of measure
47


48
            Method conversionMethod = tempClass.getMethod(toConversion, methodParams);
                49


50
            // Define the method parameters that will be passed to the above method
51


52
            Object[] params = new Object[] { new Double(quantity) };
                53


54
            // Get the quantity after the conversion
55


56
            String toQuantity = (String)conversionMethod.invoke(convertFrom, params);
                57


58
            // Print the results
59


60
            String answerToQues = question.getResponse() +
61
                    toQuantity + " " + toConversion;
                62


63
            JOptionPane.showMessageDialog(null, answerToQues);
                64


65
            // Closes the frame after OK is clicked
66


67
            frame.dispose();
                68


69
        }
            catch (ClassNotFoundException e)
            {
                70
              // TODO Auto-generated catch block
71
              e.printStackTrace();
                72
          }
            catch (NoSuchMethodException e)
            {
                73
              // TODO Auto-generated catch block
74
              e.printStackTrace();
                75
          }
            catch (SecurityException e)
            {
                76
              // TODO Auto-generated catch block
77
              e.printStackTrace();
                78
          }
            catch (InstantiationException e)
            {
                79
              // TODO Auto-generated catch block
80
              e.printStackTrace();
                81
          }
            catch (IllegalAccessException e)
            {
                82
              // TODO Auto-generated catch block
83
              e.printStackTrace();
                84
          }
            catch (IllegalArgumentException e)
            {
                85
              // TODO Auto-generated catch block
86
              e.printStackTrace();
                87
          }
            catch (InvocationTargetException e)
            {
                88
              // TODO Auto-generated catch block
89
              e.printStackTrace();
                90
          }
            91


92
    }
    }
}
}
