using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public class PotionEffectRepository : IRepository<PotionEffect>, IDisposable
{
    private PotionShoppeContext context;

    public PotionEffectRepository(PotionShoppeContext _context)
    {
        context = _context;
    }

    public IEnumerable<PotionEffect> Get()
    {
        return [.. context.PotionEffects.Include(pe => pe.Potion).Include(pe => pe.Effect)];
    }

    public IEnumerable<PotionEffect> GetListing(IFilter<PotionEffect>? filter = null)
    {
        throw new NotImplementedException();
    }

    public PotionEffect GetById(int id)
    {
        return context.PotionEffects.Find(id);
    }

    public PotionEffect Insert(PotionEffect entity)
    {
        context.PotionEffects.Add(entity);
        Save();
        return entity;
    }

    public void Update(PotionEffect entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        Save();
    }

    public void Delete(int id)
    {
        PotionEffect potionEffect = context.PotionEffects.Find(id);
        context.PotionEffects.Remove(potionEffect);
        Save();
    }

    public void Save()
    {
        context.SaveChanges();
    }

    #region Dispose
    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
    }

    #endregion
}
