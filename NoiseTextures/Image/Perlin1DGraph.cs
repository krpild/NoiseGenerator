using Perlin;

namespace Visualizer
{
    public static class GraphGenerator
    {
        public static void VisualiseGraph(Perlin1D noise)
        {

            string[,] drawing = BuildGraph(noise);
            
            for (int x = 0; x < drawing.GetLength(0); x++)
            {
                for (int y = 0; y < drawing.GetLength(1); y++)
                {
                    
                    switch (drawing[x, y])
                    {
                        case "@":
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case ".":
                            Console.ForegroundColor = ConsoleColor.Black;
                            break;
                        case "-":
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                    Console.Write(drawing[x, y]);
                }
                Console.Write("\n");
            }

        }

        private static string[,] BuildGraph(Perlin1D noise)
        {
            double ceiling = Math.Round(noise.interpolatedData.Max() + 0.5, 1);
            double floor = Math.Round(noise.interpolatedData.Min() - 0.5, 1);

            List<double> verticalRange = GetVerticalVisualisationRange(floor, ceiling);

            string[,] drawing = new string[verticalRange.Count, noise.interpolatedData.Count];
            double position;
            string symbol;
            bool occupied;

            for (int x = 0; x < noise.interpolatedData.Count; x++)
            {
                occupied = false;
                for (int y = verticalRange.Count - 1; y >= 0; y--)
                {
                    position = verticalRange[y];
                    if (Math.Round(noise.interpolatedData[x], 1) == position)
                    {
                        occupied = !occupied;
                        symbol = "#";
                        if (noise.interpolatedData[x] == 0) symbol = "@";
                        if (position == 0) occupied = !occupied;
                    }
                    else if (occupied)
                    {
                        symbol = ".";
                    }
                    else
                    {
                        symbol = " ";
                    }

                    if (symbol != "#" && symbol != "@" && position == 0)
                    {
                        symbol = "-";
                        occupied = !occupied;
                    }

                    drawing[y, x] = symbol;
                }
            }

            return drawing;
        }

        private static List<double> GetVerticalVisualisationRange(double floor, double ceiling)
        {
            List<double> verticalRange = new List<double>();
            double point = floor;

            verticalRange.Add(point);

            while (point < ceiling)
            {
                verticalRange.Add(Math.Round(point, 1));
                point += 0.1;
            }

            return verticalRange;
        }
    }
}
