using System.Net;
using Newtonsoft.Json;
using RestSharp;

namespace Freshdesk.Sharp.Entities
{
    public class Tickets
    {
        public const string ApiUrl = "/api/v2/tickets";

        internal ApiClient ApiClient { get; set; }

        public Ticket Create(Ticket ticket)
        {
            ticket.Deleted = null;
            ticket.CreatedAt = null;
            ticket.HasFirstEscalated = null;
            ticket.IsEscalated = null;
            if (string.IsNullOrEmpty(ticket.Type)) ticket.Type = null;

            var result = ApiClient.ExecuteRequest(ApiUrl, Method.POST, ticket);
            return result.StatusCode == HttpStatusCode.Created ? JsonConvert.DeserializeObject<Ticket>(result.Content) : null;
        }
    }
}
