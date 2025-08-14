using System;
using System.CodeDom.Compiler;

namespace Perlin
{
    public class Perlin1D
    {
        private List<double> perlin1DSlopeValues = new List<double>();
        static readonly Random randomizer = new Random();

        public void Generate1DPerlinInRange(int range)
        {
            for (int i = 0; i < range; i++)
            {
                perlin1DSlopeValues.Add(GetRandomDouble());
            }
        }

        public double SamplePointAtPosition(double position)
        {
            int floorPosition = (int)Math.Floor(position);
            int ceilingPosition = (int)Math.Ceiling(position);

            double a = perlin1DSlopeValues[floorPosition];
            double b = perlin1DSlopeValues[ceilingPosition];

            double distanceFromFloor = position - floorPosition;
            double distanceFromCeiling = distanceFromFloor - 1;

            double floorDotProduct = distanceFromFloor * a;
            double ceilingDotProduct = distanceFromCeiling * b;
            

            double sampledPoint = floorDotProduct + SmoothStep(distanceFromFloor) * (ceilingDotProduct-floorDotProduct); //LERP

            return sampledPoint;
        }

        private double SmoothStep(double x)
        {
            return 6 * Math.Pow(x, 5) - 15 * Math.Pow(x, 4) + 10 * Math.Pow(x, 3);
        }

        public List<double> SamplePointsWithFrequency(int frequency)
        {
            List<double> interpolatedPoints = new List<double>();
            double fraction = 1.0 / (frequency + 1);
            for (int i = 0; i < perlin1DSlopeValues.Count - 1; i++)
            {
                interpolatedPoints.Add(SamplePointAtPosition(i));

                double position;

                for (int j = 0; j < frequency; j++)
                {
                    position = i + fraction * (j + 1);
                    interpolatedPoints.Add(SamplePointAtPosition(position));
                }
            }

            interpolatedPoints.Add(0);

            return interpolatedPoints;
        }

        private static double GetRandomDouble()
        {
            return randomizer.NextDouble() * (1 - (-1)) + -1;
        }
    }
}
