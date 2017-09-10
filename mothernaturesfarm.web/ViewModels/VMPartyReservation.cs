using System;
using System.Web.Mvc;
using mothernaturesfarm.web.Models;

namespace mothernaturesfarm.web.ViewModels
{
    public class VMPartyReservation : VMBase
    {

        private SelectList _states;
        private SelectList _partyTimes;

        public string ParentName { get; set; }

        public string ParentEmail { get; set; }

        public string HomePhone { get; set; }

        public string CellPhone { get; set; }

        public string StreetAddress { get; set; }

        public string City { get; set; }

        public SelectList States
        {
            get
            {
                if (_states == null)
                    _states = new SelectList(StaticCollections.States, "Abbreviation", "Name");
                return (_states);
            }
        }

        public string SelectedState { get; set; }

        public string PostalCode { get; set; }

        public string ChildName { get; set; }

        public int? ChildAge { get; set; }

        
        public DateTime PartyDate { get; set; }

        public SelectList PartyTimes
        {
            get
            {
                if (_partyTimes == null)
                    _partyTimes = new SelectList(StaticCollections.PartyTimes, "Name", "Value");
                return(_partyTimes);
            }
        }

        public string SelectedPartyTime { get; set; }

        public int? NumberOfKids { get; set; }

        public int? NumberOfAdults { get; set; }

        public bool AddPrivateArea { get; set; }

        public string Comments { get; set; }
    }
}