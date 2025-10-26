using FluentAssertions;
using PersonalMd.Domain.Entities;
using PersonalMd.Domain.Validator;

namespace MdTester
{
    public class UserTests
    {
        [Fact]
        public void Constructor_ShouldThrow_WhenInvalidParameters()
        {
            Action act = () => new User("", "test@mail.com", 25, "male");
            act.Should().Throw<DomainValidation>().WithMessage("Invalid name");
        }

        [Fact]
        public void Constructor_ShouldCreateUser_WhenValidData()
        {
            var user = new User("John Doe", "john@mail.com", 30, "male");

            user.Id.Should().NotBeEmpty();
            user.Name.Should().Be("John Doe");
            user.Email.Should().Be("john@mail.com");
            user.Age.Should().Be(30);
            user.Gender.Should().Be("male");
            user.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
        }
    }
}
