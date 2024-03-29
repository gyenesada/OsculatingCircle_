﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OsculatingCurve
{
    public partial class Form1 : Form
    {
        double epszilon = 0.1;
        List<dPoint> usedPoints = new List<dPoint>();

        dPoint firstDerivative;
        dPoint secondDerivative;
        dPoint normalVector;

        Image img;

        double curvature;
        double radiusOfCurvature;
        dPoint centerOfCurvature;
        Visualizer visualizer;

        dPoint ortogonalizedSecondDerivative;

        Point pont;
        dPoint closest;

        public Form1()
        {
            InitializeComponent();
        }

        #region Operators
        Dictionary<string, Func<double, double>> unaryOperators = new Dictionary<string, Func<double, double>>() {
            { "neg", x => -x },
            { "sqr", x => x*x},
            { "sqrt", Math.Sqrt },
            { "sin", Math.Sin},
            { "cos", Math.Cos},
            { "tan", Math.Tan},
            { "sinh", Math.Sinh},
            { "cosh", Math.Cosh},
            { "tanh", Math.Tanh}
        };

        Dictionary<string, Func<double, double, double>> binaryOperators = new Dictionary<string, Func<double, double, double>>() {
            { "+", (x,y) => x+y },
            { "-", (x,y) => x-y },
            { "*", (x,y) => x*y },
            { "/", (x,y) => x/y },
            { "^", (x,y) => Math.Pow(x, y)}
        };
        #endregion

        #region Struct
        public struct dPoint
        {
            public double X;
            public double Y;

            public dPoint(double x, double y)
            {
                X = x;
                Y = y;
            }

            public Point toPoint()
            {
                return new Point((int)X, (int)Y);
            }

            public void Normalize(double newNorm)
            {
                double Length = this.euclideanNorm();
                X = Math.Sqrt(newNorm) * X / Length;
                Y = Math.Sqrt(newNorm) * Y / Length;
            }

            public double scalar(dPoint y)
            {
                return (X * y.X) + (Y * y.Y);
            }

            public double euclideanNorm()
            {
                return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
            }

        }
        #endregion

        private double stringToFunction(string text, double input)
        {
            List<string> inputString = new List<string>(text.Split(','));
            inputString.Reverse();
            List<double> evalStack = new List<double>();

            foreach (string item in inputString)
            {
                if (unaryOperators.ContainsKey(item))
                {
                    double result = unaryOperators[item]
                        (
                            evalStack[evalStack.Count - 1]
                        );
                    evalStack.RemoveAt(evalStack.Count - 1);
                    evalStack.Add(result);
                }
                else if (binaryOperators.ContainsKey(item))
                {
                    double result = binaryOperators[item]
                        (
                            evalStack[evalStack.Count - 2],
                            evalStack[evalStack.Count - 1]
                        );
                    evalStack.RemoveRange(evalStack.Count - 2, 2);
                    evalStack.Add(result);
                }
                else
                {
                    if (item == "t")
                    {
                        evalStack.Add(input);
                    }
                    else
                    {
                        try
                        {
                            evalStack.Add(Double.Parse(item.Replace('.', ',')));
                        }catch(System.FormatException e)
                        {
                            MessageBox.Show("Nem jó formátum!");
                        }
                    }
                }
            }

            return evalStack.First();
        }

        private void getPoints()
        {
            usedPoints.Clear();

            string codeX = textBoxX.Text;
            string codeY = textBoxY.Text;
            string[] interval = textBoxInt.Text.Split(',');

            if ((textBoxPoint.Text != ","))
            {
                pont = new Point(
                    int.Parse(textBoxPoint.Text.Split(',')[0]),
                    int.Parse(textBoxPoint.Text.Split(',')[1])
                );
            }

            if (interval.Length != 2) throw new ArgumentException();

            double from = double.Parse(interval[0]);
            double to = double.Parse(interval[1]);

            dPoint bufferPoint = new dPoint(stringToFunction(codeX, from),
                stringToFunction(codeY, from));

            usedPoints.Add(bufferPoint);

            for (double i = from + 0.1; i < to; i += epszilon)
            {
                dPoint nextPoint = new dPoint((stringToFunction(codeX, i)),
                    (stringToFunction(codeY, i)));

                usedPoints.Add(nextPoint);
                bufferPoint = nextPoint;
            }

        }

        private void runButton_Click(object sender, EventArgs e)
        {
            visualizer = new Visualizer(canvas);
            getPoints();

            if (pont != null)
            {
                int index = closestPoint(pont);
            }

            visualizer.drawFunction(usedPoints);
            cleanBtn.Enabled = true;
        }


        private int closestPoint(Point p)
        {
            int resultIndex = 0;
            double deltaX = usedPoints.First().X - p.X;
            double deltaY = usedPoints.First().Y - p.Y;

            double minDistance = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));

            for (int i = 1; i < usedPoints.Count; i++)
            {
                deltaX = usedPoints.ElementAt(i).X - p.X;
                deltaY = usedPoints.ElementAt(i).Y - p.Y;

                double newDistance = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));

                if (newDistance < minDistance)
                {
                    minDistance = newDistance;
                    resultIndex = i;
                    closest = new dPoint(usedPoints[i].X, usedPoints[i].Y);
                }
            }

            return resultIndex;
        }

        private void getFirstDerivative(int index)
        {
            firstDerivative = new dPoint(
                (usedPoints[index + 1].X - usedPoints[index].X) / epszilon,
                (usedPoints[index + 1].Y - usedPoints[index].Y) / epszilon
            );
        }

        private void getSecondDerivative(int index)
        {
            secondDerivative = new dPoint(
                (usedPoints[index + 1].X - (2 * usedPoints[index].X) + usedPoints[index - 1].X) / Math.Pow(epszilon, 2),
                (usedPoints[index + 1].Y - (2 * usedPoints[index].Y) + usedPoints[index - 1].Y) / Math.Pow(epszilon, 2)
                );
        }

        private void calcCurvature() 
        {

            normalVector = new dPoint(-firstDerivative.Y, firstDerivative.X);
            curvature = ((secondDerivative.scalar(normalVector)) / Math.Pow(firstDerivative.euclideanNorm(), 2));

            Console.WriteLine("Görbület: " + curvature);

            if (curvature > 0.0000000000001 || curvature < -0.0000000000001)
            {
                radiusOfCurvature = 1 / Math.Abs(curvature); 
            }
            else
            {
                radiusOfCurvature = 0;
            }

            Console.WriteLine("Görbületi sugár: " + radiusOfCurvature);
            
        }

        private void G_S_ortogonalization()
        {
            double c = secondDerivative.scalar(firstDerivative) / firstDerivative.scalar(firstDerivative);

            dPoint secondDerivateS = new dPoint
                (
                secondDerivative.X - c * firstDerivative.X,
                secondDerivative.Y - c * firstDerivative.Y
                );

            double multiplier = 1 / secondDerivateS.euclideanNorm();

            ortogonalizedSecondDerivative = new dPoint
                (
                multiplier * secondDerivateS.X,
                multiplier * secondDerivateS.Y
                );
        }

        private void calcCentreOfCurvate(int index)
        {
            G_S_ortogonalization();
            centerOfCurvature = new dPoint
                (
                    usedPoints[index].X + radiusOfCurvature * ortogonalizedSecondDerivative.X,
                    usedPoints[index].Y + radiusOfCurvature * ortogonalizedSecondDerivative.Y
                );

            Console.WriteLine("Görbületi középpont: (" + centerOfCurvature.X + "," + centerOfCurvature.Y + ")");
        }

        private void canvas_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point bufferPoint = visualizer.transformPoint(me.Location);
            
            int index = closestPoint(bufferPoint);
        }

        private void animationBtn_Click(object sender, EventArgs e)
        {
            for(int i=2; i<=usedPoints.Count-2; i+=1)
            {
                getFirstDerivative(i);
                getSecondDerivative(i);

                calcCurvature();
                calcCentreOfCurvate(i);

                using (var bmpTemp = new Bitmap("temp.jpg"))
                {
                    img = new Bitmap(bmpTemp);
                } 
                
                if (holdOnCB.Checked)
                {
                    if (centerCB.Checked)
                    {
                        visualizer.drawCircle(centerOfCurvature, radiusOfCurvature, img, true, true);
                    }else
                    {
                        visualizer.drawCircle(centerOfCurvature, radiusOfCurvature, img, true, false);
                    }
                }
                else
                {
                    visualizer.drawCircle(centerOfCurvature, radiusOfCurvature, img, false, false);
                }

                Thread.Sleep(150);
            }
        }

        private void pointBtn_Click(object sender, EventArgs e)
        {
            string[] chosenPoint = textBoxPoint.Text.Split(',');
            if (chosenPoint.Length == 2 && textBoxPoint.Text != ",")
            {

                pont = new Point(
                    int.Parse(textBoxPoint.Text.Split(',')[0]),
                    int.Parse(textBoxPoint.Text.Split(',')[1])
                );

                int index = closestPoint(pont);

                visualizer.drawFunction(usedPoints);
                Console.WriteLine("Legközelebbi pont: " + closest.X + ", " + closest.Y);

                getFirstDerivative(index);
                Console.WriteLine("Első derivált: " + firstDerivative.X + ", " + firstDerivative.Y);

                getSecondDerivative(index);
                Console.WriteLine("Második derivált: " + secondDerivative.X + ", " + secondDerivative.Y);

                calcCurvature();
                calcCentreOfCurvate(index);
                visualizer.drawCircle(centerOfCurvature, radiusOfCurvature);
            }
        }

        private void holdOnCB_CheckedChanged(object sender, EventArgs e)
        {
            if (holdOnCB.Checked)
            {
                centerCB.Enabled = true;
            }else
            {
                centerCB.Enabled = false;
            }
        }

        private void cleanBtn_Click(object sender, EventArgs e)
        { 
            visualizer.drawFunction(usedPoints);
        }
    }
}
