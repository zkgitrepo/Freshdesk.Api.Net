using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using RestSharp;

namespace Freshdesk.Sharp.Entities
{
    public class Contacts
    {
        public const string ApiUrl = "/api/v2/contacts";

        internal ApiClient ApiClient { get; set; }

        public List<Contact> Search(string email)
        {
            var result = ApiClient.ExecuteRequest($"{ApiUrl}?email={email}", Method.GET);
            return result.StatusCode == HttpStatusCode.OK ? JsonConvert.DeserializeObject<List<Contact>>(result.Content) : new List<Contact>();
        }

        public Contact Create(Contact contact)
        {
            contact.Active = null;
            contact.Deleted = null;
            contact.CreatedAt = null;

            var result = ApiClient.ExecuteRequest(ApiUrl, Method.POST, contact);
            return result.StatusCode == HttpStatusCode.Created ? JsonConvert.DeserializeObject<Contact>(result.Content) : null;
        }
        public Contact View(string id)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                throw new Exception("Id is missing or empty");
            }
            var result = ApiClient.ExecuteRequest($"{ApiUrl}/{id}", Method.GET);
            return result.StatusCode == HttpStatusCode.OK ? JsonConvert.DeserializeObject<Contact>(result.Content) : null;
        }

        public Contact Update(Contact contact)
        {
            if (contact.Id <= 0)
            {
                throw new Exception("Contact Id is missing");
            }
            var result = ApiClient.ExecuteRequest($"{ApiUrl}/{contact.Id}", Method.PUT, contact);
            return result.StatusCode == HttpStatusCode.OK ? JsonConvert.DeserializeObject<Contact>(result.Content) : null;
        }
        public bool Delete(string id)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                throw new Exception("Id is missing or empty");
            }
            var result = ApiClient.ExecuteRequest($"{ApiUrl}/{id}", Method.DELETE);
            return result.StatusCode == HttpStatusCode.NoContent;
        }

        public List<Contact> ListAll()
        {
            var result = ApiClient.ExecuteRequest(ApiUrl, Method.GET);
            return result.StatusCode == HttpStatusCode.OK ? JsonConvert.DeserializeObject<List<Contact>>(result.Content) : new List<Contact>();
        }
    }
}
