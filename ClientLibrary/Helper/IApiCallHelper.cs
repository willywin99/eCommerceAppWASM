using ClientLibrary.Models;

namespace ClientLibrary.Helper
{
    public interface IApiCallHelper
    {
        Task<HttpResponseMessage> ApiCallTyeCall<TModel>(ApiCall apiCall);
        Task<TResponse> GetServiceResponse<TResponse>(HttpResponseMessage message);
        ServiceResponse ConnectionError();
    }
}
