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
                var cell = _universe[row, column];
                if (!cell) continue;
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

    public bool[,] GetUniverse()
    {
        return _universe;
    }
}