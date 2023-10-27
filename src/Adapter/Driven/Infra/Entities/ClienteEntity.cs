using Domain.ValueObjects;

namespace Infra.Entities;

public class ClienteEntity : BaseEntity
{
    public string CPF { get;  set; }
    public string Nome { get;  set; }
    public string Email{ get;  set; }
    
}