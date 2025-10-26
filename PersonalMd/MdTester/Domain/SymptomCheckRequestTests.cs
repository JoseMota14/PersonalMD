using FluentAssertions;
using PersonalMd.Domain.Entities;
using PersonalMd.Domain.Validator;

namespace MdTester
{
    public class SymptomCheckRequestTests
    {
        [Fact]
        public void Constructor_ShouldThrow_WhenInvalidParameters()
        {
            Action act = () => new SymptomCheckRequest("", 0, new List<string>());
            act.Should().Throw<DomainValidation>().WithMessage("Invalid sex");
        }

        [Fact]
        public void Constructor_ShouldThrow_WhenNoSymptoms()
        {
            Action act = () => new SymptomCheckRequest("male", 30, new List<string>());
            act.Should().Throw<DomainValidation>().WithMessage("Invalid symptoms, must contain at least 1");
        }

        [Fact]
        public void Constructor_ShouldCreate_WhenValidData()
        {
            var req = new SymptomCheckRequest("female", 25, new List<string> { "fever" });

            req.Sex.Should().Be("female");
            req.Age.Should().Be(25);
            req.Symptoms.Should().ContainSingle("fever");
        }
    }
}
