using Api.Models;
using Microsoft.EntityFrameworkCore;
using PagedList;

namespace Api.Data;

public class IngredientRepository : IRepository<Ingredient>, IDisposable
{
    private PotionShoppeContext _context;

    public IngredientRepository(PotionShoppeContext context)
    {
        _context = context;
    }

    public IEnumerable<Ingredient> Get()
    {
        var ingredients = _context.Ingredients.Include(i => i.Effect).Include(i => i.IngredientCategory).AsQueryable();
        return [.. ingredients];
    }

    public IEnumerable<Ingredient> GetListing(IFilter<Ingredient>? filter = null, Pagination? page = null)
    {
        var ingredients = _context.Ingredients.Include(i => i.Effect).Include(i => i.IngredientCategory).AsQueryable();
        return ingredients.ToPagedList(page?.Page ?? 1, page?.Limit ?? 20);
    }

    public Ingredient? GetById(int id)
    {
        return _context.Ingredients.Find(id);
    }

    public Ingredient Insert(Ingredient entity)
    {
        _context.Ingredients.Add(entity);
        Save();
        return entity;
    }

    public void Update(Ingredient entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        Save();
    }

    public void Delete(int id)
    {
        Ingredient ingredient = _context.Ingredients.Find(id);
        _context.Ingredients.Remove(ingredient);
        Save();
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    #region Dispose
    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _context.Dispose();
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
