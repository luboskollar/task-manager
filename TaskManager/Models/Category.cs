namespace TaskManager.Models;

public class Category
{
    public int Id { get; private set; }
    public string Name { get; set; } = string.Empty;

    public Category(int id, string name)
    {
        Id = id;
        Name = name;
    }
}