using Dapper;
using PortfolioApi.EntityValueObject;
using PortfolioApi.Extensions;

namespace PortfolioApi.Test.Extensions;

public class QueryExtensionTest
{
    [Fact]
    public void ToQuery_brackets_each_name_and_joins_with_AND()
    {
        // arrange
        List<Filter> filters =
        [
            new Filter
            {
                Name = "FirstName",
                Value = "Sample"
            },
            new Filter
            {
                Name = "Email",
                Value = "sample@google.com"
            }
        ];

        // act
        var query = filters.ToQuery();

        // assert
        Assert.Equal("[FirstName] = @FirstName AND [Email] = @Email", query);
    }

    [Fact]
    public void ToQuery_on_an_empty_list_yields_an_empty_string()
    {
        // arrange
        var filters = new List<Filter>();

        // act
        var query = filters.ToQuery();

        // assert
        Assert.Equal("", query);
    }

    [Fact]
    public void ToQueryWithDynamicParameters_returns_the_same_predicate_as_ToQuery()
    {
        // arrange
        List<Filter> filters =
        [
            new Filter
            {
                Name = "FirstName",
                Value = "Sample"
            },
            new Filter
            {
                Name = "Email",
                Value = "sample@google.com"
            }
        ];

        // act
        var query = filters.ToQueryWithDynamicParameters(new DynamicParameters());

        // assert
        Assert.Equal(filters.ToQuery(), query);
    }

    [Fact]
    public void ToQueryWithDynamicParameters_registers_one_parameter_per_filter()
    {
        // arrange
        List<Filter> filters =
        [
            new Filter
            {
                Name = "FirstName",
                Value = "Sample"
            },
            new Filter
            {
                Name = "Email",
                Value = "sample@google.com"
            }
        ];
        var parameters = new DynamicParameters();

        // act
        filters.ToQueryWithDynamicParameters(parameters);

        // assert
        Assert.Equal("Sample", parameters.Get<string>("@FirstName"));
        Assert.Equal("sample@google.com", parameters.Get<string>("@Email"));
    }
}
