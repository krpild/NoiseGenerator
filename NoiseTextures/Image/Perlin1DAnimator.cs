using System;
using Perlin;

namespace Visualizer;

public class Perlin1DAnimator
{
    /*
    Should determine in the beginning which of the slopes are negative and positive. 
    If they reach an upper ceiling, their position multiplier changes.
    Could map a list with slopeValue multipliers and shove it in here.
    */

    List<List<double>> slopeMultiplier = new List<List<double>>();

    private Perlin1D perlin;

    public void Animate(Perlin1D function)
    {
        perlin = function;
        MapSlopeMultiplier();
        Step();
    }

    private void MapSlopeMultiplier()
    {
        for (int i = 0; i < perlin.perlinSlopeList.Count; i++)
        {
            slopeMultiplier.Add(new List<double>());
            for (int j = 0; j < perlin.perlinSlopeList[i].Count; j++)
            {
                if (perlin.perlinSlopeList[i][j] > 0)
                {
                    slopeMultiplier[i].Add(1);
                }
                else
                {
                    slopeMultiplier[i].Add(-1);
                }
            }
        }
    }

    private void Step()
    {
        ClearConsole();
        perlin.IncrementSlopes(slopeMultiplier);
        perlin.SamplePointsWithResolution(30);
        GraphGenerator.VisualiseGraph(perlin);
        Thread.Sleep(20);
        Step();
    }
    
    private void ClearConsole()
    {
        Console.SetCursorPosition(0, 0);
        Console.CursorVisible = false;
        
    }

}
