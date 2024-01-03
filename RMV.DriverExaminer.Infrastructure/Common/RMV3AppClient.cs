namespace RMV.DriverExaminer.Infrastructure.Common
{
    //https://johnthiriet.com/efficient-api-calls/
    public interface IRMV3AppClient
    {
        Task<HttpResponseMessage> GetData(string apiAction, CancellationToken cancellationToken);
    }
    public class RMV3AppClient : IRMV3AppClient
    {
        private readonly HttpClient _httpClient;

        public RMV3AppClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://api.publicapis.org/");
            //httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.xxx.v3+json");
            //httpClient.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<HttpResponseMessage> GetData(string apiAction, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetAsync(apiAction);
                if (!response.IsSuccessStatusCode)
                    throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");
                    
           return response;
                
        }
    }
}
