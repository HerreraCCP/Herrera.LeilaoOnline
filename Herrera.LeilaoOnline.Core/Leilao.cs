using Herrera.LeilaoOnline.Core.Enums;

namespace Herrera.LeilaoOnline.Core;

public class Leilao
{
    private Interessada _ultimoCliente;
    private IList<Lance> _lances;
    private readonly IModalidadeAvaliacao _avaliador;
    
    public IEnumerable<Lance> Lances => _lances;
    public string Peca { get; set; }
    public Lance Ganhador { get; private set; }
    public EstadoLeilao Estado { get; private set; }
    

    public Leilao(string peca, IModalidadeAvaliacao avaliador)
    {
        Peca = peca;
        Estado = EstadoLeilao.LeilaoAntesDoPregao;
        _lances = new List<Lance>();
        _avaliador = avaliador;
    }

    private bool NovoLanceAceito(Interessada cliente, double valor)
    {
        return (Estado == EstadoLeilao.LeilaoEmAndamento && cliente != _ultimoCliente);
    }

    public void RecebeLance(Interessada cliente, double valor)
    {
        if (!NovoLanceAceito(cliente, valor)) return;

        _lances.Add(new Lance(cliente, valor));
        _ultimoCliente = cliente;
    }

    public void IniciaPregao()
    {
        Estado = EstadoLeilao.LeilaoEmAndamento;
    }

    public void TerminaPregao()
    {
        if (Estado != EstadoLeilao.LeilaoEmAndamento)
            throw new InvalidOperationException("deu ruim...");

        Ganhador = _avaliador.Avalia(this);
        Estado = EstadoLeilao.LeilaoFinalizado;
    }
}