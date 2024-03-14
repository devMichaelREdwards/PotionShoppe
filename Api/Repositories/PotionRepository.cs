using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public class PotionRepository : IRepository<Potion>, IDisposable
{
    private PotionShoppeContext context;

    public PotionRepository(PotionShoppeContext _context)
    {
        context = _context;
    }

    public IEnumerable<Potion> Get()
    {
        return [.. context.Potions.Include(p => p.Employee).Include(p => p.PotionEffects).ThenInclude(pe => pe.Effect)];
    }

    public IEnumerable<Potion> GetListing(IFilter<Potion>? filter = null, Pagination? page = null)
    {
        return [.. context.Potions.Include(p => p.PotionEffects).ThenInclude(pe => pe.Effect)];
    }

    public Potion? GetById(int id)
    {
        return context.Potions.Find(id);
    }

    public Potion Insert(Potion entity)
    {
        context.Potions.Add(entity);
        Save();
        return entity;
    }

    public void Update(Potion entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        Save();
    }

    public void Delete(int id)
    {
        Potion potion = context.Potions.Find(id);
        context.Potions.Remove(potion);
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
