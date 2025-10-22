using Mango.Services.ShoppingCartAPI.Models.Dto;
using Mango.Web.Models;
using Mango.Web.Service.IServise;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;

namespace Mango.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        [Authorize]
        public async Task<IActionResult> CartIndex()
        {
            return View(await LoadCartDtoBasedOnLoggedInUser());
        }
        private async Task<cartDto>LoadCartDtoBasedOnLoggedInUser()
        {
            var userId = User.Claims.Where(u => u.Type == JwtRegisteredClaimNames.Sub)?.FirstOrDefault()?.Value;

            ResponseDto? response = await _cartService.GetCartByUserIdAsync(userId);
            if (response != null & response.IsSuccess)
            {
                cartDto cartDto = JsonConvert.DeserializeObject<cartDto>(Convert.ToString(response.Result));
                return cartDto;
            }
            return new cartDto();
        }
    }
}
