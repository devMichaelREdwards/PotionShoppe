using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public class IngredientRepository : IRepository<Ingredient>, IDisposable
{
    private PotionShoppeContext context;

    public IngredientRepository(PotionShoppeContext _context)
    {
        context = _context;
    }

    public IEnumerable<Ingredient> Get()
    {
        return [.. context.Ingredients.Include(i => i.Effect)];
    }

    public Ingredient GetById(int id)
    {
        return context.Ingredients.Find(id);
    }

    public Ingredient Insert(Ingredient entity)
    {
        context.Ingredients.Add(entity);
        Save();
        return entity;
    }

    public void Update(Ingredient entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        Save();
    }

    public void Delete(int id)
    {
        Ingredient ingredient = context.Ingredients.Find(id);
        context.Ingredients.Remove(ingredient);
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

    public IEnumerable<Ingredient> GetListing()
    {
        throw new NotImplementedException();
    }

    #endregion
}
