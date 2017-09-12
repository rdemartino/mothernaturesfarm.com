using System.Web.Mvc;
using mothernaturesfarm.web.Models;

namespace mothernaturesfarm.web.ViewModels
{
    public class VMCoupon : VMBase
    {
        private SelectList _states;

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string StreetAddress { get; set; }

        public string City { get; set; }

        public SelectList States
        {
            get
            {
                if (_states == null)
                    _states = new SelectList(StaticCollections.States, "Abbreviation", "Name");
                return(_states);
            }
        }

        public string SelectedState { get; set; }

        public string PostalCode { get; set; }

        public string RecommendedBy { get; set; }

        public bool AddToNewsletter { get; set; }
    }
}