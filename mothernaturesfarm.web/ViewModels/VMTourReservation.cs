using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using mothernaturesfarm.web.Models;

namespace mothernaturesfarm.web.ViewModels
{
    public class VMTourReservation
    {
        private SelectList _states;
        private SelectList _tourTimes;

        public string SchoolName { get; set; }

        public string SchoolAddress { get; set; }

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

        public string SchoolPhone { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SchoolFax { get; set; }

        public string TeacherName { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string TeacherAide { get; set; }

        public string TeacherEmail { get; set; }

        public string TeacherCellPhone { get; set; }

        public int? NumberOfKids { get; set; }

        public string IncludePackage { get; set; }

        public int? NumberOfAdults { get; set; }

        public string TourDate1 { get; set; }

        public string TourDate2 { get; set; }

        public string TourDate3 { get; set; }

        public SelectList TourTimes
        {
            get
            {
                if (_tourTimes == null)
                    _tourTimes = new SelectList(StaticCollections.TourTimes, "Name", "Value");
                return(_tourTimes);
            }
        }

        public string SelectedTourTime1 { get; set; }

        public string SelectedTourTime2 { get; set; }

        public string SelectedTourTime3 { get; set; }

    }
}
