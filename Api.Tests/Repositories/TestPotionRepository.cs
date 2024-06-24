using Api.Data;
using Api.Models;
using Faker;

namespace Api.Tests;

public class TestPotionRepository : IListingRepository<Potion>, IDisposable
{
    private List<Potion> potions = new();

    public TestPotionRepository()
    {
        potions = DataFaker.FakePotions();
    }

    public IEnumerable<Potion> Get()
    {
        return potions;
    }

    public Potion GetById(int id)
    {
        return potions.Find(s => s.PotionId == id);
    }

    public Potion Insert(Potion entity)
    {
        potions.Add(entity);
        return entity;
    }

    public void Update(Potion entity)
    {
        Potion selected = potions.FirstOrDefault(
            s => s.PotionId == entity.PotionId
        );
        if (selected != null)
        {
            selected.Name = entity.Name;
        }
    }

    public void Delete(int id)
    {
        potions = potions.Where(s => s.PotionId != id).ToList();
    }

    public void Save()
    {
        // Not needed for testing
    }

    #region Dispose
    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing) { }
        }
        disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
    }

    public IEnumerable<Potion> GetListing(IFilter<Potion>? filter = null, Pagination? page = null, SortOrder? sortOrder = null)
    {
        return potions;
    }

    public IFilter<Potion> GetFilterData()
    {
        throw new NotImplementedException();
    }

    #endregion
}
