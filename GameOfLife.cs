namespace GameOfLife;

public class GameOfLife(bool[,] universe)
{
    private readonly bool[,] _universe = universe;

    public void nextGen()
    {
        ;
    }

    public bool[,] GetUniverse()
    {
        return _universe;
    }
}