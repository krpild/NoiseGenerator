using System.CodeDom.Compiler;

namespace Perlin
{
    public class PermutationTable
    {

        private byte[] _table = new byte[256];
    
        public byte[] GeneratePermutationTable(int seed)
        {
            PopulateTable();
            ShuffleTable(seed);
            byte[] result = new byte[512];
            for (int i = 0; i < _table.Length; i++)
            {
                result[i] = _table[i];
                result[i + 256] = _table[i];
            }

            return result;
        }

        private void PopulateTable()
        {
            byte index = 0;
            for (int i = 0; i < _table.Length; i++)
            {
                _table[i] = index;
                index++;
            }
        }

        private void ShuffleTable(int seed) // Using modern Fisher-Yates shuffle
        {
            var rnd = new Random(seed);
        
            byte val;
            int index;
            for (int i = 255; i > 0; i--)
            {
                index = rnd.Next(0, i + 1);
                val = _table[i];
                _table[i] = _table[index];
                _table[index] = val;
            }
        }
    }
}