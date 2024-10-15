public interface TaskManager
{
    void Save(Task task);
    void Delete(Task task);

    Task? GetTask(string title);

    List<Task> GetAllTasks();
}

public class FileTaskManager : TaskManager
{
    public void Save(Task task)
    {
        string serializedTask = task.Title;
        serializedTask += "," + task.Description;
        serializedTask += "," + task.Label;
        serializedTask += "," + task.Completed;
        serializedTask += "," + task.CreationDate;
        serializedTask += "," + task.DeadlineDate;

        File.WriteAllText("tasks/" + task.Title, serializedTask);
    }

    public void Delete(Task task)
    {
        File.Delete("tasks/" + task.Title);
    }

    public List<Task> GetAllTasks()
    {
        // TODO: Fix
        return null;
    }

    public Task? GetTask(string title)
    {
        try
        {
            string fileContent = File.ReadAllText("tasks/" + title);
            string[] parts = fileContent.Split(",");

            Task task = new Task {
                Title = parts[0],
                Description = parts[1],
                Label = parts[2],
                Completed = parts[3].Equals("True"),
                // TODO: Convert dates
                CreationDate = DateTime.Now,
                DeadlineDate = DateTime.Now,
            };

            return task;
        }
        catch (Exception e)
        {
            return null;
        }
    }
}

public class ListTaskManager : TaskManager
{
    private List<Task> tasks = new List<Task>();

    public void Save(Task task)
    {
        tasks.Add(task);
    }

    public void Delete(Task task)
    {
        tasks.Remove(task);
    }

    public List<Task> GetAllTasks()
    {
        return tasks;
    }

    public Task? GetTask(string title)
    {
        foreach (Task task in tasks) {
            if (task.Title.Equals(title)) {
                return task;
            }
        }

        return null;
    }    
}