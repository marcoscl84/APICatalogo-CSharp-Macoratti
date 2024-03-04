using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers;

[Route("[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProdutosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Produto>> Get()
    {
        var produtos = _context.Produtos.ToList();
        if(produtos is null)
        {
            return NotFound("Produtos não encontrado");
        }
        return produtos;
    }

    [HttpGet("{id:int}", Name="ObterProduto")]
    public ActionResult<Produto> Get(int id)
    {
        var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);

        if(produto == null)
        {
            return NotFound("Produto não encontrado");
        }
        return produto;
    }

    [HttpPost]
    public ActionResult Post(Produto produto)
    {
        if(produto is null)
            return BadRequest();

        _context.Produtos.Add(produto);
        _context.SaveChanges();

        // retorna 201 e especifica a URI para acessar a rota do produto criado
        return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId }, produto);
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Produto produto)
    {
        if(id != produto.ProdutoId)
        {
            return BadRequest();
        }

        // informa ao contexto que a entidade do produto está em um estado modificado 
        _context.Entry(produto).State = EntityState.Modified;
        _context.SaveChanges();

        return Ok(produto);
    }
}
