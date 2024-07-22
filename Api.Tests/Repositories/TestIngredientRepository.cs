using Api.Data;
using Api.Models;
using Faker;

namespace Api.Tests;

public class TestIngredientRepository : IListingRepository<Ingredient>, IDisposable
{
    private List<Ingredient> ingredients = new();

    public TestIngredientRepository()
    {
        ingredients = DataFaker.FakeIngredients();
    }

    public IEnumerable<Ingredient> Get()
    {
        return ingredients;
    }

    public Ingredient GetById(int id)
    {
        return ingredients.Find(s => s.IngredientId == id);
    }

    public Ingredient Insert(Ingredient entity)
    {
        ingredients.Add(entity);
        return entity;
    }

    public void Update(Ingredient entity)
    {
        Ingredient selected = ingredients.FirstOrDefault(
            s => s.IngredientId == entity.IngredientId
        );
        if (selected != null)
        {
            selected.EffectId = entity.EffectId;
            selected.Product = entity.Product;
        }
    }

    public void Delete(int id)
    {
        ingredients = ingredients.Where(s => s.IngredientId != id).ToList();
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

    public IEnumerable<Ingredient> GetListing(IFilter<Ingredient>? filter = null, Pagination? page = null, SortOrder? sortOrder = null)
    {
        return ingredients;
    }

    public IFilter<Ingredient> GetFilterData()
    {
        throw new NotImplementedException();
    }

    #endregion
}
