using System;
using Perlin;

namespace Visualizer
{
    public static class GraphGenerator
    {
        public static void VisualiseGraph(Perlin1D noise)
        {
            string[,] drawing = new string[21, noise.interpolatedData.Count - 1];
            double position;
            string symbol;

            for (int x = 0; x < noise.interpolatedData.Count - 1; x++)
            {

                for (int y = 20; y >= 0; y--)
                {
                    position = Math.Round(-1.0 + (y * 0.1), 1);

                    if (noise.interpolatedData[x] <= position)
                    {
                        symbol = "#";
                    }
                    else
                    {
                        symbol = " ";
                    }

                    drawing[y, x] = symbol;

                    Console.WriteLine(position);
                }
            }

            for (int x = 0; x < drawing.GetLength(0); x++)
            {
                for (int y = 0; y < drawing.GetLength(1); y++)
                {
                    Console.Write(drawing[x, y]);
                }
                Console.Write("\n");
            }

        }
    }
}
