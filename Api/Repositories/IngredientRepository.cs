using Api.Models;
using Microsoft.EntityFrameworkCore;
using PagedList;

namespace Api.Data;

public class IngredientRepository : IListingRepository<Ingredient>, IDisposable
{
    private PotionShoppeContext _context;

    public IngredientRepository(PotionShoppeContext context)
    {
        _context = context;
    }

    public IEnumerable<Ingredient> Get()
    {
        var ingredients = _context.Ingredients.Include(i => i.Effect).Include(i => i.IngredientCategory).AsQueryable();
        return [.. ingredients];
    }

    public IEnumerable<Ingredient> GetListing(IFilter<Ingredient>? filter = null, Pagination? page = null, SortOrder? sortOrder = null)
    {
        var ingredients = _context.Ingredients.Include(i => i.Effect).Include(i => i.IngredientCategory).AsQueryable();

        string? name = filter?.GetValue("name");
        if (name != null)
        {
            ingredients = ingredients.Where(i => i.Name!.ToLower().Contains(name.ToLower()));
        }

        List<int>? categories = filter?.GetValue("category");
        if (categories != null)
        {
            ingredients = ingredients.Where(i => categories.Contains(i.IngredientCategoryId ?? 0));
        }

        List<int>? effects = filter?.GetValue("effect");
        if (effects != null)
        {
            ingredients = ingredients.Where(i => effects.Contains(i.EffectId ?? 0));
        }

        int? cMin = filter?.GetValue("cmin");
        if (cMin != null)
        {
            ingredients = ingredients.Where(i => i.Cost >= cMin);
        }

        int? cMax = filter?.GetValue("cmax");
        if (cMax != null)
        {
            ingredients = ingredients.Where(i => i.Cost <= cMax);
        }

        int? pMin = filter?.GetValue("pmin");
        if (pMin != null)
        {
            ingredients = ingredients.Where(i => i.Price >= pMin);
        }

        int? pMax = filter?.GetValue("pmax");
        if (pMax != null)
        {
            ingredients = ingredients.Where(i => i.Price <= pMax);
        }

        bool? inStock = filter?.GetValue("instock");
        if (inStock == true)
        {
            ingredients = ingredients.Where(i => i.CurrentStock > 0);
        }


        return ingredients.ToPagedList(page?.Page ?? 1, page?.Limit ?? 20);
    }

    public IFilter<Ingredient> GetFilterData()
    {
        return new IngredientFilter()
        {
            CostMax = _context.Ingredients.Max(i => i.Cost),
            PriceMax = _context.Ingredients.Max(i => i.Price)
        };
    }

    public Ingredient? GetById(int id)
    {
        return _context.Ingredients.Find(id);
    }

    public Ingredient Insert(Ingredient entity)
    {
        _context.Ingredients.Add(entity);
        Save();
        return entity;
    }

    public void Update(Ingredient entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        Save();
    }

    public void Delete(int id)
    {
        Ingredient ingredient = _context.Ingredients.Find(id);
        _context.Ingredients.Remove(ingredient);
        Save();
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
