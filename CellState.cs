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
        return numberOfAliveNeighbors is < 2 or > 3 ? DeadCell.GetInstance() : this;
    }
}

public class DeadCell : ICellState
{
    private static readonly DeadCell Instance = new DeadCell();

    public static DeadCell GetInstance() => Instance;
    
    public ICellState NextState(int numberOfAliveNeighbors)
    {
        return numberOfAliveNeighbors == 3 ? LivingCell.GetInstance() : this;
    }
}