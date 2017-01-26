using Brightfind.Episerver.Twilio.Business.Twilio;

namespace Brightfind.Episerver.Twilio
{
    public class SMSManager
    {
        public bool SendMessage(string toNumber, string body, params string[] mediaUrl)
        {
            var twilioClient = new RestClient();
            var message = twilioClient.SendMessage("", toNumber, body, mediaUrl ?? new string[] { });
            return message != null;
        }
    }
}