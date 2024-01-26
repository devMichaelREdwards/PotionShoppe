using Api.Data;
using Api.Models;
using Faker;

namespace Api.Tests;

public class TestOrderPotionRepository : IRepository<OrderPotion>, IDisposable
{
    private List<OrderPotion> orderPotions = new();

    public TestOrderPotionRepository()
    {
        orderPotions = DataFaker.FakeOrderPotions();
    }

    public IEnumerable<OrderPotion> Get()
    {
        return orderPotions;
    }

    public OrderPotion GetById(int id)
    {
        return orderPotions.Find(s => s.OrderPotionId == id);
    }

    public OrderPotion Insert(OrderPotion entity)
    {
        orderPotions.Add(entity);
        return entity;
    }

    public void Update(OrderPotion entity)
    {
        OrderPotion selected = orderPotions.FirstOrDefault(
            s => s.OrderPotionId == entity.OrderPotionId
        );
        if (selected != null)
        {
            selected.PotionId = entity.PotionId;
        }
    }

    public void Delete(int id)
    {
        orderPotions = orderPotions.Where(s => s.OrderPotionId != id).ToList();
    }

    public void Save()
    {
        // Not needed for testing
    }

    #region Dispose
    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing) { }
        }
        disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
    }

    #endregion
}
