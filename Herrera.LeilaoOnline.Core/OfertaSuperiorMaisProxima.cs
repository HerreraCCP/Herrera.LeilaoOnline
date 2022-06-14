namespace Herrera.LeilaoOnline.Core;

public class OfertaSuperiorMaisProxima : IModalidadeAvaliacao
{
    private double ValorDestino { get; }

    public OfertaSuperiorMaisProxima(double valorDestino) => ValorDestino = valorDestino;

    public Lance Avalia(Leilao leilao) =>
        leilao
            .Lances
            .DefaultIfEmpty(new Lance(null, 0))
            .Where(x => x.Valor > ValorDestino)
            .OrderBy(x => x.Valor)
            .FirstOrDefault();
}