using PersonalMd.Domain.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalMd.Domain.Entities
{
    public class ConditionResult
    {
        public string Name { get; private set; } = string.Empty;
        public double Likelihood { get; private set; }

        public ConditionResult(string name, double likelihood)
        {
            DomainValidation.When(string.IsNullOrWhiteSpace(name), "Condition must have a name");
            DomainValidation.When(likelihood < 0 || likelihood > 100, "Likelihood must be between 0 and 100");

            Name = name;
            Likelihood = likelihood;
        }
    }
}
