using System;
using System.CodeDom.Compiler;

namespace Perlin
{
    public class Perlin1D
    {
        /*
        We could actually just make it so that 
        there is a list of octaves where if 
        there is a single member, we have a 
        noise function without additional octaves. 
        */

        private List<List<double>> octaveSlopes = new List<List<double>>();
        /* 
        ^^^^^^
        Is essentially a container of slopeValues. 
        The index of each list in there represents an octave level.
        */

        private List<double> slopeValues = new List<double>();
        static readonly Random randomizer = new Random();
        public List<double> interpolatedData = new List<double>();

        private List<List<double>> octavesInterpolated = new List<List<double>>();
        /*
        ^^^^^^
        This is essentially interpolated data for each octave. 
        The index of each list represents a power for the 
        division by two of octave values that will eventually 
        be summed up into interpolatedData.
        */
        public void Generate1DPerlinInRange(int range, int octaves)
        {
            //TODO: add octaves
            //I go through each octave and double the range on each increment in octave.
            // START OF NEW CODE
            for (int o = 0; o < octaves; o++)
            {
                if (o != 0) range += range - 1;
                List<double> octave = new List<double>();
                for (int i = 0; i < range; i++)
                {
                    octave.Add(GetRandomDouble());
                }
                octaveSlopes.Add(octave);
            }

            slopeValues = octaveSlopes[0];

            // END OF NEW CODE

            /*
            for (int i = 0; i < range; i++)
            {
                slopeValues.Add(GetRandomDouble());
            }
            */

        }

        public double SamplePointAtRatio(double ratio) //Should be SamplePointAtRatio we get a position from ratio by multiplying it with the element count.
        {
            double position = ratio * slopeValues.Count;
            int floorPosition = (int)Math.Floor(position);
            int ceilingPosition = (int)Math.Ceiling(position);

            double distanceFromFloor = position - floorPosition;
            double distanceFromCeiling = distanceFromFloor - 1;

            double floorDotProduct = distanceFromFloor * slopeValues[floorPosition];
            Console.WriteLine(slopeValues.Count);
            Console.WriteLine(ceilingPosition);

            double ceilingDotProduct = distanceFromCeiling * slopeValues[ceilingPosition];

            double sampledPoint = floorDotProduct + SmoothStep(distanceFromFloor)
            * (ceilingDotProduct - floorDotProduct); //LERP

            return sampledPoint;
        }

        private double SmoothStep(double x)
        {
            return 6 * Math.Pow(x, 5) - 15 * Math.Pow(x, 4) + 10 * Math.Pow(x, 3);
        }

        public void SamplePointsWithResolution(int resolution) //Becomes problematic with octaves. Will change later. 
        // Samples a point at the original octave and finds that same relative position in the next.
        {
            List<double> interpolatedPoints = new List<double>();
            double fraction = 1.0 / (resolution + 1); //This is a fraction of the original noise.
            List<double> ratios = new List<double>();
            for (int i = 0; i < slopeValues.Count - 1; i++)
            {
                double ratio = i / slopeValues.Count;
                interpolatedPoints.Add(SamplePointAtRatio(ratio));

                double position;

                for (int j = 0; j < resolution; j++)
                {
                    position = i + fraction * (j + 1); //It will calculate a position for the original.
                    ratio = position / slopeValues.Count;
                    ratios.Add(ratio); //Save positions for future octaves.
                    
                    interpolatedPoints.Add(SamplePointAtRatio(ratio));
                }
            }

            foreach (var ratio in ratios)
            {
                Console.WriteLine(ratio);
            }

            interpolatedPoints.Add(0);

            interpolatedData = interpolatedPoints;
        }

        private static double GetRandomDouble()
        {
            return randomizer.NextDouble() * (1 - (-1)) + -1;
        }
    }
}
