using Api.Data;
using Api.Models;
using Faker;

namespace Api.Tests;

public class TestOrderIngredientRepository : IRepository<OrderIngredient>, IDisposable
{
    private List<OrderIngredient> potionIngredients = new();

    public TestOrderIngredientRepository()
    {
        potionIngredients = DataFaker.FakeOrderIngredients();
    }

    public IEnumerable<OrderIngredient> Get()
    {
        return potionIngredients;
    }

    public OrderIngredient GetById(int id)
    {
        return potionIngredients.Find(s => s.OrderIngredientId == id);
    }

    public OrderIngredient Insert(OrderIngredient entity)
    {
        potionIngredients.Add(entity);
        return entity;
    }

    public void Update(OrderIngredient entity)
    {
        OrderIngredient selected = potionIngredients.FirstOrDefault(
            s => s.OrderIngredientId == entity.OrderIngredientId
        );
        if (selected != null)
        {
            selected.IngredientId = entity.IngredientId;
        }
    }

    public void Delete(int id)
    {
        potionIngredients = potionIngredients.Where(s => s.OrderIngredientId != id).ToList();
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
