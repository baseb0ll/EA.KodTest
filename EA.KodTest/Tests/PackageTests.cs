using EA.KodTest.Application.Package;
using Xunit;

namespace EA.KodTest.Tests
{
    public class PackageTests
    {
        [Theory]
        [InlineData("1234567890123456789")]
        [InlineData("12345678901234")]
        [InlineData("12345678901256789")]
        [InlineData("")]
        public void PackagenumberLengthMustBe18DigitsLong(string packageNumber)
        {
            var query = new GetPackageMeasuresQuery(packageNumber);
            var validator = new GetPackageMeasuresQueryValidator();
            var validationres = validator.Validate(query);

            Assert.False(validationres.IsValid);
        }

        [Theory]
        [InlineData("123456789012ert6789")]
        [InlineData("123456789@01234!")]
        [InlineData("123456789a1256789")]
        [InlineData("")]
        public void PackagenumberMustOnlyContainDigits(string packageNumber)
        {
            var query = new GetPackageMeasuresQuery(packageNumber);
            var validator = new GetPackageMeasuresQueryValidator();
            var validationres = validator.Validate(query);

            Assert.False(validationres.IsValid);
        }

        [Theory]
        [InlineData(40.0, 100.0, 55.0, 20.0)]
        [InlineData(65.0, 50.0, 55.0, 20.0)]
        [InlineData(40.0, 10.0, 0.0, 20.0)]
        [InlineData(40.0, 20.0, 55.0, 30.0)]
        public void PackageMustNotExceedLimits(double Height, double Length, double Width, double Weight)
        {
            var package = new PackageModel
            {
                Height = Height,
                Length = Length,
                Width = Width,
                Weight = Weight
            };

            var validator = new PackageValidator();
            var validationres = validator.Validate(package);

            Assert.False(validationres.IsValid);
        }
    }
}
