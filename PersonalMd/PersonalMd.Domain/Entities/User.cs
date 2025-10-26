using PersonalMd.Domain.Validator;

namespace PersonalMd.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public int Age { get; private set; }
        public string Gender { get; private set; } = string.Empty;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        public User(string name, string email, int age, string gender)
        {
            DomainValidation.When(string.IsNullOrWhiteSpace(name), "Invalid name");
            DomainValidation.When(string.IsNullOrWhiteSpace(email), "Invalid email");
            DomainValidation.When(age <= 0, "Invalid age");
            DomainValidation.When(string.IsNullOrWhiteSpace(gender), "Invalid gender");

            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Age = age;
            Gender = gender;
        }
    }
}
