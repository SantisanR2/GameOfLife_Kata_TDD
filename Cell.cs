namespace GameOfLife;

public class Cell(ICellState initialState)
{
    public ICellState GetState()
    {
        return initialState;
    }
}