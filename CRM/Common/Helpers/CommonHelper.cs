namespace CRM.Common.Helpers
{
    public static class CommonHelper
    {
        public static string UnderscoreToPascalCase(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            var words = input.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
            var result = string.Join("", words.Select(w => char.ToUpper(w[0]) + w.Substring(1).ToLower()));

            return result;
        }

        public static DateTime? ToDateTime(this string dateStr)
        {
            try
            {
                var date = Convert.ToDateTime(dateStr);
                return date;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
