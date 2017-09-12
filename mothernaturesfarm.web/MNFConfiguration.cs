using System;
using System.Configuration;

namespace mothernaturesfarm.web
{
    public class MNFConfiguration
    {
        private const string CFG_DEF_CONNECTION_STRING_KEY = "mnf.cnstr";
        private const string CFG_EMAIL_PARTYRES_RECIPIENT = "email.partyres.recipient";
        private const string CFG_EMAIL_PARTYRES_SENDER = "email.partyres.sender";
        private const string CFG_EMAIL_PARTYRES_MINKIDS = "email.partyres.minkids";
        private const string CFG_EMAIL_TOURRES_RECIPIENT = "email.tourres.recipient";
        private const string CFG_EMAIL_TOURRES_SENDER = "email.tourres.sender";
        private const string CFG_EMAIL_TOURRES_MINKIDS = "email.tourres.minkids";
        private const string CFG_EMAIL_CONTACTUS_RECIPIENT = "email.contactus.recipient";
        private const string CFG_EMAIL_CONTACTUS_SENDER = "email.contactus.sender";
        private const string CFG_EMAIL_COUPON_RECIPIENT = "email.coupon.recipient";
        private const string CFG_EMAIL_COUPON_SENDER = "email.coupon.sender";
        private const string CFG_COUPON_CURRENTID = "coupon.currentid";
        private const string CFG_COUPON_IMGFILEPATH = "coupon.imgfilepath";


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

        public static string CouponImageFilePath
        {
            get
            {
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings[CFG_COUPON_IMGFILEPATH]))
                    return (ConfigurationManager.AppSettings[CFG_COUPON_IMGFILEPATH]);
                throw new Exception("Coupon Image file path not defined");
            }
        }

        public static string CouponRecipient
        {
            get
            {
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings[CFG_EMAIL_COUPON_RECIPIENT]))
                    return (ConfigurationManager.AppSettings[CFG_EMAIL_COUPON_RECIPIENT]);
                throw new Exception("Coupon Recipient not defined");
            }
        }

        public static string CouponSender
        {
            get
            {
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings[CFG_EMAIL_COUPON_SENDER]))
                    return (ConfigurationManager.AppSettings[CFG_EMAIL_COUPON_SENDER]);
                throw new Exception("Coupon Sender not defined");
            }
        }

        public static int CouponCurrentId
        {
            get
            {
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings[CFG_COUPON_CURRENTID]))
                    return (Convert.ToInt32(ConfigurationManager.AppSettings[CFG_COUPON_CURRENTID]));
                throw new Exception("Current Coupon ID not defined");
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

        public static int PartyReservationMinKids
        {
            get
            {
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings[CFG_EMAIL_PARTYRES_MINKIDS]))
                    return (Convert.ToInt32(ConfigurationManager.AppSettings[CFG_EMAIL_PARTYRES_MINKIDS]));
                throw new Exception("Party Reservation Min Kids not defined");
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

        public static int TourReservationMinKids
        {
            get
            {
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings[CFG_EMAIL_TOURRES_MINKIDS]))
                    return (Convert.ToInt32(ConfigurationManager.AppSettings[CFG_EMAIL_TOURRES_MINKIDS]));
                throw new Exception("Tour Reservation Min Kids not defined");
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