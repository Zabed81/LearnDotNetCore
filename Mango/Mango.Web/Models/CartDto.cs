using Mango.Web.Models;

namespace Mango.Services.ShoppingCartAPI.Models.Dto
{
    public class cartDto
    {
        public CartHeaderDto CartHeader { get; set; }
        public IEnumerable<CartDetailsDto>? CartDetails { get; set; }
    }
}
