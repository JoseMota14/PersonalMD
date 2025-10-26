using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalMd.Application.CQRS.Results
{
    public class Result<T>
    {
        public ResultStatus Status { get; }
        public string? Error { get; }
        public T? Value { get; }

        private Result(ResultStatus status, T? value, string? error)
        {
            Status = status;
            Value = value;
            Error = error;
        }

        public static Result<T> Success(T value) => new(ResultStatus.Success, value, null);
        public static Result<T> Fail(string error, ResultStatus status = ResultStatus.Failure) => new(status, default, error);
    }
}
