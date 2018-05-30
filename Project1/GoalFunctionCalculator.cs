using Optimalization.Configuration;
using Optimalization.CoolingRateCalculator;
using Optimalization.FileUtils;
using Optimalization.INPFileMaker;
using Optimalization.Logger.Model;
using Optimalization.Plots;
using Optimalization.Runners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimalization
{
    public class GoalFunctionCalculator
    {


        private static double calculateLast(double[] times)
        {
            double sum = 0;
            foreach (double entity in times)
            {
                sum = sum + entity;
            }

            return 1200 - sum;
        }


        public static double getGoalFunction(double[] times, double condt,int particleID, bool plotGraph)
        {
            Logger.Logger.logLine("Starting Simulations", true);

            roundTimes(times);

            string EXECUTION_NAME = "eval";
            times[times.Length - 1] = calculateLast(times);
            string amplitude = AmplitudeCalculator.calculateAmplitude(times,condt);
            FileCreator fc = new FileCreator();
            fc.AmplitudeProp = amplitude;
            fc.CreateINPFile(EXECUTION_NAME + ".inp");
            AbaqusProgramRunner.RunAbaqus(EXECUTION_NAME, EXECUTION_NAME);
            string output = AbaqusUtils.parseDataFromAbaqToCSV(ConfigurationStorage.CONFIGURATION.AbaqusDirectory + EXECUTION_NAME + ".dat");
            if (plotGraph)
            { 
                PlotCreator plotDrawer = new PlotCreator();
                plotDrawer.buildDataFromCSV(output);
                plotDrawer.generatePlot("particleCunter-"+particleID);
            }
            DataParser parser = new DataParser();
            string data = parser.createDataForTransE(output);
            TransEUtils.createTransDat(data);
            TransERunner.Run(ConfigurationStorage.CONFIGURATION.TransEDirectory);


            string transEFileName = ConfigurationStorage.CONFIGURATION.TransEDirectory+"trans.out";

            string austeniteString = TransEUtils.findFraction(Fraction.austenite, transEFileName);
            double austenite = TransEUtils.findFractionDouble(Fraction.austenite, transEFileName);
            double martensite = TransEUtils.findFractionDouble(Fraction.martensite, transEFileName);
            double ferrite = TransEUtils.findFractionDouble(Fraction.ferrite, transEFileName);
            double perlite = TransEUtils.findFractionDouble(Fraction.pearlite, transEFileName);


            double goal = (2 * (1 / austenite)) + (0.5 * martensite) + ferrite + perlite;

            return goal;
        }


        public static Solution getSolution(double[] times, double condt, int particleID, bool plotGraph)
        {
            Logger.Logger.logLine("Starting Simulations", true);

            roundTimes(times);

            string EXECUTION_NAME = "eval";
            times[times.Length - 1] = calculateLast(times);
            string amplitude = AmplitudeCalculator.calculateAmplitude(times, condt);
            FileCreator fc = new FileCreator();
            fc.AmplitudeProp = amplitude;
            fc.CreateINPFile(EXECUTION_NAME + ".inp");
            AbaqusProgramRunner.RunAbaqus(EXECUTION_NAME, EXECUTION_NAME);
            string output = AbaqusUtils.parseDataFromAbaqToCSV(ConfigurationStorage.CONFIGURATION.AbaqusDirectory + EXECUTION_NAME + ".dat");
            if (plotGraph)
            {
                PlotCreator plotDrawer = new PlotCreator();
                plotDrawer.buildDataFromCSV(output);
                plotDrawer.generatePlot("particleCunter-" + particleID);
            }
            DataParser parser = new DataParser();
            string data = parser.createDataForTransE(output);
            TransEUtils.createTransDat(data);
            TransERunner.Run(ConfigurationStorage.CONFIGURATION.TransEDirectory);


            string transEFileName = ConfigurationStorage.CONFIGURATION.TransEDirectory + "trans.out";

            string austeniteString = TransEUtils.findFraction(Fraction.austenite, transEFileName);
            double austenite = TransEUtils.findFractionDouble(Fraction.austenite, transEFileName);
            double martensite = TransEUtils.findFractionDouble(Fraction.martensite, transEFileName);
            double ferrite = TransEUtils.findFractionDouble(Fraction.ferrite, transEFileName);
            double perlite = TransEUtils.findFractionDouble(Fraction.pearlite, transEFileName);


            double goal = (2 * (1 / austenite)) + (0.5 * martensite) + ferrite + perlite;

            Solution result = new Solution();
            result.Intervals = times;
            result.Condt = condt;
            result.Ferrite = ferrite;
            result.Goal = goal;
            result.Martensite = martensite;
            result.Pearlite = perlite;
            result.RetainedAustenite = austenite;

            return result;
        }


        static void roundTimes(double[] times)
        {
            for (int i = 0; i < times.Length; i++)
            {
                times[i] = Math.Round(times[i]);
            }
        }
    }

}
