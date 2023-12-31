﻿using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;
using Infra.Context;
using Infra.Entities;
using MongoDB.Driver;

namespace Infra.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly AppDbContext _context;

    public ProdutoRepository(AppDbContext context)
    {
        _context = context;
    }


    public void Inserir(Produto produto)
    {
        ProdutoEntity produtoEntity = new ProdutoEntity
        {
            Nome = produto.Nome,
            Categoria = produto.Categoria,
            Descricao = produto.Descricao,
            Imagem = produto.Imagem,
            Preco = produto.Preco
        };
        
        _context.Produtos.InsertOne(produtoEntity);
    }

    public void Atualizar(Produto produto)
    {
        var dbProduto = _context.Produtos.Find(p => p.Nome == produto.Nome).FirstOrDefault();
        
        if (dbProduto is null)
        {
            throw new InvalidOperationException("Produto não esta cadastrado");
        }
        
        var produtoEntity = new ProdutoEntity
        {
            Id = dbProduto.Id,
            Nome = produto.Nome,
            Categoria = produto.Categoria,
            Descricao = produto.Descricao,
            Imagem = produto.Imagem,
            Preco = produto.Preco
        };
        
        _context.Produtos.FindOneAndReplace(p => p.Nome == produto.Nome , produtoEntity);
    }

    public void Deletar(string nome)
    {
        _context.Produtos.FindOneAndDelete(p => p.Nome == nome );
    }

    public IEnumerable<Produto> PesquisarProdutosPorCategoria(CategoriaProdutoEnum categoriaProdutoEnum)
    {
        var dbProdutos = _context.Produtos.Find(p => p.Categoria == categoriaProdutoEnum).ToList();

        return dbProdutos.Any()
            ? dbProdutos.Select(p => new Produto(p.Nome, p.Descricao, p.Categoria, p.Preco, p.Imagem))
            : new List<Produto>();

    }

    public Produto PesquisaProdutoPorNome(string nomeProduto)
    {
        var dbProduto = _context.Produtos.Find(p => p.Nome == nomeProduto).FirstOrDefault();

        return new Produto(dbProduto.Nome, dbProduto.Descricao, dbProduto.Categoria, dbProduto.Preco, dbProduto.Imagem);
    }
}