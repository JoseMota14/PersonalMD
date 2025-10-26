using PersonalMd.Domain.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalMd.Domain.Entities
{
    public class SymptomCheckRequest
    {
        public string Sex { get; private set; } = "male";
        public int Age { get; private set; }
        public List<string> Symptoms { get; private set; } = new();

        public SymptomCheckRequest(string sex, int age, List<string> symptoms)
        {
            DomainValidation.When(string.IsNullOrWhiteSpace(sex), "Invalid sex");
            DomainValidation.When(age <= 0, "Invalid age");
            DomainValidation.When(symptoms == null || symptoms.Count == 0, "Invalid symptoms, must contain at least 1");

            Sex = sex;
            Age = age;
            Symptoms = symptoms;
        }
    }
}
