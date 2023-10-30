using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Api.Controllers.CarrinhoDeCompras.Request;


public class CarrinhoDeComprasRequest
{
    [Required]
    [DefaultValue("Totem01")]
    public string IdAtendimento { get; set; }
    
    [Required]
    [DefaultValue("X-Bacon")]
    public string NomeProduto { get; set; }
    
    [DefaultValue("58669754088")]
    public string? CPF { get; set; }
}