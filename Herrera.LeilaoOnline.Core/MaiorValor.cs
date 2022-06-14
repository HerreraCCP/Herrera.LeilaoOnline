namespace Herrera.LeilaoOnline.Core;

public class MaiorValor : IModalidadeAvaliacao
{
    public Lance Avalia(Leilao leilao) =>
        leilao.Lances
            .DefaultIfEmpty(new Lance(null, 0))
            .OrderBy(x => x.Valor)
            .LastOrDefault();
}