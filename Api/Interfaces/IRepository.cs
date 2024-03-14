using Api.Models;

namespace Api.Data;

public interface IRepository<T>
{
    IEnumerable<T> Get();
    IEnumerable<T> GetListing(IFilter<T>? filter = null, Pagination? page = null);
    T? GetById(int id);
    T Insert(T entity);
    void Delete(int id);
    void Update(T entity);
    void Save();
}

public interface IAccountRepository<T> : IRepository<T>
{
    // Make this later
}

public interface IListingRepository<T> : IRepository<T>
{
    IFilter<T> GetFilterData();

}
