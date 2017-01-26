using System.Linq;
using System.Text;

namespace Brightfind.Episerver.Twilio.Business.Helpers
{
    public static class ByteHelpers
    {
        public static string ToStringConversion(this byte[] bytesToConvert, Encoding encoding = null)
        {
            if (!bytesToConvert?.Any() == true) return string.Empty;
            if (encoding == null) encoding = Encoding.Default;
            var result = encoding.GetString(bytesToConvert);
            return result;
        }
    }
}
