using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimalization.Logger.Model
{
    public class Solution
    {
        double[] intervals;
        double conduct;
        double goal;

        double retainedAustenite;
        double martensite;
        double ferrite;
        double pearlite;
        

        public double Condt
        {
            get { return conduct; }
            set { conduct = value; }
        }

        public double Goal
        {
            get { return goal; }
            set { goal = value; }
        }


        public double[] Intervals
        {
            get { return intervals; }
            set { intervals = value; }
        }


        public double RetainedAustenite
        {
            get { return retainedAustenite;}
            set { retainedAustenite = value; }
        }

        public double Martensite
        {
            get { return martensite; }
            set { martensite = value; }
        }


        public double Ferrite
        {
            get { return ferrite; }
            set { ferrite = value; }
        }

        public double Pearlite
        {
            get { return pearlite; }
            set { pearlite = value; }
        }

        public override string ToString()
        {
            string result = "";

            result = "Cooling intervals(starting with liquid): ";
            foreach(double interval in Intervals)
            {
                result = result + interval + " ; ";

            }
            result = result + "Liquid K=" + Condt;

            result = result + "\n";
            result = result + "Fractions: " + "[RetainedAustenite =" + RetainedAustenite + " ] " + "[Martensite =" + Martensite + " ]" + "[Ferrite =" + Ferrite + " ] " + "[Pearlite =" + Pearlite + " ] ";

            return result;
        }


        public static Solution FindBestSolution(List<Solution> Solutions)
        {
            Solution result = new Solution();
            result.Goal = 9999;

            foreach(Solution entity in Solutions)
            {
                if (entity.Goal <= result.Goal) result = entity;
            }

            return result;
        }

    }
}
