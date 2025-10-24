namespace GameOfLife;

public interface ICellState
{
    ICellState NextState(int numberOfAliveNeighbors);
}

public class LivingCell : ICellState
{
    private static readonly LivingCell Instance = new LivingCell();

    public static LivingCell GetInstance() => Instance;
    
    public ICellState NextState(int numberOfAliveNeighbors)
    {
        return numberOfAliveNeighbors is < 2 or > 3 ? DiedCell.GetInstance() : this;
    }
}

public class DiedCell : ICellState
{
    private static readonly DiedCell Instance = new DiedCell();

    public static DiedCell GetInstance() => Instance;
    
    public ICellState NextState(int numberOfAliveNeighbors)
    {
        return numberOfAliveNeighbors == 3 ? LivingCell.GetInstance() : this;
    }
}