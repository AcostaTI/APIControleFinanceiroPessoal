using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIControleFinanceiroPessoal.Models;

[Table("Transacoes")]
public class Transacao
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(100)]
    public string? Nome { get; set; }
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public double Valor { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public DateTime Data { get; set; }
    [Required]
    [StringLength(1)]
    public string? Tipo { get; set; } // "Entrada 'E'" ou "Saída 'S'"
    [Required]
    public int UsuarioId { get; set; }
    [Required]
    public int CategoriaId { get; set; }

    [JsonIgnore]
    public Usuario? Usuario { get; set; }
    [JsonIgnore]
    public Categoria? Categoria { get; set; }
}