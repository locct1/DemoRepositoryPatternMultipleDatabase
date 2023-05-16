namespace DemoRepositoryPattern.LibraryDbProvider
{
    public static class GetStringAppsetting
    {
        public static string DatabaseDefault()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var databaseDefault = config.GetSection("DatabaseDefault").Value;
            return databaseDefault;
        }
        public static IConfigurationRoot ConnectString()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            return config;
        }
    }
}
