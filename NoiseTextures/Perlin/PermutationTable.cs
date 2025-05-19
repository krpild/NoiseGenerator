using System.CodeDom.Compiler;

namespace Perlin;

public class PermutationTable
{

    private byte[] _table = new byte[256];
    
    public byte[] GeneratePermutationTable(int seed)
    {
        PopulateTable();
        ShuffleTable(seed);

        return _table;
    }

    private void PopulateTable()
    {
        byte num = 0;
        for (int i = 0; i < _table.Length; i++)
        {
            _table[i] = num;
            num++;
        }
    }

    private void ShuffleTable(int seed) // Using modern Fisher-Yates shuffle
    {
        var rnd = new Random(seed);
        
        byte val;
        int num;
        for (int i = 255; i > 0; i--)
        {
            num = rnd.Next(0, i + 1);
            val = _table[i];
            _table[i] = _table[num];
            _table[num] = val;
        }
    }
}