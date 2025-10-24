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
}