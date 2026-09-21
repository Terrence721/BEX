namespace BEX.StrategyEngine.Domain;

public interface IQuotingStrategy : IStrategyIdentity
{
    Quote GetQuote(RequestContext context);
}
