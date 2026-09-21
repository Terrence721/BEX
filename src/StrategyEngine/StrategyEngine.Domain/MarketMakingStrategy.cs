namespace BEX.StrategyEngine.Domain;

public sealed class MarketMakingStrategy : IQuotingStrategy, IMarketDataReactive
{
    private readonly decimal _spread;
    private readonly Dictionary<string, Tick> _latestTicks = new();

    public MarketMakingStrategy(string strategyId, string version, decimal spread)
    {
        StrategyId = strategyId;
        Version = version;
        _spread = spread;
    }

    public string StrategyId { get; }
    public string Version { get; }

    public void OnMarketDataUpdate(Tick tick) => _latestTicks[tick.InstrumentId] = tick;

    public Quote GetQuote(RequestContext context)
    {
        if (!_latestTicks.TryGetValue(context.InstrumentId, out var tick))
            throw new InvalidOperationException($"No market data received yet for instrument '{context.InstrumentId}'.");

        var mid = (tick.Bid + tick.Offer) / 2;
        var halfSpread = _spread / 2;
        return new Quote(context.InstrumentId, mid - halfSpread, mid + halfSpread, DateTimeOffset.UtcNow);
    }
}
