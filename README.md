# TaskManager

A console-based task management application built in C# (.NET 8), developed as a learning project to practice C# syntax, OOP principles, LINQ, and JSON persistence before moving to ASP.NET Core backend development.

## Features

- Add tasks with a title, due date, and priority
- View all tasks
- Delete tasks by ID
- Update task status (Pending → In Progress → Completed)
- Filter tasks by status, priority, or overdue
- Persistent storage — tasks are saved to a local JSON file and loaded on startup

## How to Run

1. Clone the repository
2. Open the solution in JetBrains Rider (or Visual Studio)
3. Run the project (`Ctrl+F5`)

## How to Use

When you launch the app, you will see the main menu:

```
=== TASK MANAGER ===
1. Show all tasks
2. Add new task
3. Delete task
4. Update task status
5. Filter tasks
0. End
```

### Adding a task
Select `2`, then enter:
- Task name
- Priority (`0` = Low, `1` = Medium, `2` = High)
- Due date in `dd.MM.yyyy` format (e.g. `29.06.2026`)

### Deleting a task
Select `3` — all tasks will be shown with their IDs. Enter the ID of the task you want to delete.

### Updating task status
Select `4` — choose a task by ID, then select a new status:
- `0` = Pending
- `1` = In Progress
- `2` = Completed

### Filtering tasks
Select `5`, then choose a filter:
- `1` = Filter by status
- `2` = Filter by priority
- `3` = Show overdue tasks (past due date, not completed)

## Project Structure

```
TaskManager/
├── Enums/
│   ├── Priority.cs        # Low, Medium, High
│   └── Status.cs          # Pending, InProgress, Completed
├── Models/
│   └── TodoItem.cs        # Task data model
├── Repositories/
│   └── TodoRepository.cs  # In-memory task management + LINQ filtering
├── Services/
│   └── JsonStorageService.cs  # Save/load tasks to todos.json
├── UI/
│   └── ConsoleUI.cs       # Console menu and user interaction
└── Program.cs             # Entry point
```

## Tech Stack

- **Language:** C# 
- **Framework:** .NET 8
- **IDE:** JetBrains Rider
- **Storage:** JSON via `System.Text.Json`