using EA.KodTest.Application.Behavior;
using EA.KodTest.Application.Interfaces;
using EA.KodTest.Application.Package;
using EA.KodTest.Infrastructure;
using EA.KodTest.Infrastructure.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

[assembly: FunctionsStartup(typeof(EA.KodTest.Program))]
namespace EA.KodTest
{
    public class Program : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddMediatR(typeof(GetPackageMeasuresQueryHandler));
            builder.Services.AddScoped<IRepositoryFactory>(sp => new RepositoryFactory(sp));
            builder.Services.AddScoped<IPackageRepository, PackageRepository>();
            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            builder.Services.AddTransient<IValidator<GetPackageMeasuresQuery>, GetPackageMeasuresQueryValidator>();
            builder.Services.AddTransient<IValidator<PackageModel>, PackageValidator>();
            builder.Services.AddDbContext<PackageContext>(options => 
                options.UseSqlite($"Data Source={Environment.SpecialFolder.LocalApplicationData}EAKodtest.db"));
        }
    }
}
