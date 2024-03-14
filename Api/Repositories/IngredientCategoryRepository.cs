using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public class IngredientCategoryRepository : IRepository<IngredientCategory>, IDisposable
{
    private PotionShoppeContext context;

    public IngredientCategoryRepository(PotionShoppeContext _context)
    {
        context = _context;
    }

    public IEnumerable<IngredientCategory> Get()
    {
        return [.. context.IngredientCategories];
    }

    public IEnumerable<IngredientCategory> GetListing(IFilter<IngredientCategory>? filter = null, Pagination? page = null)
    {
        throw new NotImplementedException();
    }

    public IngredientCategory? GetById(int id)
    {
        return context.IngredientCategories.Find(id)!;
    }

    public IngredientCategory Insert(IngredientCategory entity)
    {
        context.IngredientCategories.Add(entity);
        Save();
        return entity;
    }

    public void Update(IngredientCategory entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        Save();
    }

    public void Delete(int id)
    {
        IngredientCategory ingredientCategory = context.IngredientCategories.Find(id);
        context.IngredientCategories.Remove(ingredientCategory);
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
