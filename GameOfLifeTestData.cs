using System.Collections;

namespace GameOfLife;

public class GameOfLifeTestData
{
    public class SiHayUnaCelulaVivaYTieneDosOTresVecinosDebeVivir : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            var universe1 = GameOfLifeTest.GenerateEmptyUniverse();
            universe1[5, 5] = new Cell(LivingCell.GetInstance());
            universe1[4, 5] = new Cell(LivingCell.GetInstance());
            universe1[5, 6] = new Cell(LivingCell.GetInstance());
            yield return [universe1, 5, 5, LivingCell.GetInstance()];

            var universe2 = GameOfLifeTest.GenerateEmptyUniverse();
            universe2[5, 5] = new Cell(LivingCell.GetInstance());
            universe2[5, 6] = new Cell(LivingCell.GetInstance());
            universe2[4, 5] = new Cell(LivingCell.GetInstance());
            universe2[6, 6] = new Cell(LivingCell.GetInstance());
            yield return [universe2, 5, 5, LivingCell.GetInstance()];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class SiHayUnaCelulaMuertaYTieneTresVecinosDebeVivir : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            var universe1 = GameOfLifeTest.GenerateEmptyUniverse();
            universe1[4, 5] = new Cell(LivingCell.GetInstance());
            universe1[5, 6] = new Cell(LivingCell.GetInstance());
            universe1[6, 6] = new Cell(LivingCell.GetInstance());
            yield return [universe1, 5, 5, LivingCell.GetInstance()];

            var universe2 = GameOfLifeTest.GenerateEmptyUniverse();
            universe2[5, 6] = new Cell(LivingCell.GetInstance());
            universe2[5, 5] = new Cell(LivingCell.GetInstance());
            universe2[6, 7] = new Cell(LivingCell.GetInstance());
            yield return [universe2, 6, 6, LivingCell.GetInstance()];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}