using System.Collections.Generic;
using System.Linq;
using EPiServer.Data;
using EPiServer.Data.Dynamic;

namespace Brightfind.Episerver.Twilio.Business.DataStore
{
    internal class TwilioDataStoreManager
    {
        internal TwilioDataStore GetTwilioDataById(Identity id)
        {
            using (var twilioStore = typeof(TwilioDataStore).GetOrCreateStore())
            {
                return twilioStore.Load<TwilioDataStore>(id);
            }
        }

        internal IEnumerable<TwilioDataStore> GetAllTwilioData()
        {
            using (var twilioStore = typeof(TwilioDataStore).GetOrCreateStore())
            {
                return twilioStore.LoadAll<TwilioDataStore>();
            }
        }

        internal TwilioDataStore GetFirstTwilioData()
        {
            return GetAllTwilioData().FirstOrDefault();
        }

        internal Identity SaveTwilioData(TwilioDataStore twilioData)
        {
            if (string.IsNullOrEmpty(twilioData.FromNumber)
                || string.IsNullOrEmpty(twilioData.AccountSid)
                || string.IsNullOrEmpty(twilioData.ApiSecret)
                || string.IsNullOrEmpty(twilioData.ApiSid))
                return null;

            using (var twilioStore = typeof(TwilioDataStore).GetOrCreateStore())
            {
                return twilioData.Id == null ? twilioStore.Save(twilioData) : twilioStore.Save(twilioData, twilioData.Id);
            }
        }

        internal void DeleteTwilioData(TwilioDataStore twilioData)
        {
            using (var twilioStore = typeof(TwilioDataStore).GetOrCreateStore())
            {
                twilioStore.Delete(twilioData.Id);
            }
        }
    }
}
