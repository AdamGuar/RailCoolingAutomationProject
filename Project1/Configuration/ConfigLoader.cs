using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimalization.Configuration
{
    class ConfigLoader
    {

        public Config loadConfiguration()
        {
            String config = null;

            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader("config.txt"))
                {
                    // Read the stream to a string, and write the string to the console.
                    config = sr.ReadToEnd();
                    Console.WriteLine(config);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Configuration file cant be readed:");
                Console.WriteLine(e.Message);
            }


            string[] lines = config.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            List<string> props = new List<string>();

            foreach(string line in lines)
            {
                string[] localLines = line.Split(new char[] {'='});
                props.Add(localLines[1]);
            }

            return new Config(props[1], props[0], props[2]);
        }

        public void saveToStorage(Config config)
        {
            ConfigurationStorage.CONFIGURATION = config;
        }


    }
}
