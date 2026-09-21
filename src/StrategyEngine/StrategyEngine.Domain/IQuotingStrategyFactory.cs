namespace BEX.StrategyEngine.Domain;

public interface IQuotingStrategyFactory
{
    IQuotingStrategy ResolveQuotingStrategy(string clientId, string instrumentClass);
}
