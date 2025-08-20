using System;
using Perlin;

namespace Visualizer;

/// <summary>
/// Class <c>Perlin1DAnimator</c> handles Perlin noise animation. It only needs slope values.
/// </summary>
public class Perlin1DAnimator
{

    List<List<double>> slopeMultiplier = new List<List<double>>();

    private Perlin1D _perlin;

    public Perlin1DAnimator(Perlin1D perlin)
    {
        _perlin = perlin;
    }

    /// <summary>
    /// Animates the perlin noise function at a fixed resolution.
    /// </summary>
    public void Animate()
    {
        MapSlopeMultiplier();
        Step();
    }

    private void MapSlopeMultiplier()
    {
        for (int i = 0; i < _perlin!.perlinSlopeList.Count; i++)
        {
            slopeMultiplier.Add(new List<double>());
            for (int j = 0; j < _perlin.perlinSlopeList[i].Count; j++)
            {
                if (_perlin.perlinSlopeList[i][j] > 0)
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
        _perlin.IncrementSlopes(slopeMultiplier);
        _perlin.SamplePointsWithResolution(50);
        GraphGenerator.VisualiseGraph(_perlin);
        Thread.Sleep(100);
        Step();
    }

    private void ClearConsole()
    {
        Console.SetCursorPosition(0, 0);
        Console.CursorVisible = false;
    }
}
