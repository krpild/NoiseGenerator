using Perlin1D = Perlin.Perlin1D;

public class Program
{
    static void Main(String[] args)
    {
        Perlin1D perlin1D = new Perlin1D();
        perlin1D.GenerateSlopeValuesInRange(5,4);
        perlin1D.SamplePointsWithResolution(45);
        Visualizer.GraphGenerator.VisualiseGraph(perlin1D);
        

    }
}