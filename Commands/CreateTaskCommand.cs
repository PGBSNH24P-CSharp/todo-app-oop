using System.Globalization;

public class CreateTaskCommand : Command
{
    // Eftersom namnet på kommandot är förbestämt så
    // hårdkodas den in här i 'base'
    public CreateTaskCommand(Program program) : base("create-task", program)
    {
    }

    public override void Execute(string[] commandArgs)
    {
        if (commandArgs.Length != 2)
        {
            throw new ArgumentException("Usage: create-task <title>");
        }

        string title = commandArgs[1];

        Console.WriteLine("Enter description: ");
        string description = Console.ReadLine()!;

        Console.WriteLine("Enter label:");
        string label = Console.ReadLine()!;

        Console.WriteLine("Enter deadline date (yyyy-MM-dd):");
        string deadlineDate = Console.ReadLine()!;

        DateTime deadline = DateTime.ParseExact(deadlineDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

        Task task = new Task
        {
            Title = title,
            Description = description,
            Label = label,
            CreationDate = DateTime.Now,
            DeadlineDate = deadline,
        };

        program.TaskManager.Save(task);

        Console.WriteLine(task.ToString());
    }
}