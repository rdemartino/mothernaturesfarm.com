using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using mothernaturesfarm.web.DataAccess;
using mothernaturesfarm.web.Models;
using mothernaturesfarm.web.ViewModels;

namespace mothernaturesfarm.web.Services
{
    public class CouponService
    {
        private const float COUPONIMG_CONTENT_TOP = 200;
        private const float COUPONIMG_MARGINOFFSET = 5;
        private const float COUPONIMG_HEIGHT_ADJUSTMENT = 2;

        private bool CouponRegistrationIsValid(VMCoupon vmCoupon)
        {
            return(!(string.IsNullOrWhiteSpace(vmCoupon.Email) || string.IsNullOrWhiteSpace(vmCoupon.FirstName) ||
                     string.IsNullOrWhiteSpace(vmCoupon.LastName) || string.IsNullOrWhiteSpace(vmCoupon.PostalCode) ||
                     string.IsNullOrWhiteSpace(vmCoupon.StreetAddress) || string.IsNullOrWhiteSpace(vmCoupon.City)));
        }

        private Member UpdateMember(MNFData mnfData, VMCoupon vmCoupon)
        {
            Member mbr = mnfData.FindMember(vmCoupon.Email.Trim());
            mbr.FirstName = vmCoupon.FirstName.Trim();
            mbr.LastName = vmCoupon.LastName.Trim();
            mbr.Address1 = vmCoupon.StreetAddress.Trim();
            mbr.EmailAddress = vmCoupon.Email.Trim();
            mbr.City = vmCoupon.City.Trim();
            mbr.State = vmCoupon.SelectedState;
            mbr.PostalCode = vmCoupon.PostalCode.Trim();
            mbr.RecommendedBy = vmCoupon.RecommendedBy.Trim();
            mnfData.UpdateMember(mbr);
            return(mbr);
        }

        private Member CreateMember(MNFData mnfData, VMCoupon vmCoupon)
        {
            Member mbr = new Member();
            mbr.FirstName = vmCoupon.FirstName.Trim();
            mbr.LastName = vmCoupon.LastName.Trim();
            mbr.Address1 = vmCoupon.StreetAddress.Trim();
            mbr.EmailAddress = vmCoupon.Email.Trim();
            mbr.City = vmCoupon.City.Trim();
            mbr.State = vmCoupon.SelectedState;
            mbr.PostalCode = vmCoupon.PostalCode.Trim();
            mbr.RecommendedBy = vmCoupon.RecommendedBy.Trim();
            mbr.IsEnabled = true;
            mbr.NewsletterSubscriber = vmCoupon.AddToNewsletter;

            mnfData.InsertMember(mbr);
            return (mbr);
        }

        public CouponRegistrationResult RegisterMember(VMCoupon vmCoupon)
        {
            if (!CouponRegistrationIsValid(vmCoupon))
                return(CouponRegistrationResult.MissingRequiredData);

            MNFData mnfData = new MNFData();
            Member mbr = null;
            bool mbrExists = mnfData.MemberExists(vmCoupon.Email.Trim());

            if (mbrExists)
                mbr = UpdateMember(mnfData, vmCoupon);
            else
                mbr = CreateMember(mnfData, vmCoupon);

            if (mbr != null)
            {
                SessionService.MemberId = mbr.MemberId;

                CouponMemberUsage cmu = new CouponMemberUsage();
                cmu.CouponId = MNFConfiguration.CouponCurrentId;
                cmu.MemberId = mbr.MemberId;
                mnfData.InsertCouponMemberUsage(cmu);

                //Only send emails for NEW members
                if (!mbrExists)
                {
                    EmailNotificationServices emailSrvs = new EmailNotificationServices();
                    if (emailSrvs.SendNotification(vmCoupon) != SendNotificationResult.Success)
                        return(CouponRegistrationResult.UnknownException);
                }

                return(CouponRegistrationResult.Success);
            }
            return(CouponRegistrationResult.UnknownException);
        }

        public Image RenderCouponImage(Member mbr, Image baseImage)
        {
            Graphics g = Graphics.FromImage(baseImage);
            float lblX, x, y;
            lblX = 40;
            x = 125;
            y = COUPONIMG_CONTENT_TOP;
            Brush brsh = Brushes.Black;
            Font fLbl = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
            Font f = new Font(FontFamily.GenericSansSerif, 12);
            SizeF fSzF = g.MeasureString("W", fLbl);
            fSzF.Height += COUPONIMG_HEIGHT_ADJUSTMENT;

            g.DrawString("Name:", fLbl, brsh, lblX, y);
            g.DrawString($"{mbr.FirstName} {mbr.LastName}", f, Brushes.Black, x, y);

            y += fSzF.Height + COUPONIMG_MARGINOFFSET;

            g.DrawString("Email:", fLbl, brsh, lblX, y);
            g.DrawString(mbr.EmailAddress, f, brsh, x, y);

            y += fSzF.Height + COUPONIMG_MARGINOFFSET;

            g.DrawString("Address:", fLbl, brsh, lblX, y);
            g.DrawString(mbr.Address1, f, brsh, x, y);
            if (!string.IsNullOrEmpty(mbr.Address2))
            {
                y += fSzF.Height;
                g.DrawString(mbr.Address2, f, brsh, x, y);
            }
            y += fSzF.Height;
            g.DrawString($"{mbr.City}, {mbr.State} {mbr.PostalCode}", f, brsh, x, y);

            y += fSzF.Height + COUPONIMG_MARGINOFFSET;

            g.DrawString("Rec. By:", fLbl, brsh, lblX, y);
            g.DrawString(mbr.RecommendedBy, f, brsh, new RectangleF(x, y, 400, 300));

            return(baseImage);
        }
    }
}