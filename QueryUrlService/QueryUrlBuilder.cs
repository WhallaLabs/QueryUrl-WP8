using QponyWP.Services.QueryUrlService;

namespace WhallaLabs.Services.QueryUrlService
{
    public static class QueryUrlBuilder
    {
        public static Query CreateQuery(object data)
        {
            var parameters = QueryUrlCore.ConvertToDictionary(data);
            return new Query(parameters);
        }
    }
}
