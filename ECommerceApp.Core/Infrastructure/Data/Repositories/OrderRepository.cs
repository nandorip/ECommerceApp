using ECommerceApp.Core.Features.Orders.Repositories;

namespace ECommerceApp.Core.Infrastructure.Data.Repositories;

public class OrderRepository : IOrderRepository
{
    //private readonly ApplicationDbContext _dbContext;

    //public OrderRepository(ApplicationDbContext dbContext)
    //{
    //    _dbContext = dbContext;
    //}

    public OrderRepository() { }

    public async Task<Order> GetByIdAsync(Guid orderId)
    {
        throw new NotImplementedException();
        //return await _dbContext.Orders.FindAsync(orderId);
    }

    public Task<IEnumerable<Order>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Order order)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Order order)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
