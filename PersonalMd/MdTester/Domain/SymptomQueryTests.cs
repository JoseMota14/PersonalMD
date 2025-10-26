using System;
using System.Collections.Generic;
using FluentAssertions;
using PersonalMd.Domain.Entities;
using PersonalMd.Domain.Validator;

namespace MdTester.Domain
{
    public class SymptomQueryTests
    {
        [Fact]
        public void Constructor_ShouldThrow_WhenSymptomsListIsEmpty()
        {
            // Arrange
            var id = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var symptoms = new List<string>();

            // Act
            Action act = () => new SymptomQuery(id, userId, symptoms);

            // Assert
            act.Should().Throw<DomainValidation>()
               .WithMessage("Invalid symptoms, must contain at least 1");
        }

        [Fact]
        public void Constructor_ShouldNotThrow_WhenSymptomsExist()
        {
            // Arrange
            var id = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var symptoms = new List<string> { "fever", "fatigue" };

            // Act
            Action act = () => new SymptomQuery(id, userId, symptoms);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void CreatedAt_ShouldBeRecent()
        {
            // Arrange
            var query = new SymptomQuery();

            // Assert
            query.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
        }

        [Fact]
        public void Constructor_ShouldAssignPropertiesCorrectly()
        {
            // Arrange
            var id = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var symptoms = new List<string> { "headache" };

            // Act
            var query = new SymptomQuery(id, userId, symptoms);

            // Assert
            query.Id.Should().Be(id);
            query.UserId.Should().Be(userId);
            query.Symptoms.Should().ContainSingle("headache");
            query.ResultJson.Should().BeEmpty();
        }
    }
}
