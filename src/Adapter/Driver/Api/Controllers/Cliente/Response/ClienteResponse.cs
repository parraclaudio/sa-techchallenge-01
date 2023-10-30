namespace Api.Controllers.Cliente.Response;

public class ClienteResponse
{
    public string CPF { get;  set; }
    public string Nome { get;  set; }
    public string Email{ get;  set; }

    public ClienteResponse(string cpf, string nome, string email)
    {
        CPF = cpf;
        Nome = nome;
        Email = email;
    }
}