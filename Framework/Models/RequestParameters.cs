using RestSharp;

namespace Framework.Models
{
    public class RequestParameter
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public ParameterType ParameterType { get; set; }
    }
}