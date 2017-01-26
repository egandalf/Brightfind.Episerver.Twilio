using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Brightfind.Episerver.Twilio.Business.DataStore;
using Brightfind.Episerver.Twilio.Business.Helpers;

namespace Brightfind.Episerver.Twilio.ViewModels
{
    public class TwilioConfigurationViewModel
    {
        internal TwilioDataStore _twilioData;

        public TwilioConfigurationViewModel()
        {
            var twilioManager = new TwilioDataStoreManager();
            _twilioData = twilioManager.GetFirstTwilioData() ?? new TwilioDataStore();
        }

        [Required]
        [Description("The Twilio Phone Number which will send SMS messages.")]
        [Display(Name = "From SMS Number", Prompt = "+12125551212")]
        public string FromPhone
        {
            get
            {
                return _twilioData?.FromNumber.ToByteArray().UnProtect() ?? string.Empty;
            }
            set
            {
                _twilioData.FromNumber = value.Protect().ToStringConversion();
            }
        }

        [Required]
        [Description("The API SID configured within Twilio for this application.")]
        [Display(Name = "Application API SID")]
        public string ApiSid
        {
            get
            {
                return _twilioData?.ApiSid.ToByteArray().UnProtect() ?? string.Empty;
            }
            set
            {
                _twilioData.ApiSid = value.Protect().ToStringConversion();
            }
        }

        [Required]
        [Description("The API Secret configured within Twilio for this application.")]
        [Display(Name = "Application API Secret")]
        public string ApiSecret
        {
            get
            {
                return _twilioData?.ApiSecret.ToByteArray().UnProtect() ?? string.Empty;
            }
            set
            {
                _twilioData.ApiSecret = value.Protect().ToStringConversion();
            }
        }

        [Required]
        [Description("The Account SID configured within Twilio for this application.")]
        [Display(Name = "Account SID")]
        public string AccountSid
        {
            get
            {
                return _twilioData?.AccountSid.ToByteArray().UnProtect() ?? string.Empty;
            }
            set
            {
                _twilioData.AccountSid = value.Protect().ToStringConversion();
            }
        }
    }
}
