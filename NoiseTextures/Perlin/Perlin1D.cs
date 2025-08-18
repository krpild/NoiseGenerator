namespace Perlin
{
    /// <summary>
    /// Class <c>Perln1D</c> generates a one-dimensional perlin noise function.
    /// </summary>
    public class Perlin1D
    {
        private List<List<double>> perlinSlopeList = new List<List<double>>();
        static readonly Random randomizer = new Random();
        public List<double> noise = new List<double>();
        private List<List<double>> interpolatedPerlinList = new List<List<double>>();

        /// <summary>
        /// Prepares slope values for the function and its octaves within a given range.
        /// </summary>
        /// <param name="range">describes how many slopes the first function will contain.</param>
        /// <param name="octaves">each octave represents an additional perlin noise function laid over the first perlin noise function. 0 octaves means that it will be a bare perlin noise function.</param>
        public void GenerateSlopeValuesInRange(int range, int octaves)
        {
            perlinSlopeList = new List<List<double>>(); //Clear the list if it's already populated.
            octaves += 1;
            for (int o = 0; o < octaves; o++)
            {
                if (o != 0) range += range - 1;
                List<double> octave = new List<double>();
                for (int i = 0; i < range; i++)
                {
                    double slope = GetRandomDouble();

                    octave.Add(slope);
                }
                perlinSlopeList.Add(octave);
            }
        }

        private double SamplePointAtRatio(double ratio, int octave)
        {
            double position = ratio * (perlinSlopeList[octave].Count - 1); // It's index based so octaveSlopes[octave].Count has to be - 1
            int floorPosition = (int)Math.Floor(position);
            int ceilingPosition = (int)Math.Ceiling(position);

            double distanceFromFloor = position - floorPosition;
            double distanceFromCeiling = distanceFromFloor - 1;

            double floorDotProduct = distanceFromFloor * perlinSlopeList[octave][floorPosition];
            double ceilingDotProduct = distanceFromCeiling * perlinSlopeList[octave][ceilingPosition];

            double sampledPoint = floorDotProduct + SmoothStep(distanceFromFloor)
            * (ceilingDotProduct - floorDotProduct); //LERP

            return sampledPoint;
        }

        private double SmoothStep(double x)
        {
            return 6 * Math.Pow(x, 5) - 15 * Math.Pow(x, 4) + 10 * Math.Pow(x, 3);
        }

        /// <summary>
        /// Samples points of generated slope values from <see cref="GenerateSlopeValuesInRange"/> at a given resolution.
        /// </summary>
        /// <param name="resolution">amount of points sampled between slopes.</param>
        public void SamplePointsWithResolution(int resolution)
        {
            List<double> ratios = GetRatiosAndInterpolateFirstPerlin(resolution);

            for (int i = 1; i < perlinSlopeList.Count; i++)
            {
                List<double> interpolatedPoints = new List<double>();
                foreach (var ratio in ratios)
                {
                    interpolatedPoints.Add(SamplePointAtRatio(ratio, i));
                }
                interpolatedPerlinList.Add(interpolatedPoints);
            }

            interpolateOctaves();
        }

        private void interpolateOctaves()
        {
            List<double> summedNoise = interpolatedPerlinList[0];

            for (int i = 1; i < interpolatedPerlinList.Count; i++)
            {
                for (int j = 0; j < summedNoise.Count; j++)
                {
                    // Each octave has its data divided by half compared to previous octave level
                    double octavePointHalved = interpolatedPerlinList[i][j] / Math.Pow(2, i);

                    summedNoise[j] += octavePointHalved;
                }
            }

            noise = summedNoise;
        }

        private List<double> GetRatiosAndInterpolateFirstPerlin(int resolution)
        //I do not know how to break this method up without making it more complex
        {
            List<double> interpolatedPoints = new List<double>();
            double fraction = 1.0 / (resolution + 1);
            List<double> ratios = new List<double>();

            double ratio;
            for (int i = 0; i < perlinSlopeList[0].Count - 1; i++)
            {
                //This line is here because divisions between two integers that are converted to doubles get rounded otherwise.
                double maxIndex = perlinSlopeList[0].Count - 1;
                ratio = i / maxIndex;
                ratios.Add(ratio);

                interpolatedPoints.Add(SamplePointAtRatio(ratio, 0));

                double position;

                for (int j = 0; j < resolution; j++)
                {
                    position = i + fraction * (j + 1);

                    ratio = position / (perlinSlopeList[0].Count - 1);

                    ratios.Add(ratio);

                    interpolatedPoints.Add(SamplePointAtRatio(ratio, 0));
                }
            }

            ratios.Add(1);

            interpolatedPoints.Add(0);
            interpolatedPerlinList.Add(interpolatedPoints);

            return ratios;
        }

        private static double GetRandomDouble()
        {
            return randomizer.NextDouble() * (1 - (-1)) + -1;
        }
    }
}
