using System.ComponentModel.DataAnnotations;

namespace Api.Controllers.CarrinhoDeCompras.Request;

public class CarrinhoDeComprasRequest
{
    [Required]
    public string NomeProduto { get; set; }
    public string? CPF { get; set; }
}