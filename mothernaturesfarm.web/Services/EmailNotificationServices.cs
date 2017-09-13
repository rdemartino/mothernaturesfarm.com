using System;
using System.Net.Mail;
using mothernaturesfarm.web.Models;
using mothernaturesfarm.web.ViewModels;

namespace mothernaturesfarm.web.Services
{
    public class EmailNotificationServices
    {

        private static readonly string PARTYRESSBJFMTSTR = "Birthday Party Request";
        private static readonly string PARTYRESBODYFRMTSTR = "BIRTHDAY PARTY REQUEST: " +
                                                             $"{Environment.NewLine}Child's Name: {{0}}" +
                                                             $"{Environment.NewLine}Child's Age: {{1}}" +
                                                             $"{Environment.NewLine}Parent Name: {{2}}" +
                                                             $"{Environment.NewLine}Email: {{3}}" +
                                                             $"{Environment.NewLine}Home Phone: {{4}}" +
                                                             $"{Environment.NewLine}Cell Phone: {{5}}" +
                                                             $"{Environment.NewLine}City: {{6}}" +
                                                             $"{Environment.NewLine}State: {{7}}" +
                                                             $"{Environment.NewLine}Zip: {{8}}" +
                                                             $"{Environment.NewLine}Date: {{9}} {{10}}" +
                                                             $"{Environment.NewLine}Number of Children: {{11}}" +
                                                             $"{Environment.NewLine}Number Of Adults: {{12}}" +
                                                             $"{Environment.NewLine}Private Area Requested: {{13}}" +
                                                             $"{Environment.NewLine}Comments: {{14}}";

        private static readonly string CONTACTUSSBJFRMTSTR = "Website Message From: {0}";
        private static readonly string CONTACTUSBODYFRMTSTR = "{0}" +
                                                              $"{Environment.NewLine}{Environment.NewLine}{{1}}" +
                                                              $"{Environment.NewLine}{{2}}" +
                                                              $"{Environment.NewLine}{{3}}";

        private static readonly string TOURRESSBJFMTSTR = "School Tour Request";
        private static readonly string TOURRESBODYFRMTSTR = "SCHOOL TOUR REQUEST: " +
                                                  $"{Environment.NewLine}School Name: {{0}}" +
                                                  $"{Environment.NewLine}{{1}}" +
                                                  $"{Environment.NewLine}School Phone: {{2}}" +
                                                  $"{Environment.NewLine}School Fax: {{3}}" +
                                                  $"{Environment.NewLine}" +
                                                  $"{Environment.NewLine}TEACHER INFO:" +
                                                  $"{Environment.NewLine}Name: {{4}}" +
                                                  $"{Environment.NewLine}Aid: {{5}}" +
                                                  $"{Environment.NewLine}Email: {{6}}" +
                                                  $"{Environment.NewLine}Celsl Phone: {{7}}" +
                                                  $"{Environment.NewLine}" +
                                                  $"{Environment.NewLine}TOUR INFO" +
                                                  $"{Environment.NewLine}Tour DateTime 1: {{8}}" +
                                                  $"{Environment.NewLine}Tour DateTime 2: {{9}}" +
                                                  $"{Environment.NewLine}Tour DateTime 3: {{10}}" +
                                                  $"{Environment.NewLine}Number of Kids: {{11}}" +
                                                  $"{Environment.NewLine}Number of Adults: {{12}}" +
                                                  $"{Environment.NewLine}Sticker Option: {{13}}";

        private static readonly string COUPONSBJFRMTSTR = "Coupon Request";
        private static readonly string COUPONBODYFRMTSTR = "A Coupon was requested from: Email: {{0}}" +
                                                           $"{Environment.NewLine}Name: {{1}}" +
                                                           $"{Environment.NewLine}Address: {{2}}" +
                                                           $"{Environment.NewLine}Address2: {{3}}" +
                                                           $"{Environment.NewLine}City: {{4}}" +
                                                           $"{Environment.NewLine}State: {{5}}" +
                                                           $"{Environment.NewLine}PostalCode: {{6}}" +
                                                           $"{Environment.NewLine}Heard About From: {{7}} " +
                                                           $"{Environment.NewLine}Wants Newsletter: {{8}}";


        public SendNotificationResult SendNotification(VMContactUs vmContactUs)
        {
            string body = string.Format(CONTACTUSBODYFRMTSTR, vmContactUs.Comments, vmContactUs.Name, vmContactUs.Phone, vmContactUs.Email);
            string subject = string.Format(CONTACTUSSBJFRMTSTR, vmContactUs.Name);

            try
            {
                SendNotification(
                    MNFConfiguration.ContactUsSender,
                    MNFConfiguration.ContactUsRecipient,
                    subject,
                    body,
                    vmContactUs.Email);
                return (SendNotificationResult.Success);
            }
            catch (Exception ex)
            {
                return (SendNotificationResult.UnknownException);
            }
        }

        public SendNotificationResult SendNotification(VMPartyReservation vmPartyRes)
        {
            if (!ReservationIsValid(vmPartyRes))
                return(SendNotificationResult.MissingRequiredData);

            string body = string.Format(PARTYRESBODYFRMTSTR, vmPartyRes.ChildName.Trim(),
                vmPartyRes.ChildAge,
                vmPartyRes.ParentName.Trim(), vmPartyRes.ParentEmail.Trim(), vmPartyRes.HomePhone.Trim(),
                vmPartyRes.CellPhone.Trim(), vmPartyRes.City.Trim(), vmPartyRes.SelectedState,
                vmPartyRes.PostalCode.Trim(),
                vmPartyRes.PartyDate.Trim(), vmPartyRes.SelectedPartyTime, vmPartyRes.NumberOfKids,
                vmPartyRes.NumberOfAdults,
                vmPartyRes.AddPrivateArea, 
                string.IsNullOrWhiteSpace(vmPartyRes.Comments) ? string.Empty : vmPartyRes.Comments.Trim());

            try
            {
                SendNotification(
                    MNFConfiguration.PartyReservationSender,
                    MNFConfiguration.PartyReservationRecipient,
                    PARTYRESSBJFMTSTR,
                    body,
                    vmPartyRes.ParentEmail);
                return(SendNotificationResult.Success);
            }
            catch (Exception ex)
            {
                return(SendNotificationResult.UnknownException);
            }            
        }

        public SendNotificationResult SendNotification(VMTourReservation vmTourRes)
        {
            if (!ReservationIsValid(vmTourRes))
                return (SendNotificationResult.MissingRequiredData);

            string body = string.Format(TOURRESBODYFRMTSTR, vmTourRes.SchoolName.Trim(),
                $"{vmTourRes.SchoolAddress.Trim()}{Environment.NewLine}{vmTourRes.City.Trim()}, {vmTourRes.SelectedState} {vmTourRes.PostalCode}",
                vmTourRes.SchoolPhone.Trim(),
                vmTourRes.SchoolFax.Trim(),
                vmTourRes.TeacherName.Trim(),
                vmTourRes.TeacherAide.Trim(),
                vmTourRes.TeacherEmail.Trim(),
                vmTourRes.TeacherCellPhone.Trim(),
                $"{vmTourRes.TourDate1.Trim()} {vmTourRes.SelectedTourTime1}",
                $"{vmTourRes.TourDate2.Trim()} {vmTourRes.SelectedTourTime2}",
                $"{vmTourRes.TourDate3.Trim()} {vmTourRes.SelectedTourTime3}",
                vmTourRes.NumberOfKids,
                vmTourRes.NumberOfAdults,
                vmTourRes.IncludePackage);

            try
            {
                SendNotification(
                    MNFConfiguration.TourReservationSender,
                    MNFConfiguration.TourReservationRecipient,
                    TOURRESSBJFMTSTR,
                    body);
                return (SendNotificationResult.Success);
            }
            catch (Exception ex)
            {
                return (SendNotificationResult.UnknownException);
            }
        }

        public SendNotificationResult SendNotification(VMCoupon vmCoupon)
        {
            string body = string.Format(COUPONBODYFRMTSTR, 
                vmCoupon.Email.Trim(), 
                vmCoupon.StreetAddress.Trim(), 
                string.Empty,
                vmCoupon.City.Trim(), 
                vmCoupon.SelectedState, 
                vmCoupon.PostalCode.Trim(), 
                vmCoupon.RecommendedBy.Trim(), 
                vmCoupon.AddToNewsletter ? "Yes" : "No");

            try
            {
                SendNotification(
                    MNFConfiguration.CouponSender,
                    MNFConfiguration.CouponRecipient,
                    COUPONSBJFRMTSTR,
                    body);
                return (SendNotificationResult.Success);
            }
            catch (Exception ex)
            {
                return (SendNotificationResult.UnknownException);
            }

        }

        private bool ReservationIsValid(VMPartyReservation vmRes)
        {
            return !(string.IsNullOrWhiteSpace(vmRes.ChildName) || string.IsNullOrWhiteSpace(vmRes.ParentName) ||
                    string.IsNullOrWhiteSpace(vmRes.ParentEmail) || string.IsNullOrWhiteSpace(vmRes.HomePhone) ||
                    string.IsNullOrWhiteSpace(vmRes.CellPhone) || string.IsNullOrWhiteSpace(vmRes.City) ||
                    string.IsNullOrWhiteSpace(vmRes.PostalCode) || string.IsNullOrWhiteSpace(vmRes.PartyDate) ||
                    string.IsNullOrWhiteSpace(vmRes.SelectedPartyTime) || vmRes.NumberOfKids < MNFConfiguration.PartyReservationMinKids);
        }

        private bool ReservationIsValid(VMTourReservation vmRes)
        {
            return !(string.IsNullOrWhiteSpace(vmRes.SchoolName) || string.IsNullOrWhiteSpace(vmRes.SchoolAddress) ||
                     string.IsNullOrWhiteSpace(vmRes.City) || string.IsNullOrWhiteSpace(vmRes.PostalCode) || 
                     string.IsNullOrWhiteSpace(vmRes.SchoolPhone) || string.IsNullOrWhiteSpace(vmRes.TeacherName) ||
                     string.IsNullOrWhiteSpace(vmRes.TeacherEmail) || string.IsNullOrWhiteSpace(vmRes.TeacherCellPhone) || 
                     string.IsNullOrWhiteSpace(vmRes.TourDate1) || string.IsNullOrWhiteSpace(vmRes.TourDate2) ||
                     string.IsNullOrWhiteSpace(vmRes.TourDate3) || vmRes.NumberOfKids < MNFConfiguration.TourReservationMinKids);
        }

        private void SendNotification(string sender, string recip, string subject, string body, string replyTo = "")
        {
            MailAddress mailAddressTo = new MailAddress(recip);
            MailAddress mailAddressFrom = new MailAddress(sender, string.IsNullOrWhiteSpace(replyTo) ? sender : replyTo);
            MailMessage mailMsg = new MailMessage(mailAddressFrom, mailAddressTo);
            if (!string.IsNullOrWhiteSpace(replyTo))
                mailMsg.ReplyToList.Add(replyTo);
            mailMsg.Subject = subject;
            mailMsg.Body = body;            
            mailMsg.IsBodyHtml = false;
            
            SmtpClient smtp = new SmtpClient();            
            smtp.Send(mailMsg);
        }

    }
}