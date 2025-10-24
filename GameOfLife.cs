namespace GameOfLife;

public class GameOfLife(bool[,] universe)
{
    private bool[,] _universe = universe;

    public void nextGen()
    {
        
        for (var row = 0; row < _universe.GetLength(0); row++)
        {
            for (var column = 0; column < _universe.GetLength(1); column++)
            {
                if (row == 5 && column == 5)
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
                    if (numberOfAliveNeighbors < 2 || numberOfAliveNeighbors > 3)
                        _universe[row, column] = false;
                    else
                        _universe[row, column] = true;
                }
            }
        }
    }

    public bool[,] GetUniverse()
    {
        return _universe;
    }
}