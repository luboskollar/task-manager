using TaskManager.Enums;
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
    public bool Delete(int id)
    {
        var todo = GetById(id);
        if (todo != null)
        {
            _todoItems.Remove(todo);
            return true;
        }
        return false;
    }

    public bool Update(TodoItem updatedTodoItem)
    {
        int index = _todoItems.FindIndex(t => t.Id == updatedTodoItem.Id);
        if (index >= 0)
        {
            _todoItems[index] = updatedTodoItem;
            return true;
        }
        return false;
    }
    
    public IReadOnlyList<TodoItem> GetAll()
    {
        return _todoItems;
    }
    
    public TodoItem? GetById(int id)
    {
        return _todoItems.FirstOrDefault(t => t.Id == id);
    }

    public IReadOnlyList<TodoItem> GetByCategory(int categoryId)
    {
        return _todoItems.Where(t => t.CategoryId == categoryId).ToList();
    }

    public IReadOnlyList<TodoItem> GetByStatus(Status status)
    {
        return _todoItems.Where(t => t.Status == status).ToList();
    }

    public IReadOnlyList<TodoItem> GetByPriority(Priority priority)
    {
        return _todoItems.Where(t => t.Priority == priority).ToList();
    }

    public IReadOnlyList<TodoItem> GetOverdue()
    {
        return _todoItems.Where(t => t.DueDate < DateTime.Now && t.Status != Status.Completed).ToList();
    }

    public IReadOnlyList<TodoItem> GetSortedByDueDate()
    {
        return _todoItems.OrderBy(t => t.DueDate).ToList();
    }
}