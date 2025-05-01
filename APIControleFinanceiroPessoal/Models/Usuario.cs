using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIControleFinanceiroPessoal.Models;

[Table("Usuarios")]
public class Usuario
{
    public Usuario()
    {
        Transacoes = new Collection<Transacao>();
    }

    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(200)]
    public string? Nome { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public DateTime DataNascimento { get; set; }
    [Required]
    [StringLength(80)]
    [EmailAddress]
    public string? email { get; set; }
    [Required]
    [StringLength(20)]
    public string? Senha { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public double Saldo { get; set; }

    public ICollection<Transacao>? Transacoes { get; set; }
}
