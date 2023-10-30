using Domain.Entities;
using Domain.Repositories;
using Domain.Services;

namespace Application.Services;

public class CarrinhoDeComprasService : ICarrinhoDeComprasService
{
    private readonly ICarrinhoDeComprasRepository _repository;
    private readonly IClienteService _clienteService;
    private readonly IProdutoService _produtoService;
    private readonly IPedidoService _pedidoService;

    public CarrinhoDeComprasService(ICarrinhoDeComprasRepository repository, IClienteService clienteService, IProdutoService produtoService, IPedidoService pedidoService)
    {
        _repository = repository;
        _clienteService = clienteService;
        _produtoService = produtoService;
        _pedidoService = pedidoService;
    }

    public CarrinhoDeCompras? AdicionarProduto(string idAtendimento, string NomeProduto, string? cpf = null)
    {
        var dbCarrinho = new CarrinhoDeCompras(idAtendimento);
        
        if (!string.IsNullOrEmpty(cpf))
        {
            dbCarrinho = _repository.BuscarCarrinhoDeComprasPorCpf(cpf);
            
            if (dbCarrinho is null)
            {
                var dbCliente = _clienteService.PesquisarClientePorCpf(cpf);
                if (dbCliente is null)
                {
                    throw new InvalidOperationException("Cliente não encontrado");
                };
                dbCarrinho = new CarrinhoDeCompras(idAtendimento, cpf);
            }
        }

        var dbProduto = _produtoService.BuscarProdutoPorNome(NomeProduto);
        if (dbProduto is null)
        {
            throw new InvalidOperationException("Produto não encontrado");
        };
        
        dbCarrinho.Produtos.Add(dbProduto);
        
       return  _repository.Atualizar(dbCarrinho);
    }

    public void RemoverProduto(string idCarrinhoCompras, Produto produto)
    {
        throw new NotImplementedException();
    }
    
    
    public CarrinhoDeCompras? ExecutarCheckout(string idCarrinhoCompras)
    {
        var dbCarrinho = _repository.BuscarCarrinhoDeComprasPorIdCarrinhoDeCompras(idCarrinhoCompras);
        
        dbCarrinho.ExecuteCheckout();

        var numeroPedido =  _pedidoService.GerarPedido(dbCarrinho);
        dbCarrinho.SetNumeroPedido(numeroPedido);
        
        return  _repository.Atualizar(dbCarrinho);
    }

    public CarrinhoDeCompras BuscarCarrinhoDeComprasPorCpf(string cpf)
    {
        var dbCarrinho = _repository.BuscarCarrinhoDeComprasPorCpf(cpf);
        if (dbCarrinho is null)
            throw new InvalidOperationException("Carrinho não encontrado");
        
        return dbCarrinho;
    }
}