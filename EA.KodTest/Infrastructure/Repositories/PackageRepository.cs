using EA.KodTest.Application.Interfaces;
using EA.KodTest.Application.Package;
using EA.KodTest.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EA.KodTest.Infrastructure.Repositories
{
    public class PackageRepository : IPackageRepository
    {
        private readonly PackageContext _packageContext;
        public PackageRepository(PackageContext packageContext) 
        {
            _packageContext = packageContext;
            InitiateDatabase.Initiate(packageContext);
        }

        public Task<PackageModel> GetPackageByPackageNumberAsync(string packageNumber)
        {
            Console.WriteLine($"Querying for package {packageNumber}");
            var package = _packageContext.Packages
                .Where(p => p.PackageNumber == packageNumber)
                .FirstOrDefault();

            return Task.FromResult(package);
        }
    }
}
