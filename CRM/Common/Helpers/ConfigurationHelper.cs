namespace CRM.Common.Helpers
{
    public static class ConfigurationHelper
    {
        private static IConfiguration instance;
        static ConfigurationHelper() 
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            instance = builder.Build();
        }

        public static IConfiguration GetInstance()
        {
            return instance;
        }
    }
}
