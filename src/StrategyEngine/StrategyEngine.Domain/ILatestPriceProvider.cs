namespace BEX.StrategyEngine.Domain;

public interface ILatestPriceProvider
{
    Tick GetLatestTick(string instrumentId);
}
