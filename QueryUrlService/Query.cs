using System;
using System.Collections.Generic;
using System.Linq;
using WhallaLabs.Services.QueryUrlService.Exceptions;

namespace WhallaLabs.Services.QueryUrlService
{
    public class Query
    {
        public Dictionary<string, object> Parameters { get; private set; }

        public Query()
        {
        }

        public Query(Dictionary<string, object> parameters)
        {
            Parameters = parameters;
        }

        public void AddOrUpdateParameter(string key, object value)
        {
            if(Parameters.Keys.Contains(key))
            {
                Parameters[key] = value;
                return;
            }
            Parameters.Add(key, value);
        }

        /// <exception cref="KeyExistsException">Thrown when you want to add parameter that already exists in the Dictionary</exception>
        public void AddParameter(string key, object value)
        {
            if (Parameters.Keys.Contains(key))
            {
                throw new KeyExistsException();
            }
            Parameters.Add(key, value);
        }

        public string ToQueryString()
        {
            var parameters = string.Join("&", Parameters
                            .Select(x => string.Concat(
                                Uri.EscapeDataString(x.Key), "=",
                                Uri.EscapeDataString(x.Value.ToString()))));
            
            if(parameters.Equals(string.Empty))
            {
                return string.Empty;
            }
            return "?" + parameters;
        }
    }
}
