using Microsoft.AspNetCore.Mvc;
using Skinet_Core.Entities;
using Skinet_Core.Interfaces;
using System.Threading.Tasks;

namespace Skinet_API.Controllers
{
    public class BasketController : BaseApiController
    {
        public readonly IBasketRepository _basketRepository;
        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }


        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetCutomerById(string Id)
        {
            var basket = await _basketRepository.GetBasketAsync(Id);
            return Ok(basket??new CustomerBasket(Id));
        }
        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasket basket)
        { 
            var updatedBasket= await _basketRepository.UpdateBasketAsync(basket);
            return Ok(updatedBasket);
        }
        [HttpDelete]
        public async Task DeleteBasket(string Id)
        {
            await _basketRepository.DeleteBasketAsync(Id);
        }
    }
}
