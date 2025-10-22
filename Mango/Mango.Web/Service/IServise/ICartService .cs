using Mango.Services.ShoppingCartAPI.Models.Dto;
using Mango.Web.Models;

namespace Mango.Web.Service.IServise
{
    public interface ICartService
    {
        Task<ResponseDto?> GetCartByUserIdAsync(string UserId);
        Task<ResponseDto?> UpsertCartAsync(cartDto cartDto);
        Task<ResponseDto?> RemoveFromCartAsync(int cartDetailsId);
        Task<ResponseDto?> ApplyCouponCartAsync(cartDto cartDto);
    }
}
