namespace Domain.Entities;

public class FilaPedidos
{
    public long NumeroPedido { get; private set; }
    
    public int Prioridade { get; private set; }
    public DateTime ExpectativaFinalizacao { get; private set; }
    
    public TimeSpan TempoEspera => CalculaTempoEspera();

    public FilaPedidos(long numeroPedido, int prioridade)
    {
        NumeroPedido = numeroPedido;
        Prioridade = prioridade;
        ExpectativaFinalizacao = DateTime.Now.AddMinutes(10);
    }
    
    private TimeSpan CalculaTempoEspera()
    {
        return (DateTime.Now - ExpectativaFinalizacao).Duration();
    }
}