namespace BEX.StrategyEngine.Domain;

public interface IStrategyIdentity
{
    string StrategyId { get; }
    string Version { get; }
}
