using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;
using Infra.Context;
using Infra.Entities;
using MongoDB.Driver;

namespace Infra.Repositories;

public class CarrinhoDeComprasRepository : ICarrinhoDeComprasRepository
{
    private readonly AppDbContext _context;
    private readonly IClienteRepository _clienteRepository;

    public CarrinhoDeComprasRepository(AppDbContext context, IClienteRepository clienteRepository)
    {
        _context = context;
        _clienteRepository = clienteRepository;
    }

    public CarrinhoDeCompras? Atualizar(CarrinhoDeCompras carrinhoDeCompras)
    {
                
        var produtos = carrinhoDeCompras.Produtos.Select(p => new ProdutoEntity()
        {
            Nome = p.Nome,
            Categoria = p.Categoria,
            Descricao = p.Descricao,
            Imagem = p.Imagem,
            Preco = p.Preco
        }).ToList();
        
        var ordemPagamento = new OrdemPagamentoEntity()
        {
            StatusPagamento = carrinhoDeCompras.OrdemDePagamento.StatusPagamento,
            DataCriacao =   carrinhoDeCompras.OrdemDePagamento.DataCriacao,
            DataPagamento =carrinhoDeCompras.OrdemDePagamento.DataPagamento,
            ValorPago = carrinhoDeCompras.OrdemDePagamento.ValorPago,
            ValorTotal = carrinhoDeCompras.OrdemDePagamento.ValorTotal
        };
        
        var carrinhosDeComprasEntity = new CarrinhoDeComprasEntity()
        {
            IdCarrinhoDeCompras = carrinhoDeCompras.IdCarrinhoDeCompras,
            CPF = carrinhoDeCompras.CPF,
            OrdemDePagamento = ordemPagamento,
            Produtos = produtos,
            Status = carrinhoDeCompras.Status
        };
        
        var dbCarrinho = _context.CarrinhoDeCompras.Find(c=> Equals(c.CPF, carrinhoDeCompras.CPF) &&
                                                             c.Status == StatusCarrinhoDeCompras.EmAberto);
        
        var upsert = new ReplaceOptions() { IsUpsert = true};
        if (dbCarrinho.CountDocuments() > 0)
            carrinhosDeComprasEntity.Id = dbCarrinho.FirstOrDefault().Id;
        
        var result = _context.CarrinhoDeCompras.ReplaceOne(p=> p.Id == carrinhosDeComprasEntity.Id , carrinhosDeComprasEntity, upsert);

        return carrinhoDeCompras;
    }

    public CarrinhoDeCompras? BuscarCarrinhoDeComprasPorId(string? id)
    {
        var findCarrinho =  _context.CarrinhoDeCompras.Find(c=> Equals(c.Id,id) &&
                                                                c.Status == StatusCarrinhoDeCompras.EmAberto);

        if (findCarrinho.CountDocuments() == 0)
        {
            return null;
        }

        var dbCarrinho = findCarrinho.FirstOrDefault();
        var produtos = dbCarrinho.Produtos.Select(p => new Produto(p.Nome, p.Descricao, p.Categoria, p.Preco, p.Imagem)).ToList();

        if (dbCarrinho.OrdemDePagamento is not null)
        {
            var ordemPagamento = new OrdemDePagamento(dbCarrinho.OrdemDePagamento.StatusPagamento,
                dbCarrinho.OrdemDePagamento.DataCriacao,
                dbCarrinho.OrdemDePagamento.DataPagamento,
                dbCarrinho.OrdemDePagamento.ValorTotal,
                dbCarrinho.OrdemDePagamento.ValorPago);

            return new CarrinhoDeCompras(dbCarrinho.IdCarrinhoDeCompras, produtos, ordemPagamento, dbCarrinho.CPF);
        }
        
        return new CarrinhoDeCompras(dbCarrinho.IdCarrinhoDeCompras,produtos, null, dbCarrinho.CPF);
    }
    
    public CarrinhoDeCompras? BuscarCarrinhoDeComprasPorIdCarrinhoDeCompras(string? idCarrinhoDeCompras)
    {
        var findCarrinho =  _context.CarrinhoDeCompras.Find(c=> Equals(c.IdCarrinhoDeCompras,idCarrinhoDeCompras) &&
                                                                c.Status == StatusCarrinhoDeCompras.EmAberto);

        if (findCarrinho.CountDocuments() == 0)
        {
            return null;
        }

        var dbCarrinho = findCarrinho.FirstOrDefault();
        var produtos = dbCarrinho.Produtos.Select(p => new Produto(p.Nome, p.Descricao, p.Categoria, p.Preco, p.Imagem)).ToList();

        if (dbCarrinho.OrdemDePagamento is not null)
        {
            var ordemPagamento = new OrdemDePagamento(dbCarrinho.OrdemDePagamento.StatusPagamento,
                dbCarrinho.OrdemDePagamento.DataCriacao,
                dbCarrinho.OrdemDePagamento.DataPagamento,
                dbCarrinho.OrdemDePagamento.ValorTotal,
                dbCarrinho.OrdemDePagamento.ValorPago);

            return new CarrinhoDeCompras(dbCarrinho.IdCarrinhoDeCompras, produtos, ordemPagamento, dbCarrinho.CPF);
        }
        
        return new CarrinhoDeCompras(dbCarrinho.IdCarrinhoDeCompras,produtos, null, dbCarrinho.CPF);
    }

    
    public CarrinhoDeCompras? BuscarCarrinhoDeComprasPorCpf(string cpf)
    {
      var findCarrinho =  _context.CarrinhoDeCompras.Find(c=> Equals(c.CPF,cpf) &&
                                            c.Status == StatusCarrinhoDeCompras.EmAberto);

      if (findCarrinho.CountDocuments() == 0)
      {
          return null;
      }

      var dbCarrinho = findCarrinho.FirstOrDefault();
      var produtos = dbCarrinho.Produtos.Select(p => new Produto(p.Nome, p.Descricao, p.Categoria, p.Preco, p.Imagem)).ToList();

      if (dbCarrinho.OrdemDePagamento is not null)
      {
          var ordemPagamento = new OrdemDePagamento(dbCarrinho.OrdemDePagamento.StatusPagamento,
              dbCarrinho.OrdemDePagamento.DataCriacao,
              dbCarrinho.OrdemDePagamento.DataPagamento,
              dbCarrinho.OrdemDePagamento.ValorTotal,
              dbCarrinho.OrdemDePagamento.ValorPago);
          return new CarrinhoDeCompras(dbCarrinho.IdCarrinhoDeCompras,produtos,ordemPagamento,dbCarrinho.CPF);    
      }
      return new CarrinhoDeCompras(dbCarrinho.IdCarrinhoDeCompras,produtos,null,dbCarrinho.CPF);
    }
}