using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimalization
{
    class AbaqusUtils
    {
        private static string readFile(string fileName)
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

        private static string[] splitData(String data)
        {

            string[] portions = data.Split(new string[] { "                                INCREMENT" }, StringSplitOptions.None);

            return portions;
        }

        private static string prepareCSV(string[] portions)
        { 
            string result = "";
            foreach (string entity in portions)
            {
                string[] lines = entity.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                //fetching time value from step
                string timeLine = lines[4];
                string[] temp = timeLine.Split(new string[] { ","}, StringSplitOptions.None);
                temp = temp[1].Split(null);
                string time;
                if (temp[12] != "") time = temp[12];
                else time = temp[13];
                //end of fetching time
                //fetching temperature from step
                string temperatureLine = lines[21];
                temp = temperatureLine.Split(null);
                string temperature=temp[11];



                result = result + time + ","+temperature+"\n";
            }

            return result;
        }

       

        public static string parseDataFromAbaqToCSV(string fileName)
        {
            Logger.Logger.logLine("Parsing Data from abaqus DatFile: " + fileName, true);
            string data = readFile(fileName);
            string[] portions = splitData(data);

            List<string> portionList = portions.OfType<string>().ToList();
            portionList.RemoveAt(0);
            portions = portionList.ToArray();

            string csv = prepareCSV(portions);
            Logger.Logger.logLine("Parsing Data from abaqus DatFile: " + fileName +" DONE", true);
            return csv;
        }

    }
}
