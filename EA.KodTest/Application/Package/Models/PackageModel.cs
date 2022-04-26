using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EA.KodTest.Application.Package
{
    [Table("Packages")]
    public class PackageModel
    {
        [Key]
        public string PackageNumber { get; set; }
        public double Weight { get; set; }
        public double Length { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
    }

    public class PackageValidator : AbstractValidator<PackageModel>
    {
        public PackageValidator()
        {
            RuleFor(p => p.Weight).LessThanOrEqualTo(20).WithMessage("Package weight can not exceed 20kg.");
            RuleFor(p => p.Height).LessThanOrEqualTo(60).WithMessage("Package height can not exceed 60 cm.");
            RuleFor(p => p.Length).LessThanOrEqualTo(60).WithMessage("Package length can not exceed 60 cm.");
            RuleFor(p => p.Width).LessThanOrEqualTo(60).WithMessage("Package width can not exceed 60 cm.");
            RuleFor(p => p.Height).GreaterThan(0).WithMessage("Package height must be greater than 0 cm.");
            RuleFor(p => p.Length).GreaterThan(0).WithMessage("Package length must be greater than 0 cm.");
            RuleFor(p => p.Width).GreaterThan(0).WithMessage("Package width must be greater than 0 cm.");
            RuleFor(p => p.Weight).GreaterThan(0).WithMessage("Package weight must be greater than 0 kg.");
        }
    }
}
