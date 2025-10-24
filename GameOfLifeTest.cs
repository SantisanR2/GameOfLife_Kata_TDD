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
        game.GetUniverse().Should().Be(universe);
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
        game.GetUniverse().Should().Be(new bool[10,10]);
    }
}