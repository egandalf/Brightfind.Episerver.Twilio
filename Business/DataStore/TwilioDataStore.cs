using EPiServer.Data;
using EPiServer.Data.Dynamic;

namespace Brightfind.Episerver.Twilio.Business.DataStore
{
    [EPiServerDataStore(AutomaticallyCreateStore = true, AutomaticallyRemapStore = true)]
    public class TwilioDataStore
    {
        public Identity Id { get; set; }
        public string FromNumber { get; set; }
        public string ApiSid { get; set; }
        public string ApiSecret { get; set; }
        public string AccountSid { get; set; }
    }
}
