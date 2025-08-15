using Perlin2D = Perlin.Perlin2D;
using Perlin1D = Perlin.Perlin1D;

public class Program
{
    static void Main(String[] args)
    {
        Perlin1D perlin1D = new Perlin1D();
        perlin1D.Generate1DPerlinInRange(10);
        perlin1D.SamplePointsWithFrequency(25);
        Visualizer.GraphGenerator.VisualiseGraph(perlin1D);
        
        
        /*
        Perlin2D perlin = new Perlin2D(10);
        perlin.RenderPermutationArray();
        perlin.RenderArray();
        */
    }
}