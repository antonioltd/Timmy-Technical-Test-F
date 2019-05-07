using RestSharp;
using System.Collections.Generic;

namespace Framework.Models
{
    public class RequestDetails
    {
        public string ResourceEndpoint { get; set; }
        public Method  MethodType { get; set; }
        public IList<RequestParameter> RequestParameterList { get; set; }
        
    }
}
