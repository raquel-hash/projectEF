namespace projectEF.Models;
public class Task
{
    public Guid Id { get; set; }
    public Guid CategoriaId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Priority PriorityTask { get; set; }
    public DateTime CreateDate { get; set; }

    public virtual Category Category { get; set; }
}

public enum Priority
{
    Baja,
    Media,
    Alta
}
