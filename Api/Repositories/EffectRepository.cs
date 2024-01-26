using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public class EffectRepository : IRepository<Effect>, IDisposable
{
    private PotionShoppeContext context;

    public EffectRepository(PotionShoppeContext _context)
    {
        context = _context;
    }

    public IEnumerable<Effect> Get()
    {
        return [.. context.Effects];
    }

    public Effect GetById(int id)
    {
        return context.Effects.Find(id);
    }

    public Effect Insert(Effect entity)
    {
        context.Effects.Add(entity);
        Save();
        return entity;
    }

    public void Update(Effect entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        Save();
    }

    public void Delete(int id)
    {
        Effect effect = context.Effects.Find(id);
        context.Effects.Remove(effect);
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
