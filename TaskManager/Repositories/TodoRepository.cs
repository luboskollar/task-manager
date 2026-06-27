using TaskManager.Models;

namespace TaskManager.Repositories;

public class TodoRepository
{
    private List<TodoItem> _todoItems = new();
    private int _nextId = 1;
    
    public void Add(TodoItem todoItem)
    {
        _todoItems.Add(todoItem);
    }

    public IReadOnlyList<TodoItem> GetAll()
    {
        return _todoItems;
    }
    
    public TodoItem? GetById(int id)
    {
        return _todoItems.FirstOrDefault(t => t.Id == id);
    }
}