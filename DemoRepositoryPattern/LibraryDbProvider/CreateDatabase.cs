using Microsoft.EntityFrameworkCore.Storage;

namespace DemoRepositoryPattern.LibraryDbProvider
{
    public class CreateDatabase
    {
        public IDatabaseProvider GetDBProvider()
        {
            Type T = Type.GetType($"DemoRepositoryPattern.LibraryDbProvider.DbProvider.{GetStringAppsetting.DatabaseDefault()}");
            if (T is null)
            {
                throw new NotImplementedException("Default database not a valid database type.");
            }
            var DBProvider = Activator.CreateInstance(T) as IDatabaseProvider;
            return DBProvider;
        }
    }
}
