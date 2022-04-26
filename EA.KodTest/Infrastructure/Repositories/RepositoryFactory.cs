using EA.KodTest.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EA.KodTest.Infrastructure.Repositories
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public RepositoryFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T CreateRepository<T>() where T : IRepository
        {
            T repository = _serviceProvider.GetService<T>();

            return repository;
        }
    }
}
