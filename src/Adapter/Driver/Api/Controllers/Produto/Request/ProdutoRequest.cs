﻿using System.ComponentModel;
using Domain.ValueObjects;

namespace Api.Controllers.Produto.Request;

public class ProdutoRequest
{
    [DefaultValue("X-Egg")]
    public string Nome { get;  set; }
    [DefaultValue("Essa receita de hambúrguer com queijo e salada")]
    public string Descricao { get;  set; }
    [DefaultValue(CategoriaProdutoEnum.Lanche)]
    public CategoriaProdutoEnum Categoria { get;  set; }
    
    [DefaultValue(15.90)]
    public double Preco { get;  set; }
    [DefaultValue("x-egg")]
    public string Imagem { get;  set; }
}
