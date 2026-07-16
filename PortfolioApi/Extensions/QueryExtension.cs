using Dapper;
using PortfolioApi.EntityValueObject;

namespace PortfolioApi.Extensions;

public static class QueryExtension
{
    extension(List<Filter> filters)
    {
        public string ToQuery()
        {
            return string.Join(" AND ", filters.Select(f => $"[{f.Name}] = @{f.Name}"));
        }

        public string ToQueryWithDynamicParameters(DynamicParameters parameters)
        {
            foreach (var filter in filters)
            {
                parameters.Add($"@{filter.Name}", filter.Value);
            }

            return string.Join(" AND ", filters.Select(f => $"[{f.Name}] = @{f.Name}"));
        }
    }
}