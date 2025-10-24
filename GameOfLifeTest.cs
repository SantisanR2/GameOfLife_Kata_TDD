using System.Collections;
using AwesomeAssertions;

namespace GameOfLife;

public class GameOfLifeTest
{
    [Fact]
    public void Si_HayUnUniversoVacio_Debe_DarUnUniversoVacio()
    {
        //Arrange
        var universe = new bool[10,10];
        var game = new GameOfLife(universe);
        //Act
        game.nextGen();
        //Assert
        game.GetUniverse().Should().BeEquivalentTo(universe);
    }

    [Fact]
    public void Si_HayUnaCelulaViva_Y_TieneMenosDeDosVecinos_Debe_Morir()
    {
        //Arrange
        var universe = new bool[10, 10];
        universe[5, 5] = true;
        var game = new GameOfLife(universe);
        //Act
        game.nextGen();
        //Assert
        game.GetUniverse().Should().BeEquivalentTo(new bool[10,10]);
    }

    [Theory]
    [ClassData(typeof(GameOfLifeTestData))]
    public void Si_HayUnaCelulaViva_Y_TieneDosOTresVecinos_Debe_Vivir(bool[,] universe, int rowCell, int columnCell, bool expectedOutcomeCell)
    {
        //Arrange
        var game = new GameOfLife(universe);
        //Act
        game.nextGen();
        //Assert
        game.GetUniverse()[rowCell, columnCell].Should().Be(expectedOutcomeCell);
    }

    [Fact]
    public void Si_HayUnaCelulaMuerta_Y_TieneTresVecinos_Debe_Vivir()
    {
        //Arrange
        var universe = new bool[10, 10];
        universe[4, 5] = true;
        universe[5, 6] = true;
        universe[6, 6] = true;
        var game = new GameOfLife(universe);
        //Act
        game.nextGen();
        //Assert
        game.GetUniverse()[5, 5].Should().Be(true);
    }

    [Fact]
    public void Si_HayUnaCelulaViva_Y_TieneMasDeTresVecinos_Debe_Morir()
    {
        //Arrange
        var universe = new bool[10, 10];
        universe[5, 5] = true;
        universe[4, 5] = true;
        universe[5, 6] = true;
        universe[6, 6] = true;
        universe[4, 4] = true;
        var game = new GameOfLife(universe);
        //Act
        game.nextGen();
        //Assert
        game.GetUniverse()[5, 5].Should().Be(false);
    }
}

public class GameOfLifeTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        var universe1 = new bool[10,10];
        universe1[5, 5] = true;
        universe1[4, 5] = true;
        universe1[5, 6] = true;
        yield return [universe1, 5, 5, true];

        var universe2 = new bool[10, 10];
        universe2[5, 5] = true;
        universe2[5, 6] = true;
        universe2[4, 5] = true;
        universe2[6, 6] = true;
        yield return [universe2, 5, 5, true];
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}