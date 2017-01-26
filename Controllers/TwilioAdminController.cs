using System.Web.Mvc;
using Brightfind.Episerver.Twilio.Business.DataStore;
using Brightfind.Episerver.Twilio.ViewModels;
using EPiServer.PlugIn;

namespace Brightfind.Episerver.Twilio.Controllers
{
    [GuiPlugIn(
        Area = PlugInArea.AdminConfigMenu,
        Url = "/modules/Brightfind.Episerver.Twilio/TwilioAdmin",
        DisplayName = "Twilio Configuration",
        SortIndex = 0
        )]
    public class TwilioAdminController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var twilioConfig = new TwilioConfigurationViewModel();
            return View("/modules/_protected/Brightfind.Episerver.Twilio/Views/TwilioAdmin/Index.cshtml", twilioConfig);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Index(TwilioConfigurationViewModel twilioConfig)
        {
            var twilioManager = new TwilioDataStoreManager();
            twilioManager.SaveTwilioData(twilioConfig._twilioData);
            return View("/modules/_protected/Brightfind.Episerver.Twilio/Views/TwilioAdmin/Index.cshtml", twilioConfig);
        }

        [HttpDelete, ValidateAntiForgeryToken]
        public RedirectResult Delete()
        {
            var twilioConfig = new TwilioConfigurationViewModel();
            var twilioManager = new TwilioDataStoreManager();
            twilioManager.DeleteTwilioData(twilioConfig._twilioData);
            return new RedirectResult("/modules/Brightfind.Episerver.Twilio/TwilioAdmin");
        }
    }
}
