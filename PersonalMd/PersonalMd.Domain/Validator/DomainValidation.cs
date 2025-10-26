﻿
namespace PersonalMd.Domain.Validator
{
    public class DomainValidation : Exception
    {
        public DomainValidation(string error) : base(error) { }

        public static void When(bool condition, string error)
        {
            if (condition)
            {
                throw new DomainValidation(error);
            }
        }
    }
}
