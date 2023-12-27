using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProducerServices.Entities;
using ProducerServices.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProducerServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderRequestsController : ControllerBase
    {

        public readonly IOrderRequestService orderRequestService;

        public OrderRequestsController(IOrderRequestService _orderRequestService)
        {
            orderRequestService = _orderRequestService;
        }
        // GET: api/<OrderRequestsController>
        [HttpGet]
        public async Task<IList<OrderRequest>> GetAll()
        {
           var orderRequests=await orderRequestService.GetAllOrderRequests();
            return orderRequests;
    }

        // GET api/<OrderRequestsController>/5
        [HttpGet("{id}")]
        public async Task<OrderRequest> Get(int id)
        {
            var orderRequest =await orderRequestService.GetOrderRequestById(id);
            return orderRequest;
        }

        //// POST api/<OrderRequestsController>
        ///[HttpPost("resource")] added for apigateway
        [HttpPost("resource")]
        public async Task<IActionResult> Post([FromBody] OrderRequest orderRequest)
        {
            try
            {
                var orderRequestElem =await orderRequestService.CreateUpdateOrderRequest(orderRequest);
                return StatusCode(StatusCodes.Status201Created, orderRequestElem.ProductId+ " ~ "+ orderRequestElem.CustomerId + " Added successfully!!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        //// DELETE api/<OrderRequestsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool result =await orderRequestService.DeleteOrderRequest(id);
                if(result)
                return StatusCode(StatusCodes.Status200OK,id + " deleted successfully!!");
                else
                    return StatusCode(StatusCodes.Status202Accepted);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
