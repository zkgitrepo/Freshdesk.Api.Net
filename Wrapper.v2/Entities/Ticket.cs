using System;
using System.Collections.Generic;
using Freshdesk.Sharp.Enums;
using Newtonsoft.Json;

namespace Freshdesk.Sharp.Entities
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Ticket
    {
        /// <summary>
        /// Ticket attachments. The total size of these attachments cannot exceed 15MB.
        /// </summary>
        [JsonProperty(PropertyName = "attachments", NullValueHandling = NullValueHandling.Ignore)]
        public object[] Attachments { get; set; }

        /// <summary>
        /// Email address added in the 'cc' field of the incoming ticket email
        /// </summary>
        [JsonProperty(PropertyName = "cc_emails", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> CcEmails { get; set; }

        /// <summary>
        /// ID of the company to which this ticket belongs
        /// </summary>
        [JsonProperty(PropertyName = "company_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? CompanyId { get; set; }

        /// <summary>
        /// Key value pairs containing the names and values of custom fields. Check API docs for further details.
        /// </summary>
        [JsonProperty(PropertyName = "custom_fields", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> CustomFields { get; set; }

        /// <summary>
        /// Set to true if the ticket has been deleted/trashed. Deleted tickets will not be displayed in any views except the "deleted" filter
        /// </summary>
        [JsonProperty(PropertyName = "deleted", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Deleted { get; set; }

        /// <summary>
        /// HTML content of the ticket
        /// </summary>
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        /// <summary>
        /// Content of the ticket in plain text
        /// </summary>
        [JsonProperty(PropertyName = "description_text", NullValueHandling = NullValueHandling.Ignore)]
        public string DescriptionText { get; set; }

        /// <summary>
        /// Timestamp that denotes when the ticket is due to be resolved
        /// </summary>
        [JsonProperty(PropertyName = "due_by", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? DueBy { get; set; }

        /// <summary>
        /// Email address of the requester. If no contact exists with this email address in Freshdesk, it will be added as a new contact.
        /// </summary>
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        /// <summary>
        /// ID of email config which is used for this ticket. (i.e., support@yourcompany.com/sales@yourcompany.com)
        /// </summary>
        [JsonProperty(PropertyName = "email_config_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? EmailConfigId { get; set; }

        /// <summary>
        /// Facebook ID of the requester. A contact should exist with this facebook_id in Freshdesk.
        /// </summary>
        [JsonProperty(PropertyName = "facebook_id", NullValueHandling = NullValueHandling.Ignore)]
        public string FacebookId { get; set; }

        /// <summary>
        /// Timestamp that denotes when the first response is due
        /// </summary>
        [JsonProperty(PropertyName = "fr_due_by", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? FirstResponseDue { get; set; }

        /// <summary>
        /// Set to true if the ticket has been escalated as the result of first response time being breached
        /// </summary>
        [JsonProperty(PropertyName = "fr_escalated", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasFirstEscalated { get; set; }

        /// <summary>
        /// Email address(e)s added while forwarding a ticket
        /// </summary>
        [JsonProperty(PropertyName = "fwd_emails", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> ForwardEmails { get; set; }

        /// <summary>
        /// ID of the group to which the ticket has been assigned
        /// </summary>
        [JsonProperty(PropertyName = "group_id", NullValueHandling = NullValueHandling.Ignore)]
        public object GroupId { get; set; }

        /// <summary>
        /// Unique ID of the ticket
        /// </summary>
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        /// <summary>
        /// Set to true if the ticket has been escalated for any reason
        /// </summary>
        [JsonProperty(PropertyName = "is_escalated", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsEscalated { get; set; }

        /// <summary>
        /// Name of the requester
        /// </summary>
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// Phone number of the requester. If no contact exists with this phone number in Freshdesk, it will be added as a new contact. If the phone number is set and the email address is not, then the name attribute is mandatory.
        /// </summary>
        [JsonProperty(PropertyName = "phone", NullValueHandling = NullValueHandling.Ignore)]
        public string Phone { get; set; }

        /// <summary>
        /// Priority of the ticket
        /// </summary>
        [JsonProperty(PropertyName = "priority", NullValueHandling = NullValueHandling.Ignore)]
        public TicketPriority Priority { get; set; }

        /// <summary>
        /// ID of the product to which the ticket is associated
        /// </summary>
        [JsonProperty(PropertyName = "product_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? ProductId { get; set; }

        /// <summary>
        /// Email address added while replying to a ticket
        /// </summary>
        [JsonProperty(PropertyName = "reply_cc_emails", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> ReplyCcEmails { get; set; }

        /// <summary>
        /// User ID of the requester. For existing contacts, the requester_id can be passed instead of the requester's email.
        /// </summary>
        [JsonProperty(PropertyName = "requester_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? RequesterId { get; set; }

        /// <summary>
        /// ID of the agent to whom the ticket has been assigned
        /// </summary>
        [JsonProperty(PropertyName = "responder_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? ResponderId { get; set; }

        /// <summary>
        /// The channel through which the ticket was created
        /// </summary>
        [JsonProperty(PropertyName = "source", NullValueHandling = NullValueHandling.Ignore)]
        public TicketSource Source { get; set; }

        /// <summary>
        /// Set to true if the ticket has been marked as spam
        /// </summary>
        [JsonProperty(PropertyName = "spam", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Spam { get; set; }

        /// <summary>
        /// Status of the ticket
        /// </summary>
        [JsonProperty(PropertyName = "status", NullValueHandling = NullValueHandling.Ignore)]
        public TicketStatus Status { get; set; }

        /// <summary>
        /// Subject of the ticket
        /// </summary>
        [JsonProperty(PropertyName = "subject", NullValueHandling = NullValueHandling.Ignore)]
        public string Subject { get; set; }

        /// <summary>
        /// Tags that have been associated with the ticket
        /// </summary>
        [JsonProperty(PropertyName = "tags", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Tags { get; set; }

        /// <summary>
        /// Email addresses to which the ticket was originally sent
        /// </summary>
        [JsonProperty(PropertyName = "to_emails", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> ToEmails { get; set; }

        /// <summary>
        /// Twitter handle of the requester. If no contact exists with this handle in Freshdesk, it will be added as a new contact.
        /// </summary>
        [JsonProperty(PropertyName = "twitter_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TwitterId { get; set; }

        /// <summary>
        /// Helps categorize the ticket according to the different kinds of issues your support team deals with.
        /// </summary>
        [JsonProperty(PropertyName = "type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        /// <summary>
        /// Ticket creation timestamp
        /// </summary>
        [JsonProperty(PropertyName = "created_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Ticket updated timestamp
        /// </summary>
        [JsonProperty(PropertyName = "updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? UpdatedAt { get; set; }
    }
}
