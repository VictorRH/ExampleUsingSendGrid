using ExampleSenGrid.SendGrindLibrary.Interfaz;
using ExampleSenGrid.SendGrindLibrary.Model;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace ExampleSenGrid.SendGrindLibrary.Repository
{
    public class SendGridSendEmail : ISendGridSend
    {
        public async Task<(bool result, string errorMessage)> SendEmail(SendGridModel data)
        {

            try
            {
                var sendGridClient = new SendGridClient(data.SendGridAPIKey);
                var from = new EmailAddress(data.EmailFrom, data.NameFrom);
                var titleEmail = data.Title;
                var sender = new EmailAddress("viktor.raymundo@gmail.com", "Example Send Email");
                var contentMessage = data.PlainTextContent;

                var objectMessage = MailHelper.CreateSingleEmail(sender, from, titleEmail, contentMessage, contentMessage);

                await sendGridClient.SendEmailAsync(objectMessage);
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }

        }
    }
}
