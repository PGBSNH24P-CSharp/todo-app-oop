using System.Globalization;

public class CreateTaskCommand : Command
{
    // Eftersom namnet på kommandot är förbestämt så
    // hårdkodas den in här i 'base'
    public CreateTaskCommand(Program program) : base("create-task", program)
    {
    }

    public override string GetDescription()
    {
        return "Create a task";
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

        Console.WriteLine("Do you want a simple task, or a repeating task?");
        Console.WriteLine("1. Simple");
        Console.WriteLine("2. Repeating");
        string taskType = Console.ReadLine()!;
        Task task;
        if (taskType.Equals("1"))
        {
            Console.WriteLine("Enter deadline date (yyyy-MM-dd):");
            string deadlineDate = Console.ReadLine()!;

            DateTime deadline = DateTime.ParseExact(deadlineDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);


            task = new SimpleTask
            {
                Title = title,
                Description = description,
                Label = label,
                CreationDate = DateTime.Now,
                DeadlineDate = deadline,
            };
        }
        else
        {
            Console.WriteLine("Enter a day of week (1-7):");
            string dayOfWeekString = Console.ReadLine()!;
            int dayOfWeekIndex = int.Parse(dayOfWeekString) - 1;
            DayOfWeek dayOfWeek = DayOfWeek.Monday;
            switch (dayOfWeekIndex)
            {
                case 0:
                    dayOfWeek = DayOfWeek.Monday;
                    break;
                case 1:
                    dayOfWeek = DayOfWeek.Tuesday;
                    break;
                case 2:
                    dayOfWeek = DayOfWeek.Wednesday;
                    break;
                case 3:
                    dayOfWeek = DayOfWeek.Thursday;
                    break;
                case 4:
                    dayOfWeek = DayOfWeek.Friday;
                    break;
                case 5:
                    dayOfWeek = DayOfWeek.Saturday;
                    break;
                case 6:
                    dayOfWeek = DayOfWeek.Sunday;
                    break;
            }

            Console.WriteLine("Enter a time of day (hh:mm):");
            string timeString = Console.ReadLine()!;
            TimeOnly time = TimeOnly.Parse(timeString);

            task = new RepeatingTask {
                Title = title,
                Description = description,
                Label = label,
                CreationDate = DateTime.Now,
                Day = dayOfWeek,
                TimeOfDay = time,
             };
        }

        program.TaskManager.Save(task);

        Console.WriteLine(task.ToString());
    }
}