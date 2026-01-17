using ClientLibrary.Helper;
using ClientLibrary.Models;
using ClientLibrary.Models.Cart;

namespace ClientLibrary.Services
{
    public class CartService(
        IHttpClientHelper httpClient,
        IApiCallHelper apiHelper
    ) : ICartService
    {
        public async Task<ServiceResponse> Checkout(Checkout checkout)
        {
            var privateClient = await httpClient.GetPrivateClientAsync();
            var apiCallModel = new ApiCall
            {
                Route = Constant.Cart.Checkout,
                Type = Constant.ApiCallType.Post,
                Client = privateClient,
                Id = null!,
                Model = checkout,
            };
            var result = await apiHelper.ApiCallTyeCall<Checkout>(apiCallModel);

            if (result == null)
                return apiHelper.ConnectionError();
            else
                return await apiHelper.GetServiceResponse<ServiceResponse>(result);
        }

        public async Task<IEnumerable<GetAchieve>> GetAchieves()
        {
            var client = await httpClient.GetPrivateClientAsync();
            var apiCall = new ApiCall
            {
                Route = Constant.Cart.GetAchieves,
                Type = Constant.ApiCallType.Get,
                Client = client,
                Model = null!,
                Id = null!,
            };
            var result = await apiHelper.ApiCallTyeCall<Dummy>(apiCall);
            if (result.IsSuccessStatusCode)
                return await apiHelper.GetServiceResponse<IEnumerable<GetAchieve>>(result);
            else
                return [];
        }

        public async Task<ServiceResponse> SaveCheckoutHistory(IEnumerable<CreateAchieve> achieves)
        {
            var privateClient = await httpClient.GetPrivateClientAsync();
            var apiCallModel = new ApiCall
            {
                Route = Constant.Cart.SaveCart,
                Type = Constant.ApiCallType.Post,
                Client = privateClient,
                Id = null!,
                Model = achieves,
            };
            var result = await apiHelper.ApiCallTyeCall<IEnumerable<CreateAchieve>>(apiCallModel);

            if (result == null)
                return apiHelper.ConnectionError();
            else
                return await apiHelper.GetServiceResponse<ServiceResponse>(result);
        }
    }
}
