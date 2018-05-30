using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;
using Optimalization.Configuration;

namespace Optimalization.Plots
{
    public class PlotCreator
    {

        List<double> xvals;
        List<double> yvals;


        public PlotCreator()
        {
            xvals = new List<double>();
            yvals = new List<double>();
        }

        //TODO change it to constructor of PlotCreator?
        public void buildDataFromCSV(string csv)
        {
            string[] lines = csv.Split(new[] { '\r', '\n' });
            foreach (string line in lines)
            {
                string[] val = line.Split(new[] { ',' });
                if (val[0] != "" && val[1] != "")
                {
                    double time = Double.Parse(val[0], CultureInfo.InvariantCulture);
                    double temp = Double.Parse(val[1], CultureInfo.InvariantCulture);
                    yvals.Add(temp);
                    xvals.Add(time);
                }
            }
        }


        public void generatePlot(string PlotName)
        {
  
           // create the chart
            var chart = new Chart();
            chart.Size = new Size(800, 600);

            var chartArea = new ChartArea();
            //chartArea.AxisX.LabelStyle.Format = "dd/MMM\nhh:mm";
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisX.LabelStyle.Font = new Font("Consolas", 8);
            chartArea.AxisY.LabelStyle.Font = new Font("Consolas", 8);
            chart.ChartAreas.Add(chartArea);

            var series = new Series();
            series.Name = "Series1";
            series.ChartType = SeriesChartType.FastLine;
            series.XValueType = ChartValueType.Double;
            series.XValueType = ChartValueType.Double;
            chart.Series.Add(series);

            // bind the datapoints
            chart.Series["Series1"].Points.DataBindXY(xvals, yvals);

            // copy the series and manipulate the copy
         /*   chart.DataManipulator.CopySeriesValues("Series1", "Series2");
            chart.DataManipulator.FinancialFormula(
                FinancialFormula.WeightedMovingAverage,
                "Series2"
            );
            chart.Series["Series2"].ChartType = SeriesChartType.FastLine;
            */


            // draw!
            chart.Invalidate();

            // write out a file
            chart.SaveImage(ConfigurationStorage.CONFIGURATION.LogsDirectory+PlotName+".png", ChartImageFormat.Png);

        }
   

    }
}
