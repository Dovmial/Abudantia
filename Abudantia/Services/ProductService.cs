using Abudantia.Data;
using Abudantia.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Abudantia.Services
{
    public sealed class ProductService(EfContext db)
    {
        internal async Task<int> Add(Product product)
        {
            if (product is null)
                return 0;
            db.Products.Add(product);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception ex) 
            {
                //TODO: логирование ошибок
            }
            return product.Id;
        }

        internal async Task<Product?> GetProduct(int id, bool noTracking = true)
        { 
            IQueryable<Product> result = db.Products;
            if (noTracking)
                result = result.AsNoTracking();
            return await result.FirstOrDefaultAsync(x => x.Id == id);
        }
        internal async Task<IEnumerable<Product>> GetAllProdcts(bool noTracking = true)
        {
            IQueryable<Product> result = db.Products;
            if (noTracking)
                result = result.AsNoTracking();
            return await result.ToListAsync();
        }
        internal async Task<IEnumerable<Product>?> GetProducts(
            Expression<Func<Product, bool>> predicate,
            bool noTracking = true)
        {
            IQueryable<Product> result = db.Products;
            if (noTracking)
                result = result.AsNoTracking();
            return await result.Where(predicate).ToListAsync();
        }

        internal async ValueTask Delete(int id)
        {
            Product? product = await GetProduct(id, noTracking: false);
            if (product is null)
                return;
            db.Products.Remove(product);
            await db.SaveChangesAsync();
        }
        internal async ValueTask Update(Product product)
        {
            db.Products.Update(product);
            await db.SaveChangesAsync();
        }
    }
}
