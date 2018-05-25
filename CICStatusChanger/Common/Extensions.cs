using System.Security;

namespace CICStatusChanger.Common
{
    public static class Extensions
    {
        /// <summary>
        /// Converts a string into a "SecureString"
        /// </summary>
        /// <param name="str">Input String</param>
        /// <returns>Secure String of Input String</returns>
        public static SecureString ToSecureString(this string str)
        {
            var secureString = new SecureString();
            foreach (var c in str) secureString.AppendChar(c);
            return secureString;
        }
    }
}