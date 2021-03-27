using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, string message) : base(data, true, message)
        {
            //data ve mesaj verirse çalşır
        }
        public SuccessDataResult(T data) : base(data, true)
        {
            //sadece data verirse çalşır
        }
        public SuccessDataResult(string message) : base(default, true, message)
        {
            //sadece mesaj verirse çalşır
            //default ifadesi (örneğin; int verilirse int default değeri 0'dır)
        }
        public SuccessDataResult() : base(default, true)
        {
            //hiçbir şey vermezse çalşır
        }
    }
}
