using Microsoft.EntityFrameworkCore;
using Shop.Abstractions.Repository;
using Shop.MessageContracts.Products.Models;

namespace Shop.DataAccess.Repository;
public class ProductRepository : IProductRepository
{
    private readonly EfContext _dbContext;
    ProductRepository(
        EfContext db)
    {
        _dbContext = db;
    }
    public DbSet<ProductDTO> Entities => throw new NotImplementedException();

    public async Task AddAsync(ProductDTO entity)
    {
        await _dbContext.Products.AddAsync(DTOconverter.ToProduct(entity));

        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<ProductDTO>> GetAllAsync()
    {
        var result = await _dbContext.Products.ToListAsync();

        return DTOconverter.ToProductDTOs(result);
    }

    public async Task<ProductDTO?> GetByIdAsync(Guid id)
    {
        var result = await _dbContext.Products
            .FirstOrDefaultAsync(x => x.Id == id);

        return DTOconverter.ToProductDTO(result);
    }

    public async Task RemoveAsync(ProductDTO entity)
    {
        _dbContext.Products.Remove(DTOconverter.ToProduct(entity));

        await _dbContext.SaveChangesAsync();
    }

    public Task UpdateAsync(ProductDTO entity)
    {
        throw new NotImplementedException();
    }
}
