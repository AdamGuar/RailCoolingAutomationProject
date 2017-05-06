using Optimalization.Configuration;
using Optimalization.FileUtils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimalization
{
    enum Fraction
    {
        austenite,
        pearlite,
        martensite,
        ferrite,
    }

    class TransEUtils
    {
        //TODO: move this method to genral fileUtils
        public static string readFile(string fileName)
        {
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(fileName))
                {
                    // Read the stream to a string, and write the string to the console.
                    String line = sr.ReadToEnd();
                    return line;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                return null;
            }
        }



        public static string findFraction(Fraction fraction,string fileName)
        {
            String source = readFile(fileName);
            string[] lines = source.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            string fractionString = null;

            if (fraction.Equals(Fraction.austenite))
            {

                foreach (string s in lines)
                {
                    if (s.Contains("volume fraction of retained austenite")) fractionString = s;
                }

            }
            else
            {
                foreach (string s in lines)
                {
                    if (s.Contains("volume fraction of "+fraction.ToString())) fractionString = s;
                }
            }

            if (fractionString!= null)
            {
              string[] fractionLines = fractionString.Split(null);
                fractionString = fractionLines[fractionLines.Length-1];
            }

            return fractionString;
        }


        public static double findFractionDouble(Fraction fraction,string fileName)
        {
            double result = 0;

            String austeniteString = findFraction(fraction,fileName);

            if (austeniteString != null)
            {
                result = FractionToDouble(austeniteString);
            }

            return result;
        }


        private static double FractionToDouble(string fraction)
        {
            double result;

            if (double.TryParse(fraction, out result))
            {
                return result;
            }

            string[] split = fraction.Split(new char[] { ',', '.' });

            if (split.Length == 2)
            {
                double a = Double.Parse(split[0]);
                double b = Double.Parse(split[1]);
                if (b != 0)
                    return a + (b / 1000);
                else
                    return a;
            }

            throw new FormatException("Not a valid fraction.");
        }

        public static void createTransDat(string output)
        {
            Logger.Logger.logLine("Creating TRANSE dat file", true);
            string content = Constants.TRANS_DAT_HEADER + output;
            System.IO.File.WriteAllText(ConfigurationStorage.CONFIGURATION.TransEDirectory+"trans.dat", content);
            Logger.Logger.logLine("Creating TRANSE dat file is DONE", true);
        }


    }
}
