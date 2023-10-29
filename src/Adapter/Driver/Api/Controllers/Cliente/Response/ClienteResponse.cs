namespace Api.Controllers.Cliente.Response;

public class ClienteResponse
{
    public ClienteResponse(Domain.Entities.Cliente cliente)
    {
        CPF = cliente.CPF;
        Nome = cliente.Nome;
        Email = cliente.Email;
    }

    public string CPF { get;  private set; }
    public string Nome { get;  private set; }
    public string Email{ get;  private set; }
}