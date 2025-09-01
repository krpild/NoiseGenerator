using Visualizer;
using Perlin1D = Perlin.Perlin1D;
using Perlin2D = Perlin.Perlin2D;

public class Program
{
    static void Main(String[] args)
    {
        /*
        Perlin1D perlin1D = new Perlin1D();
        perlin1D.GenerateSlopeValuesInRange(5, 1); // determine amount of integer points the function intersects with and how many octaves you want to use.
        /*
        perlin1D.SamplePointsWithResolution(5); // How many points between any two integer points you want to see.
        GraphGenerator.VisualiseGraph(perlin1D); // Display the graph
        */

        //If you want an animated function
        /*
        Perlin1DAnimator animator = new Perlin1DAnimator(perlin1D);
        animator.Animate(); // This will run indefinitely
        */

        Perlin2D perlin2D = new Perlin2D();

        perlin2D.GenerateRandomUnitVectorsInRange(4, 4);


    }
}