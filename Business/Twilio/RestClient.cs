using System;
using Brightfind.Episerver.Twilio.Business.DataStore;
using Twilio;
using Brightfind.Episerver.Twilio.Business.Helpers;

namespace Brightfind.Episerver.Twilio.Business.Twilio
{
    internal interface IRestClient
    {
        Message SendMessage(string from, string to, string body, params string[] mediaUrl);
    }

    internal class RestClient : IRestClient
    {
        private readonly TwilioRestClient _client;
        private readonly TwilioDataStore _store;

        public RestClient()
        {
            var twilioManager = new TwilioDataStoreManager();
            _store = twilioManager.GetFirstTwilioData();
            if (_store == null) throw new Exception("Cannot send message when Twilio has not been configured. Please visit the admin screen first.");

            _client = new TwilioRestClient(
                _store.ApiSid.ToByteArray().UnProtect(), 
                _store.ApiSecret.ToByteArray().UnProtect(), 
                _store.AccountSid.ToByteArray().UnProtect());
        }

        public RestClient(TwilioRestClient client)
        {
            _client = client;
        }

        public Message SendMessage(string @from, string to, string body, params string[] mediaUrl)
        {
            return _client.SendMessage(_store?.FromNumber.ToByteArray().UnProtect() ?? from, to, body, mediaUrl ?? new string[] { });
        }
    }
}
