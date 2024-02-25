namespace CRM.Common.Helpers
{
    public class ConfigurationHelper
    {
        private static IConfiguration instance;
        public ConfigurationHelper(IConfiguration configuration) 
        {
            instance = configuration;
        }

        public IConfiguration GetInstance()
        {
            return instance;
        }
    }
}
