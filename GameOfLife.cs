namespace GameOfLife;

public class GameOfLife(bool[,] universe)
{
    private bool[,] _universe = universe;

    public void nextGen()
    {
        var NewUniverse = new bool[_universe.GetLength(0), _universe.GetLength(1)];
        for (var row = 0; row < _universe.GetLength(0); row++)
        {
            for (var column = 0; column < _universe.GetLength(1); column++)
            {
                if (row - 1 >= 0 && row + 1 <= _universe.GetLength(0) - 1 && column - 1 >= 0 && column + 1 <= _universe.GetLength(1) - 1)
                {
                    var numberOfAliveNeighbors = 0;
                    if (_universe[row - 1, column + 1])
                        numberOfAliveNeighbors++;
                    if (_universe[row, column + 1])
                        numberOfAliveNeighbors++;
                    if (_universe[row + 1 , column + 1])
                        numberOfAliveNeighbors++;
                    if (_universe[row - 1, column])
                        numberOfAliveNeighbors++;
                    if (_universe[row + 1, column])
                        numberOfAliveNeighbors++;
                    if (_universe[row - 1, column - 1])
                        numberOfAliveNeighbors++;
                    if (_universe[row, column - 1])
                        numberOfAliveNeighbors++;
                    if (_universe[row + 1, column - 1])
                        numberOfAliveNeighbors++;
                    if (numberOfAliveNeighbors is < 2 or > 3)
                        NewUniverse[row, column] = false;
                    else
                        NewUniverse[row, column] = true;
                }
            }
        }

        _universe = NewUniverse;
    }

    public bool[,] GetUniverse()
    {
        return _universe;
    }
}