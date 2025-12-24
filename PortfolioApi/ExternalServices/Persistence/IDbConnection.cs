namespace PortfolioApi.ExternalServices.Persistence;

public interface IDbConnection<out T>
{
    T OpenConnection();   
}