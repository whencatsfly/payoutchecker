using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinLinesTest.Results
{
    public class ResultWrapper<T>
    {
        [JsonProperty(PropertyName = "value")]
        public T Value { get; set; }
    }
}
