using Mango.Web.Models;

namespace Mango.Web.Service.IServise
{
    public interface ICouponService
    {
        Task<ResponseDto?> GetCouponAsync(string couponCode);
        Task<ResponseDto?> GetAllCouponsAsync();
        Task<ResponseDto?> GetCouponByIdAsync(int id);
        Task<ResponseDto?> CreateCouponsAsync(couponDto model);
        Task<ResponseDto?> UpdateCouponsAsync(couponDto model);
        Task<ResponseDto?> DeleteCouponsAsync(int id);
    }
}
