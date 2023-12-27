using Microsoft.EntityFrameworkCore;
using ProducerServices.Data;
using ProducerServices.Entities;

namespace ProducerServices.Services.Implementation
{
    public class OrderRequestService : IOrderRequestService
    {
        private readonly OrderRequestDbContext _dbContext;
        public OrderRequestService(OrderRequestDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<OrderRequest> CreateUpdateOrderRequest(OrderRequest orderrequest)
        {
            if (orderrequest.OrderId > 0)
            {
                _dbContext.OrderRequests.Add(orderrequest);
            }
            else
            {
                _dbContext.OrderRequests.Update(orderrequest);
            }
            await _dbContext.SaveChangesAsync();
             return orderrequest;
        }

        public async Task<bool> DeleteOrderRequest(int id)
        {
            var deletingOrderReq =await _dbContext.OrderRequests.FirstOrDefaultAsync(orderReq => orderReq.OrderId == id);
            if (deletingOrderReq == null) { 
                return false; 
            }
            _dbContext.Remove(deletingOrderReq);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IList<OrderRequest>> GetAllOrderRequests()
        {
            var orderRequests = await _dbContext.OrderRequests.ToListAsync();
            return orderRequests;
        }

        public async Task<OrderRequest> GetOrderRequestById(int id)
        {
            OrderRequest? orderRequest =await _dbContext.OrderRequests.Where(ele=>ele.OrderId==id).FirstOrDefaultAsync();
            return orderRequest;
        }
    }
}
