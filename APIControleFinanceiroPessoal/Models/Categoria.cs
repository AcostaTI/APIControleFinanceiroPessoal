using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIControleFinanceiroPessoal.Models;

[Table("Categorias")]
public class Categoria
{
    public Categoria()
    {
        Transacoes = new Collection<Transacao>();
    }

    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(20)]
    public string? Nome { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ICollection<Transacao>? Transacoes { get; set; }
}
