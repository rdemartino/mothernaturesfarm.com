using System;

namespace mothernaturesfarm.web.Models
{
    public class Member
    {
        public Member()
        {
            MemberId = 0;
            EmailAddress = string.Empty;
            Password = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            Address1 = string.Empty;
            Address2 = string.Empty;
            City = string.Empty;
            State = string.Empty;
            PostalCode = string.Empty;
            IsEnabled = false;
            NewsletterSubscriber = false;
            DateCreated = DateTime.Now;
        }
        public int MemberId { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string RecommendedBy { get; set; }
        public bool IsEnabled { get; set; }
        public bool NewsletterSubscriber { get; set; }
        public DateTime DateCreated { get; set; }
    }
}