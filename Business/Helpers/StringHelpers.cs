using System.Text;

namespace Brightfind.Episerver.Twilio.Business.Helpers
{
    public static class StringHelpers
    {
        public static byte[] ToByteArray(this string textToConvert)
        {
            var result = textToConvert != null ? Encoding.Default.GetBytes(textToConvert) : null;
            return result;
        }
    }
}