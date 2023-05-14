namespace DemoRepositoryPattern.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int Save();
    }
}
