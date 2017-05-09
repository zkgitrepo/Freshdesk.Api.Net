using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Freshdesk.Sharp.Constants;
using Freshdesk.Sharp.Entities;
using Newtonsoft.Json;
using RestSharp;

namespace Freshdesk.Sharp
{
    public class ApiClient
    {
        private readonly string _apiKey;
        private readonly Uri _domain;

        public ApiClient(string apiKey, string domain)
        {
            _apiKey = apiKey;
            _domain = new Uri(domain);
        }

        public List<Contact> SearchContact(string email)
        {
            var result = ExecuteRequest($"{ApiV2Urls.Contacts}?email={email}", Method.GET);
            return result.StatusCode == HttpStatusCode.OK ? JsonConvert.DeserializeObject<List<Contact>>(result.Content) : new List<Contact>();
        }

        public Contact CreateContact(Contact contact)
        {
            contact.Active = null;
            contact.Deleted = null;
            contact.CreatedAt = null;

            var result = ExecuteRequest(ApiV2Urls.Contacts, Method.POST, contact);
            return result.StatusCode == HttpStatusCode.Created ? JsonConvert.DeserializeObject<Contact>(result.Content) : null;
        }
        public Contact ViewContact(string id)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                throw new Exception("Id is missing or empty");
            }
            var result = ExecuteRequest($"{ApiV2Urls.Contacts}/{id}", Method.GET);
            return result.StatusCode == HttpStatusCode.OK ? JsonConvert.DeserializeObject<Contact>(result.Content) : null;
        }

        public Contact UpdateContact(Contact contact)
        {
            if (contact.Id <= 0)
            {
                throw new Exception("Contact Id is missing");
            }
            var result = ExecuteRequest($"{ApiV2Urls.Contacts}/{contact.Id}", Method.PUT, contact);
            return result.StatusCode == HttpStatusCode.OK ? JsonConvert.DeserializeObject<Contact>(result.Content) : null;
        }
        public bool DeleteContact(string id)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                throw new Exception("Id is missing or empty");
            }
            var result = ExecuteRequest($"{ApiV2Urls.Contacts}/{id}", Method.DELETE);
            return result.StatusCode == HttpStatusCode.NoContent;
        }

        public List<Contact> ListAllContacts()
        {
            var result = ExecuteRequest(ApiV2Urls.Contacts, Method.GET);
            return result.StatusCode == HttpStatusCode.OK ? JsonConvert.DeserializeObject<List<Contact>>(result.Content) : new List<Contact>();
        }

        public Ticket CreateTicket(Ticket ticket)
        {
            ticket.Deleted = null;
            ticket.CreatedAt = null;
            ticket.HasFirstEscalated = null;
            ticket.IsEscalated= null;
            if (string.IsNullOrEmpty(ticket.Type)) ticket.Type = null;

            var result = ExecuteRequest(ApiV2Urls.Tickets, Method.POST, ticket);
            return result.StatusCode == HttpStatusCode.Created ? JsonConvert.DeserializeObject<Ticket>(result.Content) : null;
        }


        private IRestResponse ExecuteRequest(string apiUrl, Method method, object requestBody = null)
        {
            var client = new RestClient(GetUrl(apiUrl));
            var result = client.Execute(GetRequest(method, requestBody));

            return HandleResponse(result);

        }

        private RestRequest GetRequest(Method method, object requestBody = null)
        {
            var restRequest = new RestRequest(method);
            restRequest.AddHeader("cache-control", "no-cache");
            restRequest.AddHeader("Authorization", "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(_apiKey + ":X")));

            if (requestBody == null) return restRequest;

            var json = JsonConvert.SerializeObject(requestBody);
            restRequest.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);

            return restRequest;
        }

        private static IRestResponse HandleResponse(IRestResponse response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.BadRequest: //400
                case HttpStatusCode.Forbidden: //403
                case HttpStatusCode.NotFound: //404
                case HttpStatusCode.MethodNotAllowed: //405
                case HttpStatusCode.NotAcceptable: //406
                case HttpStatusCode.Conflict: //409
                case HttpStatusCode.UnsupportedMediaType: //415
                case HttpStatusCode.InternalServerError: //500
                    ThrowException(response);
                    break;
            }

            return response;
        }

        private static void ThrowException(IRestResponse response)
        {
            var errorResponse = JsonConvert.DeserializeObject<Errors>(response.Content);
            var errorText = new StringBuilder($"{response.StatusCode.ToString()} -> {errorResponse.Description} {errorResponse.Message}");
            foreach (var error in errorResponse.ErrorList)
            {
                errorText.Append($" | {error.Field} : {error.Message}");
            }
            throw new Exception(errorText.ToString());
        }

        private string GetUrl(string apiUrl)
        {

            var url = string.Format("{0}/{1}", _domain.AbsoluteUri, apiUrl)
                .Replace("https://", "")
                .Replace("http://", "")
                .Replace("//", "/");

            return string.Format("{0}://{1}", _domain.Scheme, url);
        }
    }
}
