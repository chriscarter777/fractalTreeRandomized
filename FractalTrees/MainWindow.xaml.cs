using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FractalTrees
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // **Draw button event handler**
        private void btnDraw_Click(object sender, RoutedEventArgs e)
        {
            int gen = int.Parse(txtGenerations.Text);
            double ang = double.Parse(txtAngle.Text) /2;
            double len = double.Parse(txtLength.Text);
            double rand = double.Parse(txtRandomness.Text);
            CreateFractalTree(gen, ang, len, rand);
        }

        // **Reset button event handler**
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            txtGenerations.Text = "";
            txtAngle.Text = "";
            txtLength.Text = "";
            txtRandomness.Text = "0.0";
            drawSpace.Children.Clear();
        }

        // **Main routine**
        private void CreateFractalTree(int generations, double relativeAngle, double relativeLength, double randomness)
        {
            //calculate tree dimensions and instantiate the array of line segments
            int numLeaves = (int)(Math.Pow(2, generations));
            int numSegs = numLeaves * generations;
            Segment[,] segments = new Segment[generations + 1,numLeaves];
            Console.WriteLine("segments is initialized to " + segments.GetUpperBound(0) + " by " + segments.GetUpperBound(1));

            //seed the random number
            Random rnd = new Random();

            //starting parameters for generation 0
            double segLength = 120;
            double ang0 = 0;
            int x0 = 500;
            int y0 = 700;
            int wt0 = generations;
            Color sc0 = Colors.SaddleBrown;

            //initialize the generation 0 segment: this is the "seed"
            Segment initSegment = new Segment(segLength, ang0, relativeAngle, x0, y0, wt0, sc0);
            segments[0, 0] = initSegment;

            //loop through each generation
            for (int generation=0; generation <= generations; generation++)
            {
                //set attributes for the child generation
                int childGeneration = generation + 1;
                segLength *= relativeLength;
                int segWeight = generations - generation;
                Color segColor = new Color();
                    if (childGeneration == generations)
                    {
                        segColor = Colors.Green;
                    }
                    else
                    {
                        segColor = Colors.SaddleBrown;
                    }

                //loop through each segment in this generation... 
                int i = 0;
                int childGenerationcounter = 0;
                while (i <= (numLeaves - 1) && segments[generation, i] != null)
                {
                    Segment thisSegment = segments[generation, i];
                    //...draw it 
                    Console.WriteLine("DRAWING--Generation:" + generation + "/ Segment:" + i);
                    Console.WriteLine(thisSegment.ToString());
                    DrawSegment(thisSegment);
                    //...and initialize its two child segments if this is not already the last generation
                    if (generation < generations)
                    {
                        //introduce randomness in segment length and angle here
                        double leftSegLength = segLength + (segLength * (((rnd.NextDouble() * 2) - 1) * randomness));
                        Console.WriteLine(leftSegLength);
                        double rightSegLength = segLength + (segLength * (((rnd.NextDouble() * 2) - 1) * randomness));
                        Console.WriteLine(rightSegLength);
                        double leftAngle = thisSegment.ExitAngleLeft + (relativeAngle * (((rnd.NextDouble() * 2) - 1) * randomness));
                        Console.WriteLine(leftAngle);
                        double rightAngle = thisSegment.ExitAngleRight + (relativeAngle * (((rnd.NextDouble() * 2) - 1) * randomness));
                        Console.WriteLine(rightAngle);


                        segments[childGeneration, childGenerationcounter] = new Segment(leftSegLength, leftAngle, relativeAngle, thisSegment.X2, thisSegment.Y2, segWeight, segColor);
                        Console.WriteLine("Created " + "[" + childGeneration + "] [" + childGenerationcounter + "]");
                        childGenerationcounter++;
                        segments[childGeneration, childGenerationcounter] = new Segment(rightSegLength, rightAngle, relativeAngle, thisSegment.X2, thisSegment.Y2, segWeight, segColor);
                        Console.WriteLine("Created " + "[" + childGeneration + "] [" + childGenerationcounter + "]");
                        childGenerationcounter++;
                    }
                    i ++;
                }
                Console.WriteLine("FINISHED PROCESSING GENERATION " + generation);
            }
        }

        public void DrawSegment(Segment segment)
        {
            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = segment.SegColor;

            Line line = new Line();
            line.StrokeThickness = segment.SegWeight;
            line.X1             = segment.X1;
            line.Y1            = segment.Y1;
            line.X2           = segment.X2;
            line.Y2          = segment.Y2;
            line.Stroke     = brush;

            drawSpace.Children.Add(line);
        }
    }

    // Each tree segment is defined as an object, with accessors which calculate its endpoint and exit (spawning) angles
    public class Segment
    {
        private double length;
        private double angle;
        private double relAngle;
        private int    x1;
        private int    y1;
        private int    segWeight;
        private Color  segColor;

        public Segment(double len, double ang, double rAng, int x, int y, int sWt, Color sColr)
        {
             length = len;
             angle = ang;
             relAngle = rAng;
             x1 = x;
             y1 = y;
             segWeight = sWt;
             segColor = sColr;
        }

        public double Length
        {
            get
            {
                return length;
            }
            set
            {
                length = value;
            }
        }
        public double Angle
        {
            get
            {
                return angle;
            }
            set
            {
                angle = value;
            }
        }
        public double ExitAngleLeft
        {
            get
            {
                return angle - relAngle;
            }
        }
        public double ExitAngleRight
        {
            get
            {
                return angle + relAngle;
            }
        }
        public int X1
        {
            get
            {
                return x1;
            }
            set
            {
                x1 = value;
            }
        }
        public int Y1
        {
            get
            {
                return y1;
            }
            set
            {
                y1 = value;
            }
        }
        public int X2
        {
            get
            {
                return x1 + GetDeltaX(length, angle);
            }
        }
        public int Y2
        {
            get
            {
                return y1 - GetDeltaY(length, angle);
            }
        }
        public int SegWeight
        {
            get
            {
                return segWeight;
            }
        }

            public Color SegColor
        {
            get
            {
                return segColor;
            }
        }

        private int GetDeltaX (double length, double angle)
        {
            return (int)Math.Round((length * Math.Sin(angle)));
        }

        private int GetDeltaY(double length, double angle)
        {
            return (int)Math.Round((length * Math.Cos(angle)));
        }

        public override string ToString()
        {
            string descr = "Segment: Length " + Length + " Angle " + Angle + " ExitAngleLeft " + ExitAngleLeft + " ExitAngleRight " + ExitAngleRight + " Weight " + SegWeight + " Color " + SegColor + " from " + X1 + " , " + Y1 + " to " + X2 + " , " + Y2;
            return descr;
        }
    }
}
