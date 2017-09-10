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

        private static readonly string CONTACTUSSBJFRMTSTR = "Webiste Message From: {0}";
        private static readonly string CONTACTUSBODYFRMTSTR = "{0}" +
                                                              $"{Environment.NewLine}{Environment.NewLine}{{1}}" +
                                                              $"{Environment.NewLine}{{2}}" +
                                                              $"{Environment.NewLine}{{3}}";

        

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

        private bool ReservationIsValid(VMPartyReservation vmRes)
        {
            return !(string.IsNullOrWhiteSpace(vmRes.ChildName) || string.IsNullOrWhiteSpace(vmRes.ParentName) ||
                    string.IsNullOrWhiteSpace(vmRes.ParentEmail) || string.IsNullOrWhiteSpace(vmRes.HomePhone) ||
                    string.IsNullOrWhiteSpace(vmRes.CellPhone) || string.IsNullOrWhiteSpace(vmRes.City) ||
                    string.IsNullOrWhiteSpace(vmRes.PostalCode) || string.IsNullOrWhiteSpace(vmRes.PartyDate) ||
                    string.IsNullOrWhiteSpace(vmRes.SelectedPartyTime) || vmRes.NumberOfKids < 10);
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