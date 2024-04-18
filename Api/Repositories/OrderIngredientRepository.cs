using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public class OrderIngredientRepository : IRepository<OrderIngredient>, IDisposable
{
    private PotionShoppeContext context;

    public OrderIngredientRepository(PotionShoppeContext _context)
    {
        context = _context;
    }

    public IEnumerable<OrderIngredient> Get()
    {
        return [.. context.OrderIngredients.Include(pe => pe.Order).Include(pe => pe.Ingredient)];
    }

    public IEnumerable<OrderIngredient> GetListing(IFilter<OrderIngredient>? filter = null, Pagination? page = null, SortOrder? sortOrder = null)
    {
        throw new NotImplementedException();
    }

    public OrderIngredient? GetById(int id)
    {
        return context.OrderIngredients.Find(id);
    }

    public OrderIngredient Insert(OrderIngredient entity)
    {
        context.OrderIngredients.Add(entity);
        Save();
        return entity;
    }

    public void Update(OrderIngredient entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        Save();
    }

    public void Delete(int id)
    {
        OrderIngredient orderIngredient = context.OrderIngredients.Find(id);
        context.OrderIngredients.Remove(orderIngredient);
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
