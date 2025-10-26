using PersonalMd.Domain.Validator;

namespace PersonalMd.Domain.Entities
{
    public class SymptomQuery
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public List<string> Symptoms { get; set; } = new();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string ResultJson { get; set; } = string.Empty;

        public SymptomQuery() { }

        public SymptomQuery(Guid id, Guid userId, List<string> symptoms) 
        {
            ValidateSymtoms(symptoms);

            Id = id;
            UserId = userId;
        }

        private void ValidateSymtoms(List<string> symptoms)
        {
            DomainValidation.When(symptoms.Count == 0, "Invalid symptoms, must contain at least 1");

            Symptoms = symptoms;
        }
    }
}
