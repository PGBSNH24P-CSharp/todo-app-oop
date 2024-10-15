// Detta är en abstract klass - och inte ett interface - för att
// kunna spara 'Name' variabeln som nås i menyerna. Man skulle dock
// kunna skapat ett interface likt detta:
/*
public interface ICommand {
    void Execute(string[] commandArgs);
    string GetName();
}

Med följande implementation exempelvis, vilket 
har samma effekt som den abstrakta klassen:

public class CreateTaskCommand : ICommand {
    public string GetName()
    {
        return "create-task";
    }

    public void Execute(string[] commandArgs) {}
}
*/
public abstract class Command {

    // Denna variabel bestämmer namnet på kommandot
    // exempelvis "create-task" eller "remove-task".
    public string Name { get; init; }

    protected Program program;

    // Constructorn skapas för att tvinga alla implementationer
    // exempelvis (CreateTaskCommand) att skicka in ett namn så att
    // det görs på rätt sätt.
    public Command(string name, Program program) {
        this.Name = name;
        this.program = program;
    }

    // Alla kommandon har den delade funktionaliteten 'Execute'
    // och därför läggs den in som abstract metod
    public abstract void Execute(string[] commandArgs);

    public abstract string GetDescription();
}