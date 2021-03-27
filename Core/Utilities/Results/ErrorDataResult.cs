using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {
            //data ve mesaj verirse çalşır
        }
        public ErrorDataResult(T data) : base(data, false)
        {
            //sadece data verirse çalşır
        }
        public ErrorDataResult(string message) : base(default, false, message)
        {
            //sadece mesaj verirse çalşır
        }
        public ErrorDataResult() : base(default, false)
        {
            //hiçbir şey vermezse çalşır
        }
    }
}
