namespace GameOfLife;

public class GameOfLife(Cell[,] universe)
{
    private Cell[,] _universe = universe;

    public void NextGen()
    {
        var newUniverse = new Cell[_universe.GetLength(0), _universe.GetLength(1)];
        foreach (var (row, column) in Enumerable.Range(0, 10).SelectMany(i => Enumerable.Range(0, 10).Select(j => (i, j))))
        {
            newUniverse[row, column] = new Cell(DeadCell.GetInstance());
        }
        
        for (var row = 0; row < _universe.GetLength(0); row++)
        {
            for (var column = 0; column < _universe.GetLength(1); column++)
            {
                var numberOfAliveNeighbors = GetNumberOfAliveNeighbors(row, column);
                var nextState = _universe[row, column].GetState().NextState(numberOfAliveNeighbors);
                newUniverse[row, column] = new Cell(nextState);
            }
        }
        _universe = newUniverse;
    }

    private int GetNumberOfAliveNeighbors(int row, int column)
    {
        if (row - 1 < 0 || row + 1 > _universe.GetLength(0) - 1 || column - 1 < 0 ||
            column + 1 > _universe.GetLength(1) - 1)
        {
            return 0;
        }
        
        var numberOfAliveNeighbors = 0;
        
        if (_universe[row - 1, column + 1].GetState() is LivingCell)
            numberOfAliveNeighbors++;
        if (_universe[row, column + 1].GetState() is LivingCell)
            numberOfAliveNeighbors++;
        if (_universe[row + 1 , column + 1].GetState() is LivingCell)
            numberOfAliveNeighbors++;
        if (_universe[row - 1, column].GetState() is LivingCell)
            numberOfAliveNeighbors++;
        if (_universe[row + 1, column].GetState() is LivingCell)
            numberOfAliveNeighbors++;
        if (_universe[row - 1, column - 1].GetState() is LivingCell)
            numberOfAliveNeighbors++;
        if (_universe[row, column - 1].GetState() is LivingCell)
            numberOfAliveNeighbors++;
        if (_universe[row + 1, column - 1].GetState() is LivingCell)
            numberOfAliveNeighbors++;

        return numberOfAliveNeighbors;
    }

    public Cell[,] GetUniverse()
    {
        return _universe;
    }
}