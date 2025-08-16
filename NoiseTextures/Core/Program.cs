using Perlin2D = Perlin.Perlin2D;
using Perlin1D = Perlin.Perlin1D;

public class Program
{
    static void Main(String[] args)
    {
        Perlin1D perlin1D = new Perlin1D();
        perlin1D.Generate1DPerlinInRange(6,2);
        perlin1D.SamplePointsWithResolution(45);
        
        
        //Visualizer.GraphGenerator.VisualiseGraph(perlin1D);
        
        
        /*
        Perlin2D perlin = new Perlin2D(10);
        perlin.RenderPermutationArray();
        perlin.RenderArray();
        */
    }
}