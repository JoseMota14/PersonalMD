using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalMd.Application.DTOs
{
    public class ConditionResultDto
    {
        public string Name { get; set; } = string.Empty;
        public double Likelihood { get; set; }
    }
}
