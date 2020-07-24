using System;
using System.Collections.Generic;
using System.Text;

namespace HlidacStatu.Api.V2.Dataset.Typed
{
    public class Result<TData>
        where TData : class
    {
        public long Total{ get; set; }
        public long Page { get; set; }
        public TData[] Results { get; set; }
    }
}
