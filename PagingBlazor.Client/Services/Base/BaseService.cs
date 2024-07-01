namespace PagingBlazor.Client.Services.Base
{
    public class BaseService
    {
        protected readonly HttpClient _httpClient;


        public BaseService(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }
    }
}
