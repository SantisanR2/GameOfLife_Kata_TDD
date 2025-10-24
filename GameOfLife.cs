namespace GameOfLife;

public class GameOfLife(Cell[,] universe)
{
    private Cell[,] _universe = universe;

    private readonly int _widthUniverse = universe.GetLength(0);

    private readonly int _heightUniverse = universe.GetLength(1);
    

    public void NextGen()
    {
        var newUniverse = GameOfLifeTest.GenerateEmptyUniverse(_widthUniverse, _heightUniverse);
        
        foreach (var row in Enumerable.Range(0, _widthUniverse))
        {
            foreach (var column in Enumerable.Range(0, _heightUniverse))
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
        var numberOfAliveNeighbors = 0;
        
        for (var innerRow = -1; innerRow <= 1; innerRow++) {
            for (var innerColumn = -1; innerColumn <= 1; innerColumn++) {
                
                if (innerRow == 0 && innerColumn == 0) continue;
                
                var neighborRow = row + innerRow;
                var neighborColumn = column + innerColumn;
                
                if (neighborRow >= 0 && neighborRow < _widthUniverse &&
                    neighborColumn >= 0 && neighborColumn < _heightUniverse &&
                    _universe[neighborRow, neighborColumn].GetState() is LivingCell) {
                    numberOfAliveNeighbors++;
                }
            }
        }

        return numberOfAliveNeighbors;
    }

    public Cell[,] GetUniverse()
    {
        return _universe;
    }
}