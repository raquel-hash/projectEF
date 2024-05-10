using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectEF.Models;
public class Task
{
    [Key]
    public Guid Id { get; set; }
    [ForeignKey("CategoriaId")]
    public Guid CategoriaId { get; set; }
    [Required]
    [MaxLength(200)]
    public string Title { get; set; }
    public string Description { get; set; }
    public Priority PriorityTask { get; set; }
    public DateTime CreateDate { get; set; }
    public virtual Category Category { get; set; }
    [NotMapped]
    public string Resume { get; set; }
}

public enum Priority
{
    Baja,
    Media,
    Alta
}
