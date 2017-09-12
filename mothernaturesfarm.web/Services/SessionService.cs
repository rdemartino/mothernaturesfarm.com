using System;
using System.Web;
using System.Web.SessionState;

namespace mothernaturesfarm.web.Services
{
    public class SessionService
    {
        private static readonly string SKEY_MEMBERID = "mbrid";

        public static int MemberId
        {
            get
            {
                if (SessionState[SKEY_MEMBERID] != null)
                    return (Convert.ToInt32(SessionState[SKEY_MEMBERID]));
                return (0);
            }
            set => SessionState[SKEY_MEMBERID] = value;
        }
        /// <summary>
        /// Gets the current HttpSessionState reference.
        /// </summary>
        private static HttpSessionState SessionState => (HttpContext.Current.Session);
    }
}