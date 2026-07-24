using Dapper;
using PortfolioApi.EntityValueObject;
using PortfolioApi.Utilities;

namespace PortfolioApi.Test.Utilities;

public class QueryPaginationBuilderTest
{
    [Fact]
    public void ApplySize_registers_the_clamped_size()
    {
        // arrange
        var parameters = new DynamicParameters();
        var pagination = new Pagination
        {
            Size = 50
        };
        var builder = new QueryPaginationBuilder(pagination, parameters);

        // act
        builder.ApplySize();

        // assert
        Assert.Equal(10, parameters.Get<int>("@Size"));
    }

    [Theory]
    [InlineData(0, 5, 0)]
    [InlineData(1, 5, 0)]
    [InlineData(3, 5, 10)]
    [InlineData(4, 10, 30)]
    public void ApplyOffset_is_page_minus_one_times_size(int page, int size, int expected)
    {
        // arrange
        var parameters = new DynamicParameters();
        var pagination = new Pagination
        {
            Page = page,
            Size = size
        };
        var builder = new QueryPaginationBuilder(pagination, parameters);

        // act
        builder.ApplyOffset();

        // assert
        Assert.Equal(expected, parameters.Get<int>("@Offset"));
    }

    [Fact]
    public void ApplySearch_passes_the_search_term_through()
    {
        // arrange
        var parameters = new DynamicParameters();
        var pagination = new Pagination
        {
            Search = "sample"
        };
        var builder = new QueryPaginationBuilder(pagination, parameters);

        // act
        builder.ApplySearch();

        // assert
        Assert.Equal("sample", parameters.Get<string>("@Search"));
    }

    [Fact]
    public void ApplySearch_passes_null_through()
    {
        // arrange
        var parameters = new DynamicParameters();
        var pagination = new Pagination
        {
            Search = null
        };
        var builder = new QueryPaginationBuilder(pagination, parameters);

        // act
        builder.ApplySearch();

        // assert
        Assert.Null(parameters.Get<string?>("@Search"));
    }

    [Fact]
    public void Build_substitutes_sort_and_direction()
    {
        // arrange
        var parameters = new DynamicParameters();
        var pagination = new Pagination
        {
            SortBy = "Email",
            SortDirection = "desc"
        };
        var builder = new QueryPaginationBuilder(pagination, parameters)
            .InsertSortBy("Id", "Email")
            .InsertSortDi();

        // act
        var query = builder.Build("order by $Sort $Direction");

        // assert
        Assert.Equal("order by Email desc", query);
    }

    [Fact]
    public void InsertFilter_renders_the_predicate_and_registers_the_parameter()
    {
        // arrange
        var parameters = new DynamicParameters();
        var pagination = new Pagination
        {
            Filters = [
                new Filter
                {
                    Name = "Email",
                    Value = "sample@google.com"
                }]
        };
        var builder = new QueryPaginationBuilder(pagination, parameters)
            .InsertFilter("Email");

        // act
        var query = builder.Build("where ($Filter)");

        // assert
        Assert.Equal("where ([Email] = @Email)", query);
        Assert.Equal("sample@google.com", parameters.Get<string>("@Email"));
    }

    [Fact]
    public void InsertFilter_with_no_allowed_matches_leaves_filter_as_true()
    {
        // arrange
        var parameters = new DynamicParameters();
        var pagination = new Pagination
        {
            Filters = [
                new Filter
                {
                    Name = "Secret", 
                    Value = "qwerty"
                }]
        };
        var builder = new QueryPaginationBuilder(pagination, parameters)
            .InsertFilter("Email");

        // act
        var query = builder.Build("where ($Filter)");

        // assert
        Assert.Equal("where (true)", query);
    }
}