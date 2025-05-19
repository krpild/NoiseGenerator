using PerlinNoise = Perlin.Perlin;

public class Program
{
    static void Main(String[] args)
    {
        PerlinNoise perlin = new PerlinNoise(20);
        perlin.PopulateArray();
        perlin.RenderArray();
    }
}