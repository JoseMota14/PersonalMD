using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalMd.Application.CQRS.Results
{
    public enum ResultStatus
    {
        Success,
        NotFound,
        ValidationError,
        Failure
    }
}
