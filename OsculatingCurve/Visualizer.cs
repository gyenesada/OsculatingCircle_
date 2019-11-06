using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
            drawingPen = new Pen(Color.Green, 1.5f);
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

        public void initCartesian(Graphics g)
        {
            graphics = canvas.CreateGraphics();
            g.Clear(Color.White);

            Size size = canvas.Size;
            origo.X = size.Width / 2;
            origo.Y = size.Height / 2;

            g.DrawLine(new Pen(Color.Gray, 2), size.Width / 2, 0, size.Width / 2, size.Height);
            g.DrawLine(new Pen(Color.Gray, 2), 0, size.Height / 2, size.Width, size.Height / 2);
        }

        public void drawFunction(List<dPoint> usedPoints)
        {
            preComputePoints(usedPoints);
            doDraw();
        }



        public void doDraw()
        {
            using (Bitmap bmp = new Bitmap(canvas.Width, canvas.Height))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    //graphics.Clear(Color.White);
                    initCartesian(g);
                    initCartesian(graphics);
                    Point bufferPoint = pointsToDraw[0];

                    for (int i = 1; i < pointsToDraw.Count(); i++)
                    {
                        Point nextPoint = pointsToDraw[i];

                        g.DrawLine(drawingPen, bufferPoint, nextPoint);
                        graphics.DrawLine(drawingPen, bufferPoint, nextPoint);

                        bufferPoint = nextPoint;
                    }
                }
                bmp.Save("temp.jpg");
            }

        }

        public void refresh(Image img)
        {
                graphics.Clear(Color.White);
                canvas.Refresh();

                canvas.Image = img;
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

            Point centerPoint = new Point
                (
                    origo.X + (int)(scale * centerOfCurvature.X),
                    origo.Y - (int)(scale * centerOfCurvature.Y)
                );
            graphics.DrawEllipse(new Pen(Color.Black), centerPoint.X - 1, centerPoint.Y - 1, 4, 4);
            return centerPoint;
        }

        public void drawCircle(dPoint center, double radius, Image img, Boolean b, Boolean centerOnly)
        {
            if (!b)
            {
                refresh(img);
            }
            Point centerPoint = drawCenterOfCurvature(center);
            int scaledRadius = (int)(scale * radius);
            if (!centerOnly)
            {
                graphics.DrawEllipse(new Pen(Color.Coral), centerPoint.X - scaledRadius, centerPoint.Y - scaledRadius, scaledRadius * 2, scaledRadius * 2);
            }
        }

        public void drawCircle(dPoint center, double radius)
        {
            Point centerPoint = drawCenterOfCurvature(center);
            int scaledRadius = (int)(scale * radius);
            graphics.DrawEllipse(new Pen(Color.Coral), centerPoint.X - scaledRadius, centerPoint.Y - scaledRadius, scaledRadius * 2, scaledRadius * 2);
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
