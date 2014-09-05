using System;
using System.Collections.Generic;
using System.Linq;
using QponyWP.Services.QueryUrlService;

namespace WhallaLabs.Services.QueryUrlService
{
    static class QueryUrlCore
    {
        public static Dictionary<string, object> ConvertToDictionary(object data)
        {
            var result = new Dictionary<string, object>();
            if (data == null)
                return result;

            // Get all properties on the object
            var allPriperties = data.GetType().GetProperties()
                .Where(x => x.CanRead)
                .Where(x => x.GetValue(data, null) != null)
                .Where(x => !Attribute.IsDefined(x, typeof(QueryIgnore)));

            var nonTaggedProperties = allPriperties.Where(x => !Attribute.IsDefined(x, typeof(QueryProperty)))
                .ToDictionary(x => x.Name, x => x.GetValue(data, null));

            var taggedProperties = allPriperties.Where(x => Attribute.IsDefined(x, typeof(QueryProperty)))
                .ToDictionary(x => ((IEnumerable<QueryProperty>)x.GetCustomAttributes(typeof(QueryProperty), true)).First().Name, x => x.GetValue(data, null));

            return result.Concat(taggedProperties).Concat(nonTaggedProperties).GroupBy(d => d.Key).ToDictionary(d => d.Key, d => d.First().Value);
        }
    }
}
