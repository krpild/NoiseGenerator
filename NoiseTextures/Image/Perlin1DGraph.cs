using Perlin;

namespace Visualizer
{
    public static class GraphGenerator
    {
        public static void VisualiseGraph(Perlin1D perlin)
        {

            string[,] drawing = BuildGraph(perlin);
            
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

        private static string[,] BuildGraph(Perlin1D perlin)
        {
            double ceiling = Math.Round(perlin.noise.Max() + 0.5, 1);
            double floor = Math.Round(perlin.noise.Min() - 0.5, 1);

            

            List<double> verticalRange = GetVerticalVisualisationRange(floor, ceiling);

            string[,] drawing = new string[verticalRange.Count, perlin.noise.Count];
            double position;
            string symbol;
            bool occupied;

            for (int x = 0; x < perlin.noise.Count; x++)
            {
                occupied = false;
                for (int y = verticalRange.Count - 1; y >= 0; y--)
                {
                    position = verticalRange[y];
                    if (Math.Round(perlin.noise[x], 1) == position)
                    {
                        occupied = !occupied;
                        symbol = "#";
                        if (perlin.noise[x] == 0) symbol = "@";
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
