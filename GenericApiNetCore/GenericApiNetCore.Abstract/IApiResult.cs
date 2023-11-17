using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IApiResult<out T>
{
    T? Result { get; }
    bool IsSuccess { get; }
    string? Message { get; }
}
