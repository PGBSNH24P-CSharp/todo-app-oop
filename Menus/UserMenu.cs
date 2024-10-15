public class UserMenu : Menu
{
    public UserMenu(Program program) : base(program) {
        // Eftersom 'AddCommand' kommer från 'Menu' (bas-klassen) så kan man
        // använda 'base' för att referera till den
        base.AddCommand(new CreateTaskCommand(program));

        // Men samtidigt, eftersom det endast finns en 'AddCommand' så
        // behövs det inte:
        // AddCommand(new CreateTaskCommand());

        base.AddCommand(new RemoveTaskCommand(program));
        base.AddCommand(new SearchTaskCommand(program));
    }

    public override void Display()
    {
        Console.WriteLine("Welcome to the app. Type 'help' for a list of commands.");
    }
}