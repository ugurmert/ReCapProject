using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //Temel void operasyonlar için kullanacağız
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
