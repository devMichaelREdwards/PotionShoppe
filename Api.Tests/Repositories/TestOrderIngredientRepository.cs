using Api.Data;
using Api.Models;
using Faker;

namespace Api.Tests;

public class TestOrderIngredientRepository : IRepository<OrderIngredient>, IDisposable
{
    private List<OrderIngredient> orderIngredients = new();

    public TestOrderIngredientRepository()
    {
        orderIngredients = DataFaker.FakeOrderIngredients();
    }

    public IEnumerable<OrderIngredient> Get()
    {
        return orderIngredients;
    }

    public OrderIngredient GetById(int id)
    {
        return orderIngredients.Find(s => s.OrderIngredientId == id);
    }

    public OrderIngredient Insert(OrderIngredient entity)
    {
        orderIngredients.Add(entity);
        return entity;
    }

    public void Update(OrderIngredient entity)
    {
        OrderIngredient selected = orderIngredients.FirstOrDefault(
            s => s.OrderIngredientId == entity.OrderIngredientId
        );
        if (selected != null)
        {
            selected.IngredientId = entity.IngredientId;
        }
    }

    public void Delete(int id)
    {
        orderIngredients = orderIngredients.Where(s => s.OrderIngredientId != id).ToList();
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
