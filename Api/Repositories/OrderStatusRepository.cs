using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public class OrderStatusRepository : IRepository<OrderStatus>, IDisposable
{
    private PotionShoppeContext context;

    public OrderStatusRepository(PotionShoppeContext _context)
    {
        context = _context;
    }

    public IEnumerable<OrderStatus> Get()
    {
        return [.. context.OrderStatuses];
    }

    public OrderStatus GetById(int id)
    {
        return context.OrderStatuses.Find(id);
    }

    public OrderStatus Insert(OrderStatus entity)
    {
        context.OrderStatuses.Add(entity);
        Save();
        return entity;
    }

    public void Update(OrderStatus entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        Save();
    }

    public void Delete(int id)
    {
        OrderStatus orderStatus = context.OrderStatuses.Find(id);
        context.OrderStatuses.Remove(orderStatus);
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
