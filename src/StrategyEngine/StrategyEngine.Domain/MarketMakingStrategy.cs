namespace BEX.StrategyEngine.Domain;

public sealed class MarketMakingStrategy : IQuotingStrategy
{
    private readonly decimal _spread;
    private readonly ILatestPriceProvider _priceProvider;

    public MarketMakingStrategy(string strategyId, string version, decimal spread, ILatestPriceProvider priceProvider)
    {
        StrategyId = strategyId;
        Version = version;
        _spread = spread;
        _priceProvider = priceProvider;
    }

    public string StrategyId { get; }
    public string Version { get; }

    public Quote GetQuote(RequestContext context)
    {
        var tick = _priceProvider.GetLatestTick(context.InstrumentId);
        var mid = (tick.Bid + tick.Offer) / 2;
        var halfSpread = _spread / 2;
        return new Quote(context.InstrumentId, mid - halfSpread, mid + halfSpread, DateTimeOffset.UtcNow);
    }
}
