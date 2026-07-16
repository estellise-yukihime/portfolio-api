namespace PortfolioApi.EntityValueObject;

public class Paginated<T>
{
    public Paginated(List<T> items, int page, int size, int total)
    {
        Items = items;
        Page = page;
        Size = size;
        Total = total;
    }

    public List<T> Items { get; init; }
    public int Page { get; init; }
    public int Size { get; init; }
    public int Total { get; init; }
}