using BEX.StrategyEngine.Domain;

namespace BEX.StrategyEngine.Domain.Tests;

public class MarketMakingStrategyTests
{
    [Fact]
    public void GetQuote_WithKnownTick_ReturnsMidPriceSplitBySpread()
    {
        var priceProvider = new InMemoryLatestPriceProvider();
        priceProvider.OnMarketDataUpdate(new Tick("EURUSD", 1.0800m, 1.0802m, DateTimeOffset.UtcNow));
        var strategy = new MarketMakingStrategy("mm-1", "1.0", spread: 0.0004m, priceProvider);

        var quote = strategy.GetQuote(new RequestContext("client-1", "EURUSD", 1_000_000m));

        Assert.Equal("EURUSD", quote.InstrumentId);
        Assert.Equal(1.0799m, quote.Bid);
        Assert.Equal(1.0803m, quote.Offer);
    }

    [Fact]
    public void GetQuote_WithNoTickForInstrument_Throws()
    {
        var strategy = new MarketMakingStrategy("mm-1", "1.0", spread: 0.0004m, new InMemoryLatestPriceProvider());

        Assert.Throws<InvalidOperationException>(
            () => strategy.GetQuote(new RequestContext("client-1", "EURUSD", 1_000_000m)));
    }

    [Fact]
    public void Identity_ExposesConstructorValues()
    {
        var strategy = new MarketMakingStrategy("mm-1", "1.0", spread: 0.0004m, new InMemoryLatestPriceProvider());

        Assert.Equal("mm-1", strategy.StrategyId);
        Assert.Equal("1.0", strategy.Version);
    }
}
