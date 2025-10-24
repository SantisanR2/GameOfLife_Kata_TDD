namespace GameOfLife;

public class GameOfLife(bool[,] universe)
{
    private bool[,] _universe = universe;

    public void nextGen()
    {
        
        for (int row = 0; row < _universe.GetLength(0); row++)
        {
            for (int column = 0; column < _universe.GetLength(1); column++)
            {
                bool cell = _universe[row, column];
                if (cell)
                {
                    var numberOfAliveNeighbors = 0;
                    if (_universe[row - 1, column + 1])
                        numberOfAliveNeighbors++;
                    if (_universe[row, column + 1])
                        numberOfAliveNeighbors++;
                    if (_universe[row +1 , column + 1])
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
                    if (numberOfAliveNeighbors != 2)
                        _universe[row, column] = false;
                }
            }
        }
    }

    public bool[,] GetUniverse()
    {
        return _universe;
    }
}