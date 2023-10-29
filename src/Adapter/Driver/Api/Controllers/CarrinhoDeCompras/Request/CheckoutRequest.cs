using System.ComponentModel.DataAnnotations;

namespace Api.Controllers.CarrinhoDeCompras.Request;

public class CheckoutRequest
{
    [Required]
    public  string idCarrinhoDeCompras { get; set; }
}