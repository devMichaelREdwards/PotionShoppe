using System.Linq.Expressions;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public class EffectRepository : IRepository<Effect>, IDisposable
{
    private PotionShoppeContext _context;

    public EffectRepository(PotionShoppeContext context)
    {
        _context = context;
    }

    public IEnumerable<Effect> Get()
    {
        return [.. _context.Effects];
    }

    public IEnumerable<Effect> GetListing(IFilter<Effect>? filter = null)
    {
        var effects = from effect in _context.Effects select effect;

        string name = filter.GetValue("name");
        if (name != null)
        {
            effects = effects.Where(e => e.Name.ToLower().Contains(name.ToLower()));
        }
        return [.. _context.Effects];
    }

    public Effect GetById(int id)
    {
        return _context.Effects.Find(id);
    }

    public Effect Insert(Effect entity)
    {
        _context.Effects.Add(entity);
        Save();
        return entity;
    }

    public void Update(Effect entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        Save();
    }

    public void Delete(int id)
    {
        Effect effect = _context.Effects.Find(id);
        _context.Effects.Remove(effect);
        Save();
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    #region Dispose
    private bool _disposed = false;
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
    }

    #endregion
}
