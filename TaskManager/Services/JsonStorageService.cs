using System.Text.Json;
using TaskManager.Models;

namespace TaskManager.Services;

public class JsonStorageService
{
    private const string FileName = "todos.json";
    
    public void Save(List<TodoItem> todoItems)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        File.WriteAllText(FileName, JsonSerializer.Serialize(todoItems, options));
    }

    public List<TodoItem> Load()
    {
        if (File.Exists(FileName))
        {
            return JsonSerializer.Deserialize<List<TodoItem>>(File.ReadAllText(FileName)) ?? new List<TodoItem>();
        }
        return new List<TodoItem>();
    }
}