using Api.Data;
using Api.Models;
using Faker;

namespace Api.Tests;

public class TestPotionEffectRepository : IRepository<PotionEffect>, IDisposable
{
    private List<PotionEffect> potionEffects = new();

    public TestPotionEffectRepository()
    {
        potionEffects = DataFaker.FakePotionEffects();
    }

    public IEnumerable<PotionEffect> Get()
    {
        return potionEffects;
    }

    public PotionEffect GetById(int id)
    {
        return potionEffects.Find(s => s.PotionEffectId == id);
    }

    public PotionEffect Insert(PotionEffect entity)
    {
        potionEffects.Add(entity);
        return entity;
    }

    public void Update(PotionEffect entity)
    {
        PotionEffect selected = potionEffects.FirstOrDefault(
            s => s.PotionEffectId == entity.PotionEffectId
        );
        if (selected != null)
        {
            selected.EffectId = entity.EffectId;
        }
    }

    public void Delete(int id)
    {
        potionEffects = potionEffects.Where(s => s.PotionEffectId != id).ToList();
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
