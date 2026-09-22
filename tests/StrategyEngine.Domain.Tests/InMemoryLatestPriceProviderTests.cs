using BEX.StrategyEngine.Domain;

namespace BEX.StrategyEngine.Domain.Tests;

public class InMemoryLatestPriceProviderTests
{
    [Fact]
    public void GetLatestTick_AfterOnMarketDataUpdate_ReturnsTheStoredTick()
    {
        var provider = new InMemoryLatestPriceProvider();
        var tick = new Tick("EURUSD", 1.0800m, 1.0802m, DateTimeOffset.UtcNow);

        provider.OnMarketDataUpdate(tick);
        var result = provider.GetLatestTick("EURUSD");

        Assert.Equal(tick, result);
    }

    [Fact]
    public void GetLatestTick_WithNoDataForInstrument_Throws()
    {
        var provider = new InMemoryLatestPriceProvider();

        var ex = Assert.Throws<InvalidOperationException>(() => provider.GetLatestTick("EURUSD"));
        Assert.Contains("EURUSD", ex.Message);
    }
}
