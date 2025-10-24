namespace GameOfLife;

public class GameOfLifeTest
{
    [Fact]
    public void Si_HayUnUniversoVacio_Debe_DarUnUniversoVacio()
    {
        //Arrange
        var universo = new bool[10,10];
        var game = new GameOfLife(universo);
        //Act
        game.nextGen();
        //Assert
        game.GetUniverse();
    }
}