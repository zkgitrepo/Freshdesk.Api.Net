using Freshdesk.Sharp.Entities;

namespace Freshdesk.Sharp
{
    public class FreshdeskClient
    {
        private readonly ApiClient _apiClient;

        public Contacts Contacts => new Contacts { ApiClient = _apiClient };
        public Tickets Tickets => new Tickets { ApiClient = _apiClient };

        public FreshdeskClient(string apiKey, string domain)
        {
            _apiClient=new ApiClient(apiKey, domain);
        }
    }
}
