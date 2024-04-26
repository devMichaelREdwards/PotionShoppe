namespace Api.Classes;
public class ErrorCollection
{
    public Dictionary<string, string> Errors { get; set; }
    public bool Error { get { return Errors.Count > 0; } }
    public ErrorCollection()
    {
        Errors = [];
    }

    public void Add(string key, string message)
    {
        Errors.Add(key, message);
    }

    public void Remove(string key)
    {
        Errors.Remove(key);
    }
}
