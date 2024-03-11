using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
    public async Task<ActionResult<IEnumerable<Produto>>> GetAsync()
    {
        return await _context.Produtos.AsNoTracking().ToListAsync();
    }

    [HttpGet("{id:int}", Name="ObterProduto")]
    public async Task<ActionResult<Produto>> GetAsync(int id, [BindRequired] string nome)
    {
        var nomeProduto = nome;
        var produto = await _context.Produtos.AsNoTracking().FirstOrDefaultAsync(p => p.ProdutoId == id);

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

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
        // var produto = _context.Produtos.Find(id);

        if (produto == null)
        {
            return NotFound("Produto não encontrado.");
        }

        _context.Produtos.Remove(produto);
        _context.SaveChanges();

        return Ok(produto);
    }
}
