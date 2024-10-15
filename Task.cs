public abstract class Task {
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreationDate { get; set; }
    public string Label { get; set; }
    public bool Completed { get; set; } = false;

    public override string ToString() {
        return Title + " -\n"
        + " - Description = " + Description
        // TODO: Fix ToString
        // +"\n - Deadline = " + DeadlineDate
        +"\n - Label = " + Label
        +"\n - Creation Date = " + CreationDate
        +"\n - Completed = " + Completed;
    }

    public abstract string GetTypeAsString();

    public virtual string Serialize() {
        string serializedTask = Title;
        serializedTask += "," + GetTypeAsString();
        serializedTask += "," + Description;
        serializedTask += "," + Label;
        serializedTask += "," + Completed;
        serializedTask += "," + CreationDate;
        return serializedTask;
    }
}

public class SimpleTask : Task {
    public DateTime DeadlineDate { get; set; }

    public override string GetTypeAsString()
    {
        return "simple";
    }

    public override string Serialize()
    {
        string baseString = base.Serialize();
        baseString += "," + DeadlineDate;
        return baseString;
    }
}

public class RepeatingTask : Task {
    public DayOfWeek Day { get; set; }
    public TimeOnly TimeOfDay {get; set; }

    public override string GetTypeAsString()
    {
        return "repeating";
    }

    public override string Serialize()
    {
        string baseString = base.Serialize();
        baseString += "," + Day;
        baseString += "," + TimeOfDay;
        return baseString;
    }
}