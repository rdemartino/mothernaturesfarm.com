using System.Collections.Generic;

namespace mothernaturesfarm.web.Models
{
    public static class StaticCollections
    {
        public static IEnumerable<State> States = new List<State>
        {
            new State {Abbreviation = "AZ", Name = "AZ"},
            new State {Abbreviation = "AL", Name = "AL"},
            new State {Abbreviation = "AK", Name = "AK"},
            new State {Abbreviation = "AR", Name = "AR"},
            new State {Abbreviation = "CA", Name = "CA"},
            new State {Abbreviation = "CO", Name = "CO"},
            new State {Abbreviation = "CT", Name = "CT"},
            new State {Abbreviation = "DE", Name = "DE"},
            new State {Abbreviation = "FL", Name = "FL"},
            new State {Abbreviation = "GA", Name = "GA"},
            new State {Abbreviation = "HI", Name = "HI"},
            new State {Abbreviation = "ID", Name = "ID"},
            new State {Abbreviation = "IL", Name = "IL"},
            new State {Abbreviation = "IN", Name = "IN"},
            new State {Abbreviation = "IA", Name = "IA"},
            new State {Abbreviation = "KS", Name = "KS"},
            new State {Abbreviation = "KY", Name = "KY"},
            new State {Abbreviation = "LA", Name = "LA"},
            new State {Abbreviation = "ME", Name = "ME"},
            new State {Abbreviation = "MD", Name = "MD"},
            new State {Abbreviation = "MA", Name = "MA"},
            new State {Abbreviation = "MI", Name = "MI"},
            new State {Abbreviation = "MN", Name = "MN"},
            new State {Abbreviation = "MS", Name = "MS"},
            new State {Abbreviation = "MO", Name = "MO"},
            new State {Abbreviation = "MT", Name = "MT"},
            new State {Abbreviation = "NE", Name = "NE"},
            new State {Abbreviation = "NV", Name = "NV"},
            new State {Abbreviation = "NH", Name = "NH"},
            new State {Abbreviation = "NJ", Name = "NJ"},
            new State {Abbreviation = "NM", Name = "NM"},
            new State {Abbreviation = "NY", Name = "NY"},
            new State {Abbreviation = "NC", Name = "NC"},
            new State {Abbreviation = "ND", Name = "ND"},
            new State {Abbreviation = "OH", Name = "OH"},
            new State {Abbreviation = "OK", Name = "OK"},
            new State {Abbreviation = "OR", Name = "OR"},
            new State {Abbreviation = "PA", Name = "PA"},
            new State {Abbreviation = "RI", Name = "RI"},
            new State {Abbreviation = "SC", Name = "SC"},
            new State {Abbreviation = "SD", Name = "SD"},
            new State {Abbreviation = "TN", Name = "TN"},
            new State {Abbreviation = "TX", Name = "TX"},
            new State {Abbreviation = "UT", Name = "UT"},
            new State {Abbreviation = "VT", Name = "VT"},
            new State {Abbreviation = "VA", Name = "VA"},
            new State {Abbreviation = "WA", Name = "WA"},
            new State {Abbreviation = "WV", Name = "WV"},
            new State {Abbreviation = "WI", Name = "WI"},
            new State {Abbreviation = "WY", Name = "WY"}
        };

        public static IEnumerable<UISelectItem> PartyTimes = new List<UISelectItem>
        {
            new UISelectItem() {Name="10:00 AM - 12:00 PM", Value = "10:00 AM - 12:00 PM"},
            new UISelectItem() {Name="1:00 PM - 3:00 PM", Value = "1:00 PM - 3:00 PM"},
            new UISelectItem() {Name="4:00 PM - 6:00 PM", Value = "4:00 PM - 6:00 PM"},
            new UISelectItem() {Name="7:00 PM - 9:00 PM", Value = "7:00 PM - 9:00 PM"}
        };

    }
}