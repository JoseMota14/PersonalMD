using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalMd.Application.DTOs
{
    public class SymptomQueryDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public List<string> Symptoms { get; set; } = new();
        public DateTime CreatedAt { get; set; }
        public List<ConditionResultDto> Results { get; set; } = new();
    }
}
