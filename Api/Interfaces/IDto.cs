namespace Api.Models;

public interface IDto<T> : IEquatable<T>
{
    void Update(T dest);
}

public interface IFilter<T>
{
    public dynamic? GetValue(string key);
}
