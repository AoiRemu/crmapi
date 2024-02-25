namespace CRM.Common.Helpers
{
    using System.Security.Cryptography;
    using System.Text;

    public static class EncryptionHelper
    {
        public static string ToMD5String(this string str)
        {
            MD5 md5 = MD5.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            byte[] hashBytes = md5.ComputeHash(bytes);
            string result = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            return result;
        }
    }
}
