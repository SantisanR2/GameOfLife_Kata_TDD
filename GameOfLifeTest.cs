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

    [Fact]
    public void Si_HayUnaCelulaViva_Y_TieneDosOTresVecinos_Debe_Vivir()
    {
        //Arrange
        var universe = new bool[10,10];
        universe[5, 5] = true;
        universe[4, 5] = true;
        universe[5, 6] = true;
        var game = new GameOfLife(universe);
        //Act
        game.nextGen();
        //Assert
        game.GetUniverse()[5,5].Should().Be(true);
    }
}