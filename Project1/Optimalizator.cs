using KISiM.Common;
using KISiM.Optimization;
using Optimalization.Configuration;
using Optimalization.CoolingRateCalculator;
using Optimalization.FileUtils;
using Optimalization.INPFileMaker;
using Optimalization.Logger;
using Optimalization.Logger.Model;
using Optimalization.Tests.IntegrationTests;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Optimalization
{
  

    class Optimalizator
    {

        //TODO change it!!! to local variable
        static List<Solution> localSolutionList = new List<Solution>();
        static Solution optimalGlobalSolution = new Solution();

        private static GlobalCoolingVariantCounter particleCounter = new GlobalCoolingVariantCounter();

        static int Main(string []args) {
            //Loading configuration file
            ConfigLoader loader = new ConfigLoader();

            Config config = loader.loadConfiguration();

            loader.saveToStorage(config);

            optimalGlobalSolution.Goal = 99999;
            

            // input properties
            List<InputProperties> properties = new List<InputProperties>();
            properties.Add(new InputProperties(0, "1cycle", InputValuesType.Range, new double[] { 100, 200 }));
            properties.Add(new InputProperties(1, "2cycle", InputValuesType.Range, new double[] { 3, 100 }));
            properties.Add(new InputProperties(2, "3cycle", InputValuesType.Range, new double[] { 3, 100}));
            properties.Add(new InputProperties(3, "4cycle", InputValuesType.Range, new double[] { 3, 100 }));
            properties.Add(new InputProperties(4, "5cycle", InputValuesType.Range, new double[] { 3, 100 }));
            properties.Add(new InputProperties(5, "Conductivity", InputValuesType.Range, new double[] { 500, 1000 }));


            //TESTS
            // Tester.testExcecutionChain();

            // PSO

            KISiM.Optimization.Pso pso = new KISiM.Optimization.Pso(
                Evaluator,                              // goal funtion
                                                        //_tf.Properties,
                properties,
                null);                // parameters properties (ranges)
            pso.NextStepEvent += hj_NextStepEvent;
            pso.NewOptimumFindedEvent += pso_NewOptimumFindedEvent;
            var pso_results = pso.Optimize(
                5,            // particles count
                1,         // max error
                10);          // max iterations
           // var pso_minimum = pso_results.Point.Values; // finded optimum

           // ConsoleUtils.PrintDoubleList(pso_minimum, "Pso Minimum equals: ","\n");

            Console.ReadKey();

            return 0;
        }




        static void pso_NewOptimumFindedEvent(object sender, KISiM.Optimization.Core.OptimumEventArgs e)
        {
            Logger.Logger.logLine("Optimum cooling desing found: " + e.Point.Values[0] + ";" + e.Point.Values[1] + ";" + e.Point.Values[2] + ";" + e.Point.Values[3] + ";" + e.Point.Values[4] + ";" +"Conductivity: "+e.Point.Values[5],true);
        }


        static void hj_NextStepEvent(object sender, KISiM.Optimization.Core.NextStepEventArgs e)
        {
            Logger.Logger.logLine("Next step: " + e.Step + ", evaluations: " + e.EvalExecutionCount,true);
        }




        private static void Evaluator(List<KISiM.Optimization.Core.OptimizationPoint> points)
        {
            for (int i = 0; i < points.Count; ++i)
            {
                points[i].PartialErrors = calculateErrorsAndFindSolution(points[i]);
            }

            Logger.Logger.logLine("Best solution in this iteration: \n"+Solution.FindBestSolution(localSolutionList), true);
            checkForBestGlobalSolution();
            localSolutionList = new List<Solution>();

        }


        private static List<double> calculateErrorsAndFindSolution(KISiM.Optimization.Core.OptimizationPoint point)
        {
            double hopedValue = 3.47;
            double[] times = { point.Values[0], point.Values[1], point.Values[2], point.Values[3], point.Values[4], 0 };


            Solution localSolution = GoalFunctionCalculator.getSolution(times, Math.Round(point.Values[5]),particleCounter.Counter,true);
            localSolutionList.Add(localSolution);

            List<double> result = new List<double>();

            Logger.Logger.logLine("ID: "+particleCounter.Counter+" Cooling intervals: " + times[0] + "::: " + times[1] + "::: " + times[2] + "::: " + times[3] + "::: " + times[4] + "Conductivity: " + point.Values[5] + "Goal Function: " + localSolution.Goal, true);

            result.Add(Math.Abs(hopedValue - localSolution.Goal));
  
            particleCounter.Increment();

            return result;
        }

    private static void checkForBestGlobalSolution()
        {
            if (Solution.FindBestSolution(localSolutionList).Goal <= optimalGlobalSolution.Goal) optimalGlobalSolution = Solution.FindBestSolution(localSolutionList);
        }


    }
}
