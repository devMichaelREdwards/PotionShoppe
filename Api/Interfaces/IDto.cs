public interface IDto<T> : IEquatable<T>
{
    void Update(T dest);
}

public interface IUpdate<T>
{

}
