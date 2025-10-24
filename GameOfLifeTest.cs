using System.Collections;
using AwesomeAssertions;

namespace GameOfLife;

public class GameOfLifeTest
{
    [Fact]
    public void Si_HayUnUniversoVacio_Debe_DarUnUniversoVacio()
    {
        //Arrange
        var universe = new Cell[10, 10];
        var diedCell = DiedCell.GetInstance();
        foreach (var (row, column) in Enumerable.Range(0, 10).SelectMany(i => Enumerable.Range(0, 10).Select(j => (i, j))))
        {
            universe[row, column] = new Cell(diedCell);
        }
        var game = new GameOfLife(universe);
        //Act
        game.NextGen();
        //Assert
        game.GetUniverse().Should().BeEquivalentTo(universe);
    }

    [Fact]
    public void Si_HayUnaCelulaViva_Y_TieneMenosDeDosVecinos_Debe_Morir()
    {
        //Arrange
        var universe = new Cell[10, 10];
        var diedCell = DiedCell.GetInstance();
        foreach (var (row, column) in Enumerable.Range(0, 10).SelectMany(i => Enumerable.Range(0, 10).Select(j => (i, j))))
        {
            universe[row, column] = new Cell(diedCell);
        }
        universe[5, 5] = new Cell(LivingCell.GetInstance());
        var game = new GameOfLife(universe);
        //Act
        game.NextGen();
        //Assert
        game.GetUniverse()[5, 5].GetState().Should().Be(DiedCell.GetInstance());
    }

    [Theory]
    [ClassData(typeof(GameOfLifeTestDataSiHayUnaCelulaVivaYTieneDosOTresVecinosDebeVivir))]
    public void Si_HayUnaCelulaViva_Y_TieneDosOTresVecinos_Debe_Vivir(Cell[,] universe, int rowCell, int columnCell, ICellState expectedCellState)
    {
        //Arrange
        var game = new GameOfLife(universe);
        //Act
        game.NextGen();
        //Assert
        game.GetUniverse()[rowCell, columnCell].GetState().Should().Be(expectedCellState);
    }

    [Theory]
    [ClassData(typeof(GameOfLifeTestDataSiHayUnaCelulaMuertaYTieneTresVecinosDebeVivir))]
    public void Si_HayUnaCelulaMuerta_Y_TieneTresVecinos_Debe_Vivir(Cell[,] universe, int rowCell, int columnCell, ICellState expectedCellState)
    {
        //Arrange
        var game = new GameOfLife(universe);
        //Act
        game.NextGen();
        //Assert
        game.GetUniverse()[rowCell, columnCell].GetState().Should().Be(expectedCellState);
    }

    [Fact]
    public void Si_HayUnaCelulaViva_Y_TieneMasDeTresVecinos_Debe_Morir()
    {
        //Arrange
        var universe = new Cell[10, 10];
        var diedCell = DiedCell.GetInstance();
        foreach (var (row, column) in Enumerable.Range(0, 10).SelectMany(i => Enumerable.Range(0, 10).Select(j => (i, j))))
        {
            universe[row, column] = new Cell(diedCell);
        }
        universe[5, 5] = new Cell(LivingCell.GetInstance());
        universe[4, 5] = new Cell(LivingCell.GetInstance());
        universe[5, 6] = new Cell(LivingCell.GetInstance());
        universe[6, 6] = new Cell(LivingCell.GetInstance());
        universe[4, 4] = new Cell(LivingCell.GetInstance());
        var game = new GameOfLife(universe);
        //Act
        game.NextGen();
        //Assert
        game.GetUniverse()[5, 5].GetState().Should().Be(DiedCell.GetInstance());
    }
}

public class GameOfLifeTestDataSiHayUnaCelulaVivaYTieneDosOTresVecinosDebeVivir : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        var universe1 = new Cell[10,10];
        var diedCell = DiedCell.GetInstance();
        foreach (var (row, column) in Enumerable.Range(0, 10).SelectMany(i => Enumerable.Range(0, 10).Select(j => (i, j))))
        {
            universe1[row, column] = new Cell(diedCell);
        }
        universe1[5, 5] = new Cell(LivingCell.GetInstance());
        universe1[4, 5] = new Cell(LivingCell.GetInstance());
        universe1[5, 6] = new Cell(LivingCell.GetInstance());
        yield return [universe1, 5, 5, LivingCell.GetInstance()];

        var universe2 = new Cell[10, 10];
        foreach (var (row, column) in Enumerable.Range(0, 10).SelectMany(i => Enumerable.Range(0, 10).Select(j => (i, j))))
        {
            universe2[row, column] = new Cell(diedCell);
        }
        universe2[5, 5] = new Cell(LivingCell.GetInstance());
        universe2[5, 6] = new Cell(LivingCell.GetInstance());
        universe2[4, 5] = new Cell(LivingCell.GetInstance());
        universe2[6, 6] = new Cell(LivingCell.GetInstance());
        yield return [universe2, 5, 5, LivingCell.GetInstance()];
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class GameOfLifeTestDataSiHayUnaCelulaMuertaYTieneTresVecinosDebeVivir : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        var universe1 = new Cell[10,10];
        var diedCell = DiedCell.GetInstance();
        foreach (var (row, column) in Enumerable.Range(0, 10).SelectMany(i => Enumerable.Range(0, 10).Select(j => (i, j))))
        {
            universe1[row, column] = new Cell(diedCell);
        }
        universe1[4, 5] = new Cell(new LivingCell());
        universe1[5, 6] = new Cell(new LivingCell());
        universe1[6, 6] = new Cell(new LivingCell());
        yield return [universe1, 5, 5, LivingCell.GetInstance()];

        var universe2 = new Cell[10, 10];
        foreach (var (row, column) in Enumerable.Range(0, 10).SelectMany(i => Enumerable.Range(0, 10).Select(j => (i, j))))
        {
            universe2[row, column] = new Cell(diedCell);
        }
        universe2[5, 6] = new Cell(new LivingCell());
        universe2[5, 5] = new Cell(new LivingCell());
        universe2[6, 7] = new Cell(new LivingCell());
        yield return [universe2, 6, 6, LivingCell.GetInstance()];
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}