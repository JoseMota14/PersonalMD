using FluentAssertions;
using PersonalMd.Domain.Entities;
using PersonalMd.Domain.Validator;

namespace MdTester
{
    public class ConditionResultTests
    {
        [Fact]
        public void Constructor_ShouldThrow_WhenNameIsEmpty()
        {
            Action act = () => new ConditionResult("", 50);
            act.Should().Throw<DomainValidation>().WithMessage("Condition must have a name");
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(120)]
        public void Constructor_ShouldThrow_WhenLikelihoodOutOfRange(double likelihood)
        {
            Action act = () => new ConditionResult("Flu", likelihood);
            act.Should().Throw<DomainValidation>().WithMessage("Likelihood must be between 0 and 100");
        }

        [Fact]
        public void Constructor_ShouldCreate_WhenValidData()
        {
            var result = new ConditionResult("Flu", 50);
            result.Name.Should().Be("Flu");
            result.Likelihood.Should().Be(50);
        }
    }
}
