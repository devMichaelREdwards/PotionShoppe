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
        var ingredients = _context.Ingredients.Include(i => i.Effect).Include(p => p.Products).Include(i => i.IngredientCategory).AsQueryable();
        return [.. ingredients];
    }

    public IEnumerable<Ingredient> GetListing(IFilter<Ingredient>? filter = null, Pagination? page = null, SortOrder? sortOrder = null)
    {
        var ingredients = _context.Ingredients.Include(i => i.Effect).Include(p => p.Products).Include(i => i.IngredientCategory).AsQueryable();

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
            ingredients = ingredients.Where(i => i.Products.First().Cost >= cMin);
        }

        int? cMax = filter?.GetValue("cmax");
        if (cMax != null)
        {
            ingredients = ingredients.Where(i => i.Products.First().Cost <= cMax);
        }

        int? pMin = filter?.GetValue("pmin");
        if (pMin != null)
        {
            ingredients = ingredients.Where(i => i.Products.First().Price >= pMin);
        }

        int? pMax = filter?.GetValue("pmax");
        if (pMax != null)
        {
            ingredients = ingredients.Where(i => i.Products.First().Price <= pMax);
        }

        bool? inStock = filter?.GetValue("instock");
        if (inStock == true)
        {
            ingredients = ingredients.Where(i => i.Products.First().CurrentStock > 0);
        }

        string? sort = sortOrder?.GetValue("sort");
        string? order = sortOrder?.GetValue("order");

        if (sort != null && order != null)
        {
            if (sort == "cost" && order == "asc")
            {
                ingredients = ingredients.OrderBy(i => i.Products.First().Cost);
            }

            if (sort == "cost" && order == "desc")
            {
                ingredients = ingredients.OrderByDescending(i => i.Products.First().Cost);
            }

            if (sort == "price" && order == "asc")
            {
                ingredients = ingredients.OrderBy(i => i.Products.First().Price);
            }

            if (sort == "price" && order == "desc")
            {
                ingredients = ingredients.OrderByDescending(i => i.Products.First().Price);
            }

            if (sort == "currentStock" && order == "asc")
            {
                ingredients = ingredients.OrderBy(i => i.Products.First().CurrentStock);
            }

            if (sort == "currentStock" && order == "desc")
            {
                ingredients = ingredients.OrderByDescending(i => i.Products.First().CurrentStock);
            }
        }

        return ingredients.ToPagedList(page?.Page ?? 1, page?.Limit ?? 20);
    }

    public IFilter<Ingredient> GetFilterData()
    {
        var cost = _context.Products.Where(p => p.IngredientId != null).Max(p => p.Cost);
        var price = _context.Products.Where(p => p.IngredientId != null).Max(p => p.Price);
        return new IngredientFilter()
        {
            CostMax = cost,
            PriceMax = price
        };
    }

    public Ingredient? GetById(int id)
    {
        return _context.Ingredients.Where(i => i.IngredientId == id).Include(i => i.Effect).Include(p => p.Products).Include(i => i.IngredientCategory).First();
    }

    public Ingredient Insert(Ingredient entity)
    {
        _context.Ingredients.Add(entity);
        Save();
        Product newProduct = new Product
        {
            IngredientId = entity.IngredientId,
            Cost = entity.Products.First().Cost,
            Price = entity.Products.First().Price,
            CurrentStock = entity.Products.First().CurrentStock,
            DateAdded = DateOnly.FromDateTime(DateTime.Now),
            Active = true
        };
        _context.Products.Add(newProduct);
        Save();
        return entity;
    }

    public void Update(Ingredient entity)
    {
        Ingredient ingredient = _context.Ingredients.Where(p => p.IngredientId == entity.IngredientId).First();
        ingredient.Name = entity.Name;
        ingredient.Description = entity.Description;
        ingredient.Image = entity.Image;
        ingredient.EffectId = entity.EffectId;
        ingredient.Products = entity.Products;
        Save();
    }

    public void Delete(int id)
    {
        Ingredient ingredient = _context.Ingredients.Find(id);
        _context.Products.RemoveRange(_context.Products.Where(pr => pr.IngredientId == id));
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
