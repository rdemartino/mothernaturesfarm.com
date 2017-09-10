using System;
using System.Configuration;

namespace mothernaturesfarm.web
{
    public class MNFConfiguration
    {
        private const string CFG_DEF_CONNECTION_STRING_KEY = "mnf.cnstr";
        private const string CFG_EMAIL_PARTYRES_RECIPIENT = "email.partyres.recipient";
        private const string CFG_EMAIL_PARTYRES_SENDER = "email.partyres.sender";
        private const string CFG_EMAIL_TOURRES_RECIPIENT = "email.tourres.recipient";
        private const string CFG_EMAIL_TOURRES_SENDER = "email.tourres.sender";
        private const string CFG_EMAIL_CONTACTUS_SENDER = "email.contactus.sender";
        private const string CFG_EMAIL_CONTACTUS_RECIPIENT = "email.contactus.recipient";

        /// <summary>
        /// Gets the DB connection string key.  This is the KEY used to retrieve the connection string, not
        /// the connectionstring itself.  Only the Key is needed when using Enterprise Library for data access.
        /// </summary>
        public static string DBConnectionStringKey
        {
            get
            {
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings[CFG_DEF_CONNECTION_STRING_KEY]))
                    return (ConfigurationManager.AppSettings[CFG_DEF_CONNECTION_STRING_KEY]);
                throw new Exception("Connection String Not Defined");
            }
        }

        public static string ContactUsRecipient
        {
            get
            {
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings[CFG_EMAIL_CONTACTUS_RECIPIENT]))
                    return (ConfigurationManager.AppSettings[CFG_EMAIL_CONTACTUS_RECIPIENT]);
                throw new Exception("Contact Us Recipient not defined");
            }
        }

        public static string ContactUsSender
        {
            get
            {
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings[CFG_EMAIL_CONTACTUS_SENDER]))
                    return (ConfigurationManager.AppSettings[CFG_EMAIL_CONTACTUS_SENDER]);
                throw new Exception("Contact Us Sender not defined");
            }
        }


        public static string PartyReservationRecipient
        {
            get
            {
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings[CFG_EMAIL_PARTYRES_RECIPIENT]))
                    return (ConfigurationManager.AppSettings[CFG_EMAIL_PARTYRES_RECIPIENT]);
                throw new Exception("Party Reservation Recipient not defined");
            }
        }

        public static string PartyReservationSender
        {
            get
            {
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings[CFG_EMAIL_PARTYRES_SENDER]))
                    return (ConfigurationManager.AppSettings[CFG_EMAIL_PARTYRES_SENDER]);
                throw new Exception("Party Reservation Sender not defined");
            }
        }

        public static string TourReservationRecipient
        {
            get
            {
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings[CFG_EMAIL_TOURRES_RECIPIENT]))
                    return (ConfigurationManager.AppSettings[CFG_EMAIL_TOURRES_RECIPIENT]);
                throw new Exception("Tour Reservation Recipient not defined");
            }
        }

        public static string TourReservationSender
        {
            get
            {
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings[CFG_EMAIL_TOURRES_SENDER]))
                    return (ConfigurationManager.AppSettings[CFG_EMAIL_TOURRES_SENDER]);
                throw new Exception("Tour Reservation Sender not defined");
            }
        }
    }
}