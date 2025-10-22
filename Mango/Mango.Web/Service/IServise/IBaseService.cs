using Mango.Web.Models;

namespace Mango.Web.Service.IServise
{
    public interface IBaseService
    {
        Task<ResponseDto?> SendAsync(RequestDto requestDto, bool withBearer = true);

    }
}
