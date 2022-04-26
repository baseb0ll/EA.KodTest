using EA.KodTest.Application.Interfaces;
using EA.KodTest.Utils;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace EA.KodTest.Application.Package
{
    public class GetPackageMeasuresQuery : IRequest<ActionResult<PackageModel>>
    {
        public string PackageNumber { get; set; }

        public GetPackageMeasuresQuery(string packageNumber)
        {
            PackageNumber = packageNumber;                 
        }
    }

    public class GetPackageMeasuresQueryHandler : IRequestHandler<GetPackageMeasuresQuery, ActionResult<PackageModel>>
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public GetPackageMeasuresQueryHandler(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public async Task<ActionResult<PackageModel>> Handle(GetPackageMeasuresQuery request, CancellationToken cancellationToken)
        {     
            var packageRepository = _repositoryFactory.CreateRepository<IPackageRepository>();
            var result = await packageRepository.GetPackageByPackageNumberAsync(request.PackageNumber);

            var packageValidator = new PackageValidator();
            var validationResults = packageValidator.Validate(result);

            if (!validationResults.IsValid)
                throw new ValidationException(validationResults.Errors);

            return result;
        }
    }

    public class GetPackageMeasuresQueryValidator : AbstractValidator<GetPackageMeasuresQuery>
    {
        public GetPackageMeasuresQueryValidator()
        {
            RuleFor(p => p.PackageNumber).NotEmpty().WithMessage("Package number cannot be empty.");
            RuleFor(p => p.PackageNumber).Length(18).WithMessage("Package number must be 18 digits.");
            RuleFor(p => p.PackageNumber).Must(Be.OnlyDigits).WithMessage("Package number must only contain digits.");
        }
    }
}
