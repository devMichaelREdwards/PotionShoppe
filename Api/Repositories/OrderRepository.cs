using Api.Models;
using Microsoft.EntityFrameworkCore;
using PagedList;

namespace Api.Data;

public class OrderRepository : IListingRepository<Order>, IDisposable
{
    private PotionShoppeContext context;

    public OrderRepository(PotionShoppeContext _context)
    {
        context = _context;
    }

    public IEnumerable<Order> Get()
    {
        return [.. context.Orders
                    .Include(o => o.Customer)
                    .ThenInclude(c => c.CustomerStatus)
                    .Include(o => o.OrderPotions)
                    .ThenInclude(op => op.Potion)
                    .Include(o => o.OrderIngredients)
                    .ThenInclude(oi => oi.Ingredient)
                    .Include(o => o.OrderStatus)
                ];
    }

    public IEnumerable<Order> GetListing(IFilter<Order>? filter = null, Pagination? page = null)
    {
        var orders = context.Orders
                    .Include(o => o.Customer)
                    .ThenInclude(c => c.CustomerStatus)
                    .Include(o => o.OrderStatus)
                    .AsQueryable();
        return orders.ToPagedList(page?.Page ?? 1, page?.Limit ?? 20);
    }

    public Order? GetById(int id)
    {
        return context.Orders.Find(id);
    }

    public Order Insert(Order entity)
    {
        context.Orders.Add(entity);
        Save();
        return entity;
    }

    public void Update(Order entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        Save();
    }

    public void Delete(int id)
    {
        Order order = context.Orders.Find(id);
        context.Orders.Remove(order);
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

    public IFilter<Order> GetFilterData()
    {
        throw new NotImplementedException();
    }

    #endregion
}
