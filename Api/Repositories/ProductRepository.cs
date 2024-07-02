using Api.Models;
using Microsoft.EntityFrameworkCore;
using PagedList;

namespace Api.Data;

public class ProductRepository : IRepository<Product>, IDisposable
{
    private PotionShoppeContext _context;

    public ProductRepository(PotionShoppeContext context)
    {
        _context = context;
    }

    public IEnumerable<Product> Get()
    {
        var Products = _context.Products.Include(p => p.Ingredient).Include(p => p.Potion);
        return [.. Products];
    }

    public Product? GetById(int id)
    {
        return _context.Products.Include(p => p.Ingredient).Include(p => p.Potion).Where(i => i.ProductId == id).First();
    }

    public Product Insert(Product entity)
    {
        _context.Products.Add(entity);
        Save();
        return entity;
    }

    public void Update(Product entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        Save();
    }

    public void Delete(int id)
    {
        Product Product = _context.Products.Find(id);
        _context.Products.Remove(Product);
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
