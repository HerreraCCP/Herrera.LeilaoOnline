namespace Herrera.LeilaoOnline.Core
{
    public class Lance
    {
        public Interessada Cliente { get; }
        public double Valor { get; }

        public Lance(Interessada cliente, double valor)
        {
            if (valor < 0) throw new ArgumentException("Deu ruim!");

            Cliente = cliente;
            Valor = valor;
        }
    }
}