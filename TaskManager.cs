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
        string serializedTask = task.Serialize();

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

            string taskType = parts[1];
            if (taskType.Equals("simple"))
            {
                return new SimpleTask
                {
                    Title = parts[0],
                    Description = parts[2],
                    Label = parts[3],
                    Completed = parts[4].Equals("True"),
                    // TODO: Convert dates
                    CreationDate = DateTime.Now,
                    DeadlineDate = DateTime.Now,
                };
            }
            else if (taskType.Equals("repeating"))
            {
                return new RepeatingTask
                {
                    Title = parts[0],
                    Description = parts[2],
                    Label = parts[3],
                    Completed = parts[4].Equals("True"),
                    // TODO: Convert dates
                    CreationDate = DateTime.Now,
                    Day = DayOfWeek.Monday,
                    TimeOfDay = TimeOnly.MinValue,
                };
            }

            return null;
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
        foreach (Task task in tasks)
        {
            if (task.Title.Equals(title))
            {
                return task;
            }
        }

        return null;
    }
}