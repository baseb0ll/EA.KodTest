using EA.KodTest.Application.Package;
using System.Threading.Tasks;

namespace EA.KodTest.Application.Interfaces
{
    public interface IPackageRepository : IRepository
    {
        Task<PackageModel> GetPackageByPackageNumberAsync(string packageNumber);
    }
}
