using Api.Data;
using Api.Models;
using Faker;

namespace Api.Tests;

public class TestEffectRepository : IListingRepository<Effect>, IDisposable
{
    private List<Effect> effects = new();

    public TestEffectRepository()
    {
        effects = DataFaker.FakeEffects();
    }

    public IEnumerable<Effect> Get()
    {
        return effects;
    }

    public Effect GetById(int id)
    {
        return effects.Find(s => s.EffectId == id);
    }

    public Effect Insert(Effect entity)
    {
        effects.Add(entity);
        return entity;
    }

    public void Update(Effect entity)
    {
        Effect selected = effects.FirstOrDefault(s => s.EffectId == entity.EffectId);
        if (selected != null)
        {
            selected.EffectId = entity.EffectId;
            selected.Duration = entity.Duration;
            selected.Description = entity.Description;
            selected.Value = entity.Value;
        }
    }

    public void Delete(int id)
    {
        effects = effects.Where(s => s.EffectId != id).ToList();
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

    public IFilter<Effect> GetFilterData()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Effect> GetListing(IFilter<Effect>? filter = null, Pagination? page = null, SortOrder? sortOrder = null)
    {
        throw new NotImplementedException();
    }

    #endregion
}
