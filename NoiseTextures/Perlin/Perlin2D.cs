using System;
using System.Globalization;
using System.Numerics;

namespace Perlin;

public class Perlin2D
{
    List<Vector2> preparedGradientList = new List<Vector2>
    { new Vector2(1,1), new Vector2(-1,1), new Vector2(1,-1), new Vector2(-1,-1),
    new Vector2((float)Math.Pow(2,0.5), 0), new Vector2(0, (float)Math.Pow(2,0.5)), new Vector2((float)-Math.Pow(2,0.5), 0), new Vector2(0, -(float)Math.Pow(2,0.5))}; //List of vectors pointing in 8 cardinal directions.

    List<List<Vector2>> slopeList = new List<List<Vector2>>();

    Random randomizer = new Random();

    public void GenerateRandomUnitVectorsInRange(int height, int width)
    {
        //We have a 2D matrix of Vector2 structs.
        //Console.WriteLine(preparedGradientList.Count);

        for (int i = 0; i < height; i++)
        {
            slopeList.Add(new List<Vector2>());
            for (int j = 0; j < width; j++)
            {
                int gradientIndex = randomizer.Next(0, preparedGradientList.Count);
                slopeList[i].Add(preparedGradientList[gradientIndex]);
                Console.Write(slopeList[i][j]);
            }
            Console.Write("\n");
        }
    }

    private double SmoothStep(double x)
    {
        return 6 * Math.Pow(x, 5) - 15 * Math.Pow(x, 4) + 10 * Math.Pow(x, 3);
    }
    


}
