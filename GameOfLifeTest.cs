using System.Collections;
using AwesomeAssertions;

namespace GameOfLife;

public class GameOfLifeTest
{
    public static Cell[,] GenerateEmptyUniverse()
    {
        var universe = new Cell[10, 10];
        var diedCell = DiedCell.GetInstance();
        foreach (var (row, column) in Enumerable.Range(0, 10).SelectMany(i => Enumerable.Range(0, 10).Select(j => (i, j))))
        {
            universe[row, column] = new Cell(diedCell);
        }

        return universe;
    }
    
    [Fact]
    public void Si_HayUnUniversoVacio_Debe_DarUnUniversoVacio()
    {
        //Arrange
        var universe = GenerateEmptyUniverse();
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
        var universe = GenerateEmptyUniverse();
        universe[5, 5] = new Cell(LivingCell.GetInstance());
        var game = new GameOfLife(universe);
        //Act
        game.NextGen();
        //Assert
        game.GetUniverse()[5, 5].GetState().Should().Be(DiedCell.GetInstance());
    }

    [Theory]
    [ClassData(typeof(GameOfLifeTestData.SiHayUnaCelulaVivaYTieneDosOTresVecinosDebeVivir))]
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
    [ClassData(typeof(GameOfLifeTestData.SiHayUnaCelulaMuertaYTieneTresVecinosDebeVivir))]
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
        var universe = GenerateEmptyUniverse();
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