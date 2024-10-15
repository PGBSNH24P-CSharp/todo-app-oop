/*
Todo applikation

- Skapa todos
    - Titel för task
    - Beskrivning för task
    - Datum + deadline för task
    - Label för task (kategorisera)
    - Upprepande tasks
    - create <title> <description>
- Radera todos
    - remove <title>
- Avklara todos
    - complete <title>
    - uncomplete <title>
- Uppdatera todos
    - update <title> <description>
- Schemalägga todos (med påminnelser)
    - Olika typer av tasks

Klasser:
- Task
- Calender
- Command (en för varje kommando)
- TaskManager
- CommandManager

*/


public class Program
{
    public TaskManager TaskManager { get; init; }

    public MenuManager MenuManager { get; init; }

    public Program()
    {
        this.MenuManager = new SimpleMenuManager(new UserMenu(this));
        string choice = Console.ReadLine()!;
        if (choice.Equals("file"))
        {
            this.TaskManager = new FileTaskManager();
        }
        else
        {
            this.TaskManager = new ListTaskManager();
        }
    }

    static void Main(string[] args)
    {
        Program program = new Program();

        while (true)
        {
            string input = Console.ReadLine()!;
            program.MenuManager.GetCurrentMenu().TryExecuteCommand(input);
        }
    }
}
