using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public class IngredientCategoryRepository : ICategoryRepository<IngredientCategory>, IDisposable
{
    private PotionShoppeContext _context;

    public IngredientCategoryRepository(PotionShoppeContext context)
    {
        _context = context;
    }

    public IEnumerable<IngredientCategory> Get()
    {
        return [.. _context.IngredientCategories];
    }


    public IngredientCategory? GetById(int id)
    {
        return _context.IngredientCategories.Find(id)!;
    }

    public IngredientCategory Insert(IngredientCategory entity)
    {
        _context.IngredientCategories.Add(entity);
        Save();
        return entity;
    }

    public void Update(IngredientCategory entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        Save();
    }

    public void Delete(int id)
    {
        IngredientCategory ingredientCategory = _context.IngredientCategories.Find(id);
        _context.IngredientCategories.Remove(ingredientCategory);
        Save();
    }

    public bool IsEmpty(int id)
    {
        return _context.Ingredients.Where(i => i.IngredientCategoryId == id).Count() == 0;
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
