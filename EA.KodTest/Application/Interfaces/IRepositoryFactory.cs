namespace EA.KodTest.Application.Interfaces
{
    public interface IRepositoryFactory
    {
        T CreateRepository<T>() where T : IRepository;
    }
}
