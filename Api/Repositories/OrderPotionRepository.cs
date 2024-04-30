using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public class OrderPotionRepository : IRepository<OrderPotion>, IDisposable
{
    private PotionShoppeContext context;

    public OrderPotionRepository(PotionShoppeContext _context)
    {
        context = _context;
    }

    public IEnumerable<OrderPotion> Get()
    {
        return [.. context.OrderPotions.Include(pe => pe.Order).Include(pe => pe.Potion)];
    }

    public IEnumerable<OrderPotion> GetListing(IFilter<OrderPotion>? filter = null, Pagination? page = null, SortOrder? sortOrder = null)
    {
        throw new NotImplementedException();
    }

    public OrderPotion? GetById(int id)
    {
        return context.OrderPotions.Find(id);
    }

    public OrderPotion Insert(OrderPotion entity)
    {
        context.OrderPotions.Add(entity);
        Save();
        return entity;
    }

    public void Update(OrderPotion entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        Save();
    }

    public void Delete(int id)
    {
        OrderPotion orderPotion = context.OrderPotions.Find(id);
        context.OrderPotions.Remove(orderPotion);
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
