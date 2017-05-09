using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Freshdesk.Sharp.Entities
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Contact
    {
        /// <summary>
        /// Set to true if the contact has been verified
        /// </summary>
        [JsonProperty(PropertyName = "active", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Active { get; set; }

        /// <summary>
        /// Address of the contact
        /// </summary>
        [JsonProperty(PropertyName = "address", NullValueHandling = NullValueHandling.Ignore)]
        public string Address { get; set; }

        /// <summary>
        /// Avatar of the contact
        /// </summary>
        [JsonProperty(PropertyName = "avatar", NullValueHandling = NullValueHandling.Ignore)]
        public object Avatar { get; set; }

        /// <summary>
        /// ID of the primary company to which this contact belongs
        /// </summary>
        [JsonProperty(PropertyName = "company_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? CompanyId { get; set; }

        /// <summary>
        /// Boolean	Set to true if the contact can see all tickets that are associated with the company to which he belong
        /// </summary>
        [JsonProperty(PropertyName = "view_all_tickets", NullValueHandling = NullValueHandling.Ignore)]
        public bool ViewAllTickets { get; set; }

        /// <summary>
        /// Key value pair containing the name and value of the custom fields. Plase see API docs for further info.
        /// </summary>
        [JsonProperty(PropertyName = "custom_fields", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> CustomFields { get; set; }

        /// <summary>
        /// Set to true if the contact has been deleted. Note that this attribute will only be present for deleted contacts
        /// </summary>
        [JsonProperty(PropertyName = "deleted", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Deleted { get; set; }

        /// <summary>
        /// A short description of the contact
        /// </summary>
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        /// <summary>
        /// Primary email address of the contact, must be Unique and MANDATORY. If you want to associate additional email(s) with this contact, use the other_emails attribute
        /// </summary>
        [JsonProperty(PropertyName = "email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        /// <summary>
        /// ID of the contact
        /// </summary>
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        /// <summary>
        /// Job title of the contact
        /// </summary>
        [JsonProperty(PropertyName = "job_title", NullValueHandling = NullValueHandling.Ignore)]
        public string JobTitle { get; set; }

        /// <summary>
        /// Language of the contact
        /// </summary>
        [JsonProperty(PropertyName = "language", NullValueHandling = NullValueHandling.Ignore)]
        public string Language { get; set; }

        /// <summary>
        /// Mobile number of the contact
        /// </summary>
        [JsonProperty(PropertyName = "mobile", NullValueHandling = NullValueHandling.Ignore)]
        public string Mobile { get; set; }

        /// <summary>
        /// Name of the contact (MANDATORY)
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Additional emails associated with the contact
        /// </summary>
        [JsonProperty(PropertyName = "other_emails", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> OtherEmails { get; set; }

        /// <summary>
        /// Telephone number of the contact
        /// </summary>
        [JsonProperty(PropertyName = "phone", NullValueHandling = NullValueHandling.Ignore)]
        public string Phone { get; set; }

        /// <summary>
        /// Tags associated with this contact
        /// </summary>
        [JsonProperty(PropertyName = "tags", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Tags { get; set; }

        /// <summary>
        /// Time zone in which the contact resides
        /// </summary>
        [JsonProperty(PropertyName = "time_zone", NullValueHandling = NullValueHandling.Ignore)]
        public string TimeZone { get; set; }

        /// <summary>
        /// Twitter handle of the contact, must be UNIQUE
        /// </summary>
        [JsonProperty(PropertyName = "twitter_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TwitterId { get; set; }

        /// <summary>
        /// Additional companies associated with the contact
        /// </summary>
        [JsonProperty(PropertyName = "other_companies", NullValueHandling = NullValueHandling.Ignore)]
        public List<Hashtable> OtherCompanies { get; set; }

        /// <summary>
        /// Contact creation timestamp
        /// </summary>
        [JsonProperty(PropertyName = "created_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Contact updated timestamp
        /// </summary>
        [JsonProperty(PropertyName = "updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? UpdatedAt { get; set; }
    }
}
