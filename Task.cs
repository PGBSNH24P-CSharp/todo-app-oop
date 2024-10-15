public class Task {
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime DeadlineDate { get; set; }
    public string Label { get; set; }
    public bool Completed { get; set; } = false;

    public override string ToString() {
        return Title + " -\n"
        + " - Description = " + Description
        +"\n - Deadline = " + DeadlineDate
        +"\n - Label = " + Label
        +"\n - Creation Date = " + CreationDate
        +"\n - Completed = " + Completed;
    }
}