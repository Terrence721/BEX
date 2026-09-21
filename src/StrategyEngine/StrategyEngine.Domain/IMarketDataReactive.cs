namespace BEX.StrategyEngine.Domain;

public interface IMarketDataReactive
{
    void OnMarketDataUpdate(Tick tick);
}
