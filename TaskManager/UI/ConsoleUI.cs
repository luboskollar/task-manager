using TaskManager.Enums;
using TaskManager.Models;
using TaskManager.Repositories;
using TaskManager.Services;

namespace TaskManager.UI;

public class ConsoleUI
{
    private TodoRepository _todoRepository;
    private JsonStorageService _jsonStorageService;
    
    public ConsoleUI(TodoRepository todoRepository, JsonStorageService jsonStorageService)
    {
        _todoRepository = todoRepository;
        _jsonStorageService = jsonStorageService;
    }
    
    public void Run()
    {
        List<TodoItem> todoItems = _jsonStorageService.Load();
        foreach (var t in todoItems)
        {
            _todoRepository.Add(t);
        }
        _todoRepository.SetNextId(todoItems.Count + 1);

        while (true)
        {
            ShowMainMenu();
            int number;
            if (int.TryParse(Console.ReadLine(), out number))
            {
                switch (number)
                {
                    case 1:
                        ShowAllTasks();
                        break;
                    case 2:
                    {
                        Console.WriteLine("Enter task name:");
                        string name = Console.ReadLine();
                        PriorityMenu();
                        int priorityNumber;
                        int.TryParse(Console.ReadLine(), out priorityNumber);
                        Priority priority = (Priority)priorityNumber;
                        Console.WriteLine("Enter a Due date (format dd.MM.yyyy):");
                        string dueDate = Console.ReadLine();
                        _todoRepository.Add(new TodoItem(_todoRepository.GetNextId(), name,
                            DateTime.ParseExact(dueDate, "dd.MM.yyyy", null), priority));
                        _jsonStorageService.Save(_todoRepository.GetAll());
                        break;
                    }
                    case 3:
                        ShowAllTasks();
                        Console.WriteLine();
                        Console.WriteLine("Enter an Id of the task you want to delete");
                        int id;
                        int.TryParse(Console.ReadLine(), out id);
                        _todoRepository.Delete(id);
                        _jsonStorageService.Save(_todoRepository.GetAll());
                        break;
                    case 4:
                    {
                        ShowAllTasks();
                        Console.WriteLine();
                        Console.WriteLine("Enter an Id of the task you want to update");
                        int taskId;
                        int.TryParse(Console.ReadLine(), out taskId);
                        StatusMenu();
                        int statusNumber;
                        int.TryParse(Console.ReadLine(), out statusNumber);
                        Status status = (Status)statusNumber;
                        var todo = _todoRepository.GetById(taskId);
                        if (todo != null)
                        {
                            todo.Status = status;
                            _todoRepository.Update(todo);
                            _jsonStorageService.Save(_todoRepository.GetAll());
                        }

                        break;
                    }
                    case 5:
                    {
                        IReadOnlyList<TodoItem> filteredList = new List<TodoItem>();
                        Console.WriteLine();
                        Console.WriteLine("How do you want to sort tasks");
                        Console.WriteLine("1. By status");
                        Console.WriteLine("2. By priority");
                        Console.WriteLine("3. Overdue tasks");
                        int filter;
                        if (int.TryParse(Console.ReadLine(), out filter))
                        {
                            switch (filter)
                            {
                                case 1:
                                    StatusMenu();
                                    int statusNumber;
                                    int.TryParse(Console.ReadLine(), out statusNumber);
                                    Status status = (Status)statusNumber;
                                    filteredList = _todoRepository.GetByStatus(status);
                                    break;
                                case 2:
                                    PriorityMenu();
                                    int priorityNumber;
                                    int.TryParse(Console.ReadLine(), out priorityNumber);
                                    Priority priority = (Priority)priorityNumber;
                                    filteredList = _todoRepository.GetByPriority(priority);
                                    break;
                                case 3:
                                    filteredList = _todoRepository.GetOverdue();
                                    break;
                            }
                        }
                        ShowAllTasks(filteredList);
                        break;
                    }
                    case 0:
                        return;
                }
            }
        }
    }

    private void ShowMainMenu()
    {
        Console.WriteLine();
        Console.WriteLine("=== TASK MANAGER ===");
        Console.WriteLine("1. Show all tasks");
        Console.WriteLine("2. Add new task");
        Console.WriteLine("3. Delete task");
        Console.WriteLine("4. Update task status");
        Console.WriteLine("5. Filter tasks");
        Console.WriteLine("0. End");
        Console.WriteLine();
        Console.WriteLine("Select an option:");
    }

    private void ShowAllTasks()
    {
        foreach (var t in _todoRepository.GetAll())
        {
            Console.WriteLine(t);
        }
    }

    private void ShowAllTasks(IReadOnlyList<TodoItem> todoItems)
    {
        foreach (var t in todoItems)
        {
            Console.WriteLine(t);
        }
    }

    private void StatusMenu()
    {
        Console.WriteLine();
        Console.WriteLine("Select status");
        Console.WriteLine("0 - Pending");
        Console.WriteLine("1 - InProgress");
        Console.WriteLine("2 - Completed");
    }
    
    private void PriorityMenu()
    {
        Console.WriteLine();
        Console.WriteLine("Select priority:");
        Console.WriteLine("0 - Low");
        Console.WriteLine("1 - Medium");
        Console.WriteLine("2 - High");
    }
}