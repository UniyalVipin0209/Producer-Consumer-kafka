using ProducerServices.Entities;

namespace ProducerServices.Services
{
    public interface IOrderRequestService
    {
        Task<IList<OrderRequest>> GetAllOrderRequests();

        Task<OrderRequest> GetOrderRequestById(int id);

        Task<OrderRequest> CreateUpdateOrderRequest(OrderRequest orderrequest);

        Task<bool> DeleteOrderRequest(int id);
    }
}
