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

        public void samplePointAtPosition(double position)
        {
            int floorPosition = (int)Math.Floor(position);
            int ceilingPosition = (int)Math.Ceiling(position);
            Console.WriteLine("Floor and ceiling positions at " + position);
            Console.WriteLine(floorPosition);
            Console.WriteLine(ceilingPosition);
        }

        private static double GetRandomDouble()
        {
            return randomizer.NextDouble() * (1 - (-1)) + -1;
        }
    }
}
