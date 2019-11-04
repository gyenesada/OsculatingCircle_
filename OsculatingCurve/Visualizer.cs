using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static OsculatingCurve.Form1;

namespace OsculatingCurve
{
    class Visualizer
    {
        PictureBox canvas;
        Graphics graphics;
        Pen drawingPen;

        int scale = 5;

        Point origo = new Point();

        List<Point> pointsToDraw = new List<Point>();

        public Visualizer(PictureBox canvas)
        {
            this.canvas = canvas;
            drawingPen = new Pen(Color.Green);
            initCartesian();
        }

        public void initCartesian()
        {
            graphics = canvas.CreateGraphics();
            graphics.Clear(Color.White);

            Size size = canvas.Size;
            origo.X = size.Width / 2;
            origo.Y = size.Height / 2;

            graphics.DrawLine(new Pen(Color.Gray, 2), size.Width / 2, 0, size.Width / 2, size.Height);
            graphics.DrawLine(new Pen(Color.Gray, 2), 0, size.Height / 2, size.Width, size.Height / 2);
        }

        public void drawFunction(List<dPoint> usedPoints)
        {
            preComputePoints(usedPoints);
            doDraw();
        }

        public void doDraw()
        {
            graphics.Clear(Color.White);
            initCartesian();
            Point bufferPoint = pointsToDraw[0];

            for (int i = 1; i < pointsToDraw.Count(); i++)
            {
                Point nextPoint = pointsToDraw[i];

                graphics.DrawLine(drawingPen, bufferPoint, nextPoint);
                bufferPoint = nextPoint;
            }
        }

        private void preComputePoints(List<dPoint> usedPoints)
        {
            pointsToDraw.Clear();
            Point temp = new Point
                (
                    origo.X + (int)(scale * usedPoints[0].X),
                    origo.Y - (int)(scale * usedPoints[0].Y)
                );

            pointsToDraw.Add(temp);
            int numOfPoints = 1;

            for (int i = 1; i<=usedPoints.Count-1; i++)
            {
                temp = new Point
                (
                    origo.X + (int)(scale*usedPoints[i].X),
                    origo.Y - (int)(scale*usedPoints[i].Y)
                );

                if (!(pointsToDraw[numOfPoints - 1].X == temp.X && pointsToDraw[numOfPoints - 1].Y == temp.Y))
                {
                    pointsToDraw.Add(temp);
                    numOfPoints++;
                }
                
            }

        }

        public Point drawCenterOfCurvature(dPoint centerOfCurvature)
        {
            doDraw();
            Point centerPoint = new Point
                (
                    origo.X + (int)(scale * centerOfCurvature.X),
                    origo.Y - (int)(scale * centerOfCurvature.Y)
                );

            graphics.DrawEllipse(new Pen(Color.Blue), centerPoint.X - 1, centerPoint.Y - 1, 4, 4);
            return centerPoint;
        }

        public void drawCircle(dPoint center, double radius)
        {
            Point centerPoint = drawCenterOfCurvature(center);
            int scaledRadius = (int)(scale * radius);

            graphics.DrawEllipse(new Pen(Color.Pink), centerPoint.X - scaledRadius, centerPoint.Y - scaledRadius, scaledRadius*2, scaledRadius*2);
        }

        public Point transformPoint(Point clickedPoint)
        {
            Point returnedPoint = new Point
                (
                    (clickedPoint.X - origo.X) / scale,
                    (clickedPoint.Y + origo.Y) / scale
                );

            return returnedPoint;
        }

        public void drawPoint(dPoint point, Color color)
        {
            graphics.DrawEllipse(new Pen(color), point.toPoint().X - 3, point.toPoint().Y - 3, 6, 6);
        }
    }
}
