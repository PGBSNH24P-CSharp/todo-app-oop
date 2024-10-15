public class SearchTaskCommand : Command
{
    public SearchTaskCommand(Program program) : base("search-task", program)
    {
    }

    public override string GetDescription()
    {
        return "Search for a task by title.";
    }

    public override void Execute(string[] commandArgs)
    {
        if (commandArgs.Length != 2) {
            throw new ArgumentException("Usage: search-task <title>");
        }

        string title = commandArgs[1];
        Task? task = program.TaskManager.GetTask(title);
        if (task == null) {
            Console.WriteLine("That task does not exist.");
            return;
        }

        Console.WriteLine(task);
    }
}