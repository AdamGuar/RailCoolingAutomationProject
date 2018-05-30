using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Optimalization.INPFileMaker;
using Optimalization.FileUtils;
using Optimalization.CoolingRateCalculator;
using Optimalization.Runners;
using Optimalization.Configuration;
using Optimalization.Plots;


namespace Optimalization.Tests.IntegrationTests
{
    class Tester
    {

        static String CONFIG_PATH = "config.txt";

        public static double[] times = { 10, 12, 200, 29, 3, 0};
        //public static double[] times = { 1000, 0 };

        private static double calculateLast(double[] times)
        {
            double sum = 0;
            foreach(double entity in times)
            {
                sum = sum + entity;
            }

            return 1200 - sum;
        }


        public static void testExcecutionChain()
        {

            ConfigLoader loader = new ConfigLoader();

            Config config = loader.loadConfiguration(CONFIG_PATH);

            loader.saveToStorage(config);
           

            Logger.Logger.logLine("Starting Execution Chain test", true);

           

            string EXECUTION_NAME = "intTest";
            times[times.Length-1] = calculateLast(times);
            string amplitude = AmplitudeCalculator.calculateAmplitude(times,828);
            FileCreator fc = new FileCreator();
            fc.AmplitudeProp = amplitude;
            fc.CreateINPFile(EXECUTION_NAME+".inp");
            //AbaqusProgramRunner.RunAbaqus(EXECUTION_NAME, EXECUTION_NAME);
            string output = AbaqusUtils.parseDataFromAbaqToCSV(ConfigurationStorage.CONFIGURATION.AbaqusDirectory + EXECUTION_NAME+".dat");

            PlotCreator plotDrawer = new PlotCreator();
            plotDrawer.buildDataFromCSV(output);
            plotDrawer.generatePlot("testPlot");

        //    saveCSV(output);

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


        }


        private static void saveCSV(string csv)
        {
            string csvDIR = @"C:\Users\Dom\Dysk Google\VisualStudioProjects\Project1\jarCalc\";

            System.IO.File.WriteAllText(csvDIR +"AbaqOutput.csv" , csv);

        }

    }
}
