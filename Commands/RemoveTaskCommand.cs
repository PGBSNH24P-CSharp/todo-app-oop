public class RemoveTaskCommand : Command
{
    // Eftersom namnet på kommandot är förbestämt så
    // hårdkodas den in här i 'base'
    public RemoveTaskCommand(Program program) : base("remove-task", program)
    {
    }

    public override string GetDescription()
    {
        return "Remove a task";
    }

    public override void Execute(string[] commandArgs)
    {
        if (commandArgs.Length != 2) {
            throw new ArgumentException("Usage: remove-task <title>");
        }

        string title = commandArgs[1];
        Task? task = program.TaskManager.GetTask(title);
        if (task == null) {
            Console.WriteLine("That task does not exist.");
            return;
        }

        program.TaskManager.Delete(task);
        Console.WriteLine($"Task '{task.Title}' has been removed");
    }
}