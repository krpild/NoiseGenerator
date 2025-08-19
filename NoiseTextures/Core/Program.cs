using Visualizer;
using Perlin1D = Perlin.Perlin1D;

public class Program
{
    static void Main(String[] args)
    {
        Perlin1D perlin1D = new Perlin1D();
        perlin1D.GenerateSlopeValuesInRange(5, 1);
        Perlin1DAnimator animator = new Perlin1DAnimator();
        animator.Animate(perlin1D);
    }
}