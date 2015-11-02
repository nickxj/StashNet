using System.Threading;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Serializers;

namespace StashNet.Resources
{
    public abstract class StashboardResourcesBase
    {
        protected StashboardResourcesBase(RestClient client)
        {
            Client = client;
        }

        protected RestClient Client { get; set; }

        protected virtual Task<IRestResponse> Get(string url, CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new RestRequest(url, Method.GET);

            return Client.ExecuteTaskAsync(request, cancellationToken);
        }

        protected virtual Task<IRestResponse> Delete(string url, CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new RestRequest(url, Method.DELETE)
            {
                JsonSerializer = new JsonSerializer(),
                RequestFormat = DataFormat.Json
            };
            return Client.ExecuteTaskAsync(request, cancellationToken);
        }

        protected virtual Task<IRestResponse> Put<T>(string url, T value, CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new RestRequest(url, Method.PUT)
            {
                JsonSerializer = new JsonSerializer(),
                RequestFormat = DataFormat.Json
            };
            request.AddJsonBody(value);

            return Client.ExecuteTaskAsync(request, cancellationToken);
        }

        protected virtual Task<IRestResponse> Post<T>(string url, T value, CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new RestRequest(url, Method.POST);
            request.AddObject(value);

            return Client.ExecutePostTaskAsync(request, cancellationToken);
        }
    }
}