namespace Perlin;

public class Perlin
{
    private byte[,] _noise;

    private short _imageSize;

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