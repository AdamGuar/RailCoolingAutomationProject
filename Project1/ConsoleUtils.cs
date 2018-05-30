using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimalization
{
    public class ConsoleUtils
    {


        public static void PrintDoubleList(List<double> collectionToPrint,string promptMessage,string entitySeparator)
        {

            foreach(double entity in collectionToPrint){
                Console.Write(promptMessage+entity+entitySeparator);
            }

        }


    }
}
