using Api.Classes;
using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Api.Data;

public class EmployeeAccountRepository : IRepository<EmployeeAccount>, IDisposable
{
    private PotionShoppeContext context;

    public EmployeeAccountRepository(PotionShoppeContext _context)
    {
        context = _context;
    }

    public IEnumerable<EmployeeAccount> Get()
    {
        return [.. context.EmployeeAccounts.Include(e => e.Employee).ThenInclude(e => e.EmployeeStatus)];
    }

    public EmployeeAccount GetById(int id)
    {
        return context.EmployeeAccounts.Find(id);
    }

    public EmployeeAccount GetByUserName(string userName)
    {
        return context.EmployeeAccounts.First(a => a.UserName == userName);
    }

    public RefreshToken? GetRefreshTokenForUser(string userName)
    {
        EmployeeAccount entity = context.EmployeeAccounts.First(a => a.UserName == userName);

        if (entity.RefreshToken.IsNullOrEmpty() || entity.TokenExpire is null)
        {
            return null;
        }

        return new RefreshToken()
        {
            Token = entity.RefreshToken!,
            Expire = (DateOnly)entity.TokenExpire,
        };
    }

    public EmployeeAccount Insert(EmployeeAccount entity)
    {
        context.EmployeeAccounts.Add(entity);
        Save();
        return entity;
    }

    public void Update(EmployeeAccount entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        Save();
    }

    public void UpdateRefreshToken(string userName, string? token, DateOnly? expire)
    {
        EmployeeAccount entity = GetByUserName(userName);
        entity.RefreshToken = token;
        entity.TokenExpire = expire;
        context.Entry(entity).State = EntityState.Modified;
        Save();
    }

    public void Delete(int id)
    {
        EmployeeAccount EmployeeAccount = context.EmployeeAccounts.Find(id);
        context.EmployeeAccounts.Remove(EmployeeAccount);
        Save();
    }

    public bool EmployeeExists(string userName)
    {
        return context.EmployeeAccounts.FirstOrDefault(a => a.UserName == userName) != null;
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

    public IEnumerable<EmployeeAccount> GetListing()
    {
        throw new NotImplementedException();
    }

    #endregion
}
