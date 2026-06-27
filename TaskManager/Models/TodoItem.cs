using TaskManager.Enums;

namespace TaskManager.Models;

public class TodoItem
{
    public int Id { get; private set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime DueDate { get; set; }
    public DateTime CreatedAt { get; private set; }
    public int CategoryId { get; set; }
    public Priority Priority { get; set; }
    public Status Status { get; set; } = Status.Pending;
    public TodoItem(int id, string title, DateTime dueDate, int categoryId, Priority priority)
    {
        Id = id;
        Title = title;
        DueDate = dueDate;
        CreatedAt = DateTime.Now;
        CategoryId = categoryId;
        Priority = priority;
    }
}