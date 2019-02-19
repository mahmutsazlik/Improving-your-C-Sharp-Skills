﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

namespace CircleCircleintersection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // The points.
        private List<Point> Circle0Points = new List<Point>();
        private RectangleF Circle0 = new RectangleF(-1, -1, 1, 1);
        private List<Point> Circle1Points = new List<Point>();
        private RectangleF Circle1 = new RectangleF(-1, -1, 1, 1);
        private List<PointF> Intersections = new List<PointF>();

        // Save a new point.
        private void circlePictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Circle0Points.Count == 3) Circle0Points = new List<Point>();
                Circle0Points.Add(e.Location);
            }
            else
            {
                if (Circle1Points.Count == 3) Circle1Points = new List<Point>();
                Circle1Points.Add(e.Location);
            }

            // See if we have circle 0.
            if (Circle0Points.Count == 3)
                Circle0 = FindCircle(Circle0Points[0], Circle0Points[1], Circle0Points[2]);

            // See if we have circle 1.
            if (Circle1Points.Count == 3)
                Circle1 = FindCircle(Circle1Points[0], Circle1Points[1], Circle1Points[2]);

            // See if we have both circles.
            Intersections = new List<PointF>();
            if ((Circle0Points.Count == 3) && (Circle1Points.Count == 3))
            {
                Intersections = FindCircleCircleIntersections(
                    Circle0Points[0], Circle0Points[1], Circle0Points[2],
                    Circle1Points[0], Circle1Points[1], Circle1Points[2]);
            }

            // Redraw.
            circlePictureBox.Refresh();
        }

        // Draw whatever information we have.
        private void circlePictureBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw the points.
            const int r = 3;
            foreach (Point point in Circle0Points)
                e.Graphics.DrawEllipse(Pens.Red,
                    point.X - r, point.Y - r, 2 * r, 2 * r);
            foreach (Point point in Circle1Points)
                e.Graphics.DrawEllipse(Pens.Green,
                    point.X - r, point.Y - r, 2 * r, 2 * r);

            // Draw the circles.
            if (Circle0Points.Count == 3)
                e.Graphics.DrawEllipse(Pens.Red, Circle0);
            if (Circle1Points.Count == 3)
                e.Graphics.DrawEllipse(Pens.Green, Circle1);

            // Draw the points of intersection.
            foreach (PointF point in Intersections)
                e.Graphics.DrawEllipse(Pens.Blue,
                    point.X - r, point.Y - r, 2 * r, 2 * r);

            // Draw the points of intersection.
            foreach (PointF point in Intersections)
                e.Graphics.DrawEllipse(Pens.Blue,
                    point.X - r, point.Y - r, 2 * r, 2 * r);
        }

        // Return a RectangleF that defines a circle passing through the three points.
        private RectangleF FindCircle(PointF p0, PointF p1, PointF p2)
        {
            // Find a bisector for p0-p1.
            PointF b00, b01;
            FindBisector(p0, p1, out b00, out b01);

            // Find a bisector for p1-p2.
            PointF b10, b11;
            FindBisector(p1, p2, out b10, out b11);

            // Find the bisectors' point of intersection.
            bool linesAreParallel;
            PointF center = IntersectLines(b00, b01, b10, b11, out linesAreParallel);
            if (linesAreParallel)
            {
                MessageBox.Show("The circle's points are colinear");
                return new RectangleF(-1, -1, -1, -1);
            }

            // Return the circle.
            float radius = Distance(center, p0);
            return new RectangleF(
                center.X - radius, center.Y - radius,
                2 * radius, 2 * radius);
        }

        // Find a bisector for the segment connecting the two points.
        private void FindBisector(PointF p0, PointF p1, out PointF b0, out PointF b1)
        {
            // Find the midpoint.
            b0 = new PointF(
                (p0.X + p1.X) / 2,
                (p0.Y + p1.Y) / 2);

            // Find the p0-p1 direction vector.
            float dx = p1.X - p0.X;
            float dy = p1.Y - p0.Y;

            // Add <dy, -dx> to b0 to get b1.
            b1 = new PointF(
                b0.X + dy,
                b0.Y - dx);
        }

        // Find the point of intersection between the lines p00-p01 and p10-p11.
        private PointF IntersectLines(PointF p00, PointF p01, PointF p10, PointF p11,
            out bool linesAreParallel)
        {
            // Get the segments' parameters.
            float v0x = p01.X - p00.X;
            float v0y = p01.Y - p00.Y;
            float v1x = p11.X - p10.X;
            float v1y = p11.Y - p10.Y;

            // Solve for t0 and t1.
            float denominator = v0y * v1x - v0x * v1y;

            float t0 = (v1y * (p00.X - p10.X) - v1x * (p00.Y - p10.Y)) / denominator;
            if (float.IsInfinity(t0))
            {
                linesAreParallel = true;
                return new PointF(-1, -1);
            }

            linesAreParallel = false;
            PointF p0 = new PointF(
                p00.X + t0 * v0x,
                p00.Y + t0 * v0y);
            return p0;
        }

        // Return the distance between two points.
        private float Distance(PointF p0, PointF p1)
        {
            float dx = p0.X - p1.X;
            float dy = p0.Y - p1.Y;
            float distanceSquared = dx * dx + dy * dy;
            return (float)Math.Sqrt(distanceSquared);
        }

        // Find the point of intersection between a circle defined by
        // points p0, p1, p2 and the line define by points l0, l1.
        private List<PointF> FindLineCircleIntersections(
            PointF c0, PointF c1, PointF c2,
            PointF p0, PointF p1)
        {
            // Make a list to hold the points of intersection.
            List<PointF> results = new List<PointF>();

            // Find the circle.
            RectangleF circleRect = FindCircle(c0, c1, c2);

            // If the points don't define a circle, return the empty results list.
            if (circleRect.Width < 0) return results;

            // Get the circle's center and radius.
            float radius = circleRect.Width / 2;
            PointF c = new PointF(
                circleRect.X + radius,
                circleRect.Y + radius);

            // Find the intersection.
            float vx = p1.X - p0.X;
            float vy = p1.Y - p0.Y;
            float A = vx * vx + vy * vy;
            float B = 2 * (vx * (p0.X - c.X) + vy * (p0.Y - c.Y));
            float C =
                (p0.X - c.X) * (p0.X - c.X) +
                (p0.Y - c.Y) * (p0.Y - c.Y) -
                radius * radius;

            float discriminant = B * B - 4 * A * C;
            if (discriminant < 0)
            {
                Console.WriteLine("No real solutions");
                return results;
            }

            if (Math.Abs(discriminant) < 0.0001)
            {
                Console.WriteLine("One solution");
                float t = -B / (2 * A);
                results.Add(new PointF(
                    p0.X + t * vx,
                    p0.Y + t * vy));
            }
            else
            {
                Console.WriteLine("Two solutions");
                float root = (float)Math.Sqrt(discriminant);

                float t0 = (-B + root) / (2 * A);
                results.Add(new PointF(
                    p0.X + t0 * vx,
                    p0.Y + t0 * vy));

                float t1 = (-B - root) / (2 * A);
                results.Add(new PointF(
                    p0.X + t1 * vx,
                    p0.Y + t1 * vy));
            }

            return results;
        }

        // Find the points of intersection between the circles defined
        // by points p00, p01, p02 and p10, p11, p12.
        private List<PointF> FindCircleCircleIntersections(
            Point p00, Point p01, Point p02,
            Point p10, Point p11, Point p12)
        {
            const float tiny = 0.0001f;

            List<PointF> results = new List<PointF>();

            // Find the two circles, their centers, and their radii.
            Circle0 = FindCircle(p00, p01, p02);
            float R0 = Circle0.Width / 2;
            PointF C0 = new PointF(
                Circle0.X + R0,
                Circle0.Y + R0);

            Circle1 = FindCircle(p10, p11, p12);
            float R1 = Circle1.Width / 2;
            PointF C1 = new PointF(
                Circle1.X + R1,
                Circle1.Y + R1);

            // Find the distance between the centers.
            double D = Distance(C0, C1);

            // See how many solutions there are.
            if (D > R0 + R1)
            {
                Console.WriteLine("No intersections, the circles are too far apart");
            }
            else if (D < Math.Abs(R0 - R1))
            {
                Console.WriteLine("No intersections, one circle contains the other");
            }
            else if ((Math.Abs(D) < tiny) && (Math.Abs(R0 - R1) < tiny))
            {
                Console.WriteLine("No intersections, the circles are the same");
            }
            else
            {
                // Find A and H.
                double A = (R0 * R0 - R1 * R1 + D * D) / (2 * D);
                double H = Math.Sqrt(R0 * R0 - A * A);

                // Find P2.
                double P2x = C0.X + A * (C1.X - C0.X) / D;
                double P2y = C0.Y + A * (C1.Y - C0.Y) / D;

                // Get the point P3.
                results.Add(new PointF(
                    (float)(P2x + H * (C1.Y - C0.Y) / D),
                    (float)(P2y - H * (C1.X - C0.X) / D)));
    
                // See if we a second solution.
                if (Math.Abs(D - (R0 + R1)) >= tiny)
                {
                    // Add the second solution with the +/- signs switched.
                    results.Add(new PointF(
                        (float)(P2x - H * (C1.Y - C0.Y) / D),
                        (float)(P2y + H * (C1.X - C0.X) / D)));
                }

                Console.WriteLine(results.Count.ToString() + " intersections");
            }

            // Return whatever results we found.
            return results;
        }
    }
}
