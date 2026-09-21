namespace BEX.StrategyEngine.Domain;

public sealed class InMemoryLatestPriceProvider : ILatestPriceProvider, IMarketDataReactive
{
    private readonly Dictionary<string, Tick> _latestTicks = new();

    public void OnMarketDataUpdate(Tick tick) => _latestTicks[tick.InstrumentId] = tick;

    public Tick GetLatestTick(string instrumentId)
    {
        if (!_latestTicks.TryGetValue(instrumentId, out var tick))
            throw new InvalidOperationException($"No market data received yet for instrument '{instrumentId}'.");

        return tick;
    }
}
