// Detta är en klass och inte ett interface för att
// jag vill spara kommandon som en lista (för varje meny).
// (Interfaces kan inte ha variabler)
public abstract class Menu {

    private List<Command> commands = new List<Command>();
    protected Program program;

    public Menu(Program program) {
        this.program = program;
    }

    // Hjälp-funktion som anropas för att registrera kommandon
    // inom menyer. Se 'UserMenu' för ett exempel.
    protected void AddCommand(Command command) {
        this.commands.Add(command);
    }

    // Försöker exekvera ett kommando som matchar
    // input strängen. Denna metod kör endast kommandon
    // som tillhör menyn.
    public void TryExecuteCommand(string input) {
        string[] commandArgs = input.Split(" ");
        string commandName = commandArgs[0];

        if (commandName.Equals("help")) {
            foreach (Command command in commands) {
                Console.WriteLine(command.Name + " - " + command.GetDescription());
            }

            return;
        }

        foreach (Command command in commands) {
            if (command.Name.Equals(commandName)) {
                command.Execute(commandArgs);
                return;
            }
        }
    }


    // Alla menuer har den delade funktionaliteten 'Display'
    // och därför läggs den in som abstract metod
    public abstract void Display();
}