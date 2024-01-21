using Abudantia.Data;
using Abudantia.Helpers;
using Abudantia.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Abudantia.Repository
{
    public class ProductRepository(EfContext db)
    {
        private EfContext _db { get; set; } = db;

        public async Task<OperationResult> Create(Product product)
        {
            if (product is null)
                return OperationResult.IsNull();
            return await Operation(_db.Products.Add, product);
        }

        public async Task<OperationResult> Update(Product product)
        {
            Product? prod = await _db.Products.FirstOrDefaultAsync(p => p.Id == product.Id);
            if (prod is null)
                return OperationResult.IsNull();
            return await Operation(_db.Products.Update, product);
        }

        public async Task<OperationResult> Remove(Product product)
        {
            if (product is null)
                return OperationResult.IsNull();
            var transaction = _db.Database.BeginTransaction();
            try
            {
                await _db.Products
                    .Where(p => p.Id == product.Id)
                    .ExecuteDeleteAsync();
                await transaction.CommitAsync();
                return OperationResult.OkResult();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return OperationResult.CreateFromThrow(ex);
            }
        }

        public async Task<List<Product>> GetAll(Expression<Func<Product, bool>>? filter = null)
        {
            IQueryable<Product> query = _db.Products.AsNoTracking();
            if (filter is not null)
                query = query.Where(filter);
            return await query.ToListAsync();
        }
        public async Task<Product?> Get(Expression<Func<Product, bool>> filter, bool asNoTracking = true)
        {
            IQueryable<Product> query = _db.Products;
            if (asNoTracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(filter);
        }
        public async Task<List<Product>> GetByPage(int page, int pageSize)
        {
            return await _db.Products.AsNoTracking()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
        private async Task<OperationResult> Operation(Func<Product, EntityEntry<Product>> func, Product product)
        {
            try
            {
                func(product);
                await _db.SaveChangesAsync();
                return OperationResult.OkResult();
            }
            catch (Exception ex)
            {
                return OperationResult.CreateFromThrow(ex);
            }
        }
    }
}
