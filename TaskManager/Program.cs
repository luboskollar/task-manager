using TaskManager.Repositories;
using TaskManager.Services;
using TaskManager.UI;
using TaskManager.Models;
using TaskManager.Enums;
namespace TaskManager;

class Program
{
    static void Main(string[] args)
    {
        var repository = new TodoRepository();
        var storage = new JsonStorageService();
        var ui = new ConsoleUI(repository, storage);
        ui.Run();
    }
}