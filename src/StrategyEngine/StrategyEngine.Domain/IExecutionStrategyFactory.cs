namespace BEX.StrategyEngine.Domain;

public interface IExecutionStrategyFactory
{
    IExecutionStrategy ResolveExecutionStrategy(string clientId, string instrumentClass);
}
