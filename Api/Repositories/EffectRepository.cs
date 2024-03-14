using Api.Models;
using Microsoft.EntityFrameworkCore;
using PagedList;

namespace Api.Data;

public class EffectRepository : IFilterRepository<Effect>, IDisposable
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

    public IEnumerable<Effect> GetListing(IFilter<Effect>? filter = null, Pagination? page = null)
    {
        var effects = _context.Effects.AsQueryable();

        string? name = filter?.GetValue("name");
        if (name != null)
        {
            effects = effects.Where(e => e.Name!.ToLower().Contains(name.ToLower()));
        }

        int? vMin = filter?.GetValue("vmin");
        if (vMin != null)
        {
            effects = effects.Where(e => e.Value >= vMin);
        }

        int? vMax = filter?.GetValue("vmax");
        if (vMax != null)
        {
            effects = effects.Where(e => e.Value <= vMax);
        }

        int? dMin = filter?.GetValue("dmin");
        if (dMin != null)
        {
            effects = effects.Where(e => e.Duration >= dMin);
        }

        int? dMax = filter?.GetValue("dmax");
        if (dMax != null)
        {
            effects = effects.Where(e => e.Duration <= dMax);
        }

        List<int>? values = filter?.GetValue("value");
        if (values != null)
        {
            effects = effects.Where(e => values!.Contains((int)e.Value!));
        }

        return effects.ToPagedList(page?.Page ?? 1, page?.Limit ?? 20);
    }

    public Effect? GetById(int id)
    {
        return _context.Effects.Find(id);
    }

    public IFilter<Effect> GetFilterData()
    {
        return new EffectFilter()
        {
            ValueMax = _context.Effects.Max(e => e.Value),
            DurationMax = _context.Effects.Max(e => e.Duration)
        };
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
