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
}