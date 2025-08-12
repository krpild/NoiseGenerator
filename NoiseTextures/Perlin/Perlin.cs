namespace Perlin;

public class Perlin
{
    private byte[,] _noise;

    private byte[,] _permutationTable;

    private short _imageSize;

    public short GetImageSize()
    {
        return _imageSize;
    }

    public Perlin(short imageSize)
    {
        _imageSize = imageSize;
        _noise = new byte[_imageSize, _imageSize];
    }

    public void PopulateArray()
    {
        for (int i = 0; i < _imageSize; i++)
        {
            for (int j = 0; j < _imageSize; j++)
            {
                _noise[i, j] = 0;
            }
        }
    }

    public byte[] RenderPermutationArray()
    {
        PermutationTable table = new PermutationTable();
        byte[] permTable = table.GeneratePermutationTable(1);
        //Here we actually work with any kind of array manipulation
        return permTable;
        /*
        for (int i = 0; i < permTable.Length; i++)
        {
            Console.WriteLine(i + " | " + permTable[i]);
        }
        */

    }

    public void RenderArray()
    {
        for (int i = 0; i < _imageSize; i++)
        {
            for (int j = 0; j < _imageSize; j++)
            {
                Console.Write(_noise[i,j]);
            }
            Console.Write("\n");
        }
    }
}