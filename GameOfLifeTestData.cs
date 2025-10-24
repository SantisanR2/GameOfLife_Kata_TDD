using System.Collections;

namespace GameOfLife;

public class GameOfLifeTestData
{
    public class SiHayUnaCelulaVivaYTieneDosOTresVecinosDebeVivir : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            var universe1 = GameOfLifeTest.GenerateEmptyUniverse(10, 10);
            universe1[5, 5] = new Cell(LivingCell.GetInstance());
            universe1[4, 5] = new Cell(LivingCell.GetInstance());
            universe1[5, 6] = new Cell(LivingCell.GetInstance());
            yield return [universe1, 5, 5, LivingCell.GetInstance()];

            var universe2 = GameOfLifeTest.GenerateEmptyUniverse(10, 10);
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
            var universe1 = GameOfLifeTest.GenerateEmptyUniverse(10, 10);
            universe1[4, 5] = new Cell(LivingCell.GetInstance());
            universe1[5, 6] = new Cell(LivingCell.GetInstance());
            universe1[6, 6] = new Cell(LivingCell.GetInstance());
            yield return [universe1, 5, 5, LivingCell.GetInstance()];

            var universe2 = GameOfLifeTest.GenerateEmptyUniverse(10, 10);
            universe2[5, 6] = new Cell(LivingCell.GetInstance());
            universe2[5, 5] = new Cell(LivingCell.GetInstance());
            universe2[6, 7] = new Cell(LivingCell.GetInstance());
            yield return [universe2, 6, 6, LivingCell.GetInstance()];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    
    public class SiHayCelulasVivasYTieneVecinosFueraDelUniversoDebeTomarEsosVecinosComoMuertos : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            var universe1 = GameOfLifeTest.GenerateEmptyUniverse(10, 10);
            universe1[0, 0] = new Cell(LivingCell.GetInstance());
            universe1[1, 0] = new Cell(LivingCell.GetInstance());
            universe1[0, 1] = new Cell(LivingCell.GetInstance());
            yield return [universe1, 0, 0, LivingCell.GetInstance()];

            var universe2 = GameOfLifeTest.GenerateEmptyUniverse(10, 10);
            universe2[9, 9] = new Cell(LivingCell.GetInstance());
            universe2[9, 8] = new Cell(LivingCell.GetInstance());
            yield return [universe2, 9, 9, DeadCell.GetInstance()];
            
            var universe3 = GameOfLifeTest.GenerateEmptyUniverse(10, 10);
            universe3[9, 5] = new Cell(LivingCell.GetInstance());
            universe3[8, 6] = new Cell(LivingCell.GetInstance());
            universe3[9, 4] = new Cell(LivingCell.GetInstance());
            universe3[9, 6] = new Cell(LivingCell.GetInstance());
            yield return [universe3, 9, 5, LivingCell.GetInstance()];
            
            var universe4 = GameOfLifeTest.GenerateEmptyUniverse(10, 10);
            universe4[5, 0] = new Cell(LivingCell.GetInstance());
            yield return [universe4, 5, 0, DeadCell.GetInstance()];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}