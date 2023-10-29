using Domain.ValueObjects;
using Infra.Context;
using Infra.Entities;
using MongoDB.Driver;

namespace Infra.Config;

public class CreateData
{
    private readonly AppDbContext _context;

    public CreateData(AppDbContext context)
    {
        _context = context;
        IngestInDatabase();
    }

    private void IngestInDatabase()
    {
        var clienteEntity = new ClienteEntity()
        {
            CPF = "58669754088",
            Nome = "Western Cape",
            Email = "WesternCape@hotmail.com"
        };
        
        var produtoEntities = new List<ProdutoEntity>()
        {
            new()
            {
                Nome = "X-Duplo-Bacon",
                Categoria = CategoriaProdutoEnum.Lanche,
                Descricao =
                    "Dois hambúrgueres (100% carne bovina), queijo sabor cheddar, cebola, fatias de bacon, ketchup, mostarda e pão com gergelim.",
                Imagem = "x-duplo-bacon.png",
                Preco = 15.90
            },
            new()
            {
                Nome = "X-Bacon",
                Categoria = CategoriaProdutoEnum.Lanche,
                Descricao =
                    "Um Hamburguer (100% carne bovina), queijo sabor cheddar, cebola, fatias de bacon, ketchup, mostarda e pão com gergelim.",
                Imagem = "x-bacon.png",
                Preco = 13.90
            },
            new()
            {
                Nome = "X-Salada",
                Categoria = CategoriaProdutoEnum.Lanche,
                Descricao =
                    "Um Hamburguer (100% carne bovina), alface, cebola, picles, ketchup, mostarda e pão sem gergelim.",
                Imagem = "x-salada.png",
                Preco = 9.90
            },
            new()
            {
                Nome = "Batata Fritas",
                Categoria = CategoriaProdutoEnum.Acompanhamento,
                Descricao =
                    "A batata frita mais famosa do mundo. Deliciosas batatas selecionadas, fritas, crocantes por fora, macias por dentro, douradas, irresistíveis, saborosas, famosas, e todos os outros adjetivos positivos que você quiser dar.",
                Imagem = "batata-fritas.png",
                Preco = 7.90
            },
            new()
            {
                Nome = "Nuggets",
                Categoria = CategoriaProdutoEnum.Acompanhamento,
                Descricao = "4 Chicken McNuggets saborosos e crocantes de peito de frango.",
                Imagem = "nuggets.png",
                Preco = 5.90
            },
            new()
            {
                Nome = "Coca-Cola",
                Categoria = CategoriaProdutoEnum.Bebida,
                Descricao = "Coca Cola LATA 350ml.",
                Imagem = "Coca-Cola.png",
                Preco = 6.90
            },
            new()
            {
                Nome = "Fanta",
                Categoria = CategoriaProdutoEnum.Bebida,
                Descricao = "Fanta LATA 350ml.",
                Imagem = "fanta.png",
                Preco = 6.90
            },
            new()
            {
                Nome = "Sorvete",
                Categoria = CategoriaProdutoEnum.Sobremesa,
                Descricao = "Sorvete de casquinha sabor Baunilha ",
                Imagem = "fanta.png",
                Preco = 3.90
            },
            new()
            {
                Nome = "Trufa",
                Categoria = CategoriaProdutoEnum.Sobremesa,
                Descricao = "Trufa de chocolate com recheio sortido",
                Imagem = "trufa-chocolate.png",
                Preco = 2.90
            }
        };
        

        var carrinhoCompras = new CarrinhoDeComprasEntity()
            {
                IdCarrinhoDeCompras = "8767ac05-fbc3-487e-98f6-b1c6b88fa31c",
                CPF = clienteEntity.CPF,
                Status = StatusCarrinhoDeCompras.EmAberto,
                Produtos = produtoEntities
            };
        
        var upsert = new ReplaceOptions() { IsUpsert = true};
        var dbCliente = _context.Clientes.Find(c => c.CPF == clienteEntity.CPF);
        
        if (dbCliente.CountDocuments() > 0)
            clienteEntity.Id = dbCliente.FirstOrDefault().Id;
        
        _context.Clientes.ReplaceOne(c=> c.CPF == clienteEntity.CPF, clienteEntity, upsert) ;
        
        var dbCarrinho = _context.CarrinhoDeCompras.Find(c => c.CPF == clienteEntity.CPF);
        
        if (dbCarrinho.CountDocuments() > 0)
            carrinhoCompras.Id = dbCarrinho.FirstOrDefault().Id;
        
        _context.CarrinhoDeCompras.ReplaceOne(c=> c.CPF == clienteEntity.CPF, carrinhoCompras, upsert);

        foreach (var produtoEntity in produtoEntities)
        {
            var dbProduto = _context.Produtos.Find(p=> p.Nome == produtoEntity.Nome);

            if (dbProduto.CountDocuments() > 0)
                produtoEntity.Id = dbProduto.FirstOrDefault().Id;

            _context.Produtos.ReplaceOne(p=> p.Nome == produtoEntity.Nome, produtoEntity, upsert);
        }
    }
}