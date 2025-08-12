using PerlinNoise = Perlin.Perlin;

public class Program
{
    static void Main(String[] args)
    {
        PerlinNoise perlin = new PerlinNoise(10);
        perlin.RenderPermutationArray();
        perlin.RenderArray();
    }
}