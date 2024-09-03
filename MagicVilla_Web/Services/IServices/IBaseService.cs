using MagicVilla_Web.Models;
using MagicVilla_Web.Models.APIResponses;

namespace MagicVilla_Web.Services.IServices
{
    public interface IBaseService
    {
       APIResponse responseModel { get; set; }
       Task<T> SendAsync<T>(APIRequest apiRequest);
    }
}
