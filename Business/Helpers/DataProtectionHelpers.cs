using EPiServer;
using System;
using System.Security.Cryptography;

namespace Brightfind.Episerver.Twilio.Business.Helpers
{
    public static class ProtectionHelpers
    {
        private static DataProtectionScope Scope => DataProtectionScope.CurrentUser;
        private static byte[] Entropy => typeof(Global).AssemblyQualifiedName.ToByteArray();

        public static byte[] Protect(this string textToProtect)
        {
            if (textToProtect == null) return null;

            byte[] textBytes = textToProtect.ToByteArray();
            byte[] results = ProtectedData.Protect(textBytes, Entropy, Scope);
            return results;
        }

        public static string UnProtect(this byte[] bytesToUnProtect)
        {
            try
            {
                byte[] unprotected = ProtectedData.Unprotect(bytesToUnProtect, Entropy, Scope);
                return unprotected.ToStringConversion();
            }
            catch (Exception ex)
            {
                // ignored
            }
            return string.Empty;
        }
    }
}
