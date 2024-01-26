using Api.Data;
using Api.Models;
using Faker;

namespace Api.Tests;

public class TestPotionRepository : IRepository<Potion>, IDisposable
{
    private List<Potion> ingredients = new();

    public TestPotionRepository()
    {
        ingredients = DataFaker.FakePotions();
    }

    public IEnumerable<Potion> Get()
    {
        return ingredients;
    }

    public Potion GetById(int id)
    {
        return ingredients.Find(s => s.PotionId == id);
    }

    public Potion Insert(Potion entity)
    {
        ingredients.Add(entity);
        return entity;
    }

    public void Update(Potion entity)
    {
        Potion selected = ingredients.FirstOrDefault(
            s => s.PotionId == entity.PotionId
        );
        if (selected != null)
        {
            selected.Name = entity.Name;
        }
    }

    public void Delete(int id)
    {
        ingredients = ingredients.Where(s => s.PotionId != id).ToList();
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

    #endregion
}
