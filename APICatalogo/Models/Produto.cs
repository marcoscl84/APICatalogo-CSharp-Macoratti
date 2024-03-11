using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APICatalogo.Models;

[Table("Produtos")]

public class Produto
{
    [Key]
    public int ProdutoId { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório!")]
    [StringLength(80, ErrorMessage = "O nome deve ter entre 5 e 80 caracteres.", MinimumLength = 5)]
    public string? Nome { get; set; }

    [Required]
    [StringLength(80, ErrorMessage = "A descrição deve ter no máximo {1} caracteres.")]
    public string? Descricao { get; set; }

    [Required]
    [Column(TypeName ="Decimal(10,2)")]
    public decimal Preco {  get; set; }

    [Required]
    [Range(10, 200, ErrorMessage = "A URL deve ter entre {1} e {2} caracteres.")]
    public string? ImageUrl { get; set; }
    public float Estoque { get; set; }
    public DateTime DataCadastro { get; set; }

    public int CategoriaId {  get; set; }

    // [JsonIgnore] // não exibe na serialização e desserialização
    public Categoria? Categoria { get; set; }

}
