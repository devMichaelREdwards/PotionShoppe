using Api.Models;
using Microsoft.EntityFrameworkCore;
using PagedList;

namespace Api.Data;

public class PotionRepository : IListingRepository<Potion>, IDisposable
{
    private PotionShoppeContext _context;

    public PotionRepository(PotionShoppeContext context)
    {
        _context = context;
    }

    public IEnumerable<Potion> Get()
    {
        var potions = _context.Potions.Include(p => p.Employee).Include(p => p.PotionEffects).ThenInclude(pe => pe.Effect).AsQueryable();
        return [.. potions];
    }

    public IEnumerable<Potion> GetListing(IFilter<Potion>? filter = null, Pagination? page = null, SortOrder? sortOrder = null)
    {
        var potions = _context.Potions.Include(p => p.Employee).Include(p => p.Product).Include(p => p.PotionEffects).ThenInclude(pe => pe.Effect).AsQueryable();
        string? name = filter?.GetValue("name");
        if (name != null)
        {
            potions = potions.Where(i => i.Product.Name!.ToLower().Contains(name.ToLower()));
        }

        List<int>? effects = filter?.GetValue("effect");
        if (effects != null)
        {
            potions = potions.Where(p => p.PotionEffects.Any(e => effects.Contains(e.EffectId ?? 0)));
        }

        int? cMin = filter?.GetValue("cmin");
        if (cMin != null)
        {
            potions = potions.Where(i => i.Product.Cost >= cMin);
        }

        int? cMax = filter?.GetValue("cmax");
        if (cMax != null)
        {
            potions = potions.Where(i => i.Product.Cost <= cMax);
        }

        int? pMin = filter?.GetValue("pmin");
        if (pMin != null)
        {
            potions = potions.Where(i => i.Product.Price >= pMin);
        }

        int? pMax = filter?.GetValue("pmax");
        if (pMax != null)
        {
            potions = potions.Where(i => i.Product.Price <= pMax);
        }

        bool? inStock = filter?.GetValue("instock");
        if (inStock == true)
        {
            potions = potions.Where(i => i.Product.CurrentStock > 0);
        }

        string? sort = sortOrder?.GetValue("sort");
        string? order = sortOrder?.GetValue("order");

        if (sort != null && order != null)
        {
            if (sort == "cost" && order == "asc")
            {
                potions = potions.OrderBy(i => i.Product.Cost);
            }

            if (sort == "cost" && order == "desc")
            {
                potions = potions.OrderByDescending(i => i.Product.Cost);
            }

            if (sort == "price" && order == "asc")
            {
                potions = potions.OrderBy(i => i.Product.Price);
            }

            if (sort == "price" && order == "desc")
            {
                potions = potions.OrderByDescending(i => i.Product.Price);
            }

            if (sort == "currentStock" && order == "asc")
            {
                potions = potions.OrderBy(i => i.Product.CurrentStock);
            }

            if (sort == "currentStock" && order == "desc")
            {
                potions = potions.OrderByDescending(i => i.Product.CurrentStock);
            }
        }

        return potions.ToPagedList(page?.Page ?? 1, page?.Limit ?? 20);
    }

    public IFilter<Potion> GetFilterData()
    {
        var cost = _context.Potions.Include(p => p.Product).Max(p => p.Product.Cost);
        var price = _context.Potions.Include(p => p.Product).Max(p => p.Product.Price);
        return new PotionFilter()
        {
            CostMax = cost,
            PriceMax = price
        };
    }

    public Potion? GetById(int id)
    {
        return _context.Potions.Where(p => p.PotionId == id).Include(p => p.Employee).Include(p => p.Product).Include(p => p.PotionEffects).ThenInclude(pe => pe.Effect).First();
    }

    public Potion Insert(Potion entity)
    {
        Product newProduct = new Product
        {
            Cost = entity.Product.Cost,
            Price = entity.Product.Price,
            CurrentStock = entity.Product.CurrentStock,
            DateAdded = DateOnly.FromDateTime(DateTime.Now),
            Active = true
        };
        _context.Products.Add(newProduct);
        Save();
        _context.Potions.Add(entity);
        Save();
        return entity;
    }

    public void Update(Potion entity)
    {
        Potion potion = _context.Potions.Where(p => p.PotionId == entity.PotionId).First();
        potion.Product.Name = entity.Product.Name;
        potion.Product.Description = entity.Product.Description;
        potion.Product.Image = entity.Product.Image;
        potion.PotionEffects = entity.PotionEffects;
        potion.ProductId = entity.ProductId;
        Save();
    }

    public void Delete(int id)
    {
        Potion potion = _context.Potions.Find(id);
        _context.PotionEffects.RemoveRange(_context.PotionEffects.Where(pe => pe.PotionId == potion.PotionId));
        _context.Products.RemoveRange(_context.Products.Where(pr => pr.ProductId == potion.ProductId));
        _context.Potions.Remove(potion);
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
