namespace GameOfLife;

public class GameOfLife(bool[,] universe)
{
    private bool[,] _universe = universe;

    public void nextGen()
    {
        _universe = new bool[10,10];
    }

    public bool[,] GetUniverse()
    {
        return _universe;
    }
}