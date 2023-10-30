using System.ComponentModel;

namespace Api.Controllers.Cliente.Request;

public class ClienteRequest
{
    [DefaultValue("58669754088")]
    public string CPF { get;  set; }
    
    [DefaultValue("Western Cape")]
    public string Nome { get;  set; }
    
    [DefaultValue("WesternCape@hotmail.com")]
    public string Email{ get;  set; }
}
