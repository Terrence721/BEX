using BEX.StrategyEngine.Domain;

namespace BEX.StrategyEngine.Domain.Tests;

public class TwapExecutionStrategyTests
{
    private static InMemoryLatestPriceProvider PriceProviderWith(string instrumentId, decimal bid, decimal offer)
    {
        var provider = new InMemoryLatestPriceProvider();
        provider.OnMarketDataUpdate(new Tick(instrumentId, bid, offer, DateTimeOffset.UtcNow));
        return provider;
    }

    [Fact]
    public void Execute_BuyOrder_FillsAtOffer()
    {
        var strategy = new TwapExecutionStrategy("twap-1", "1.0", PriceProviderWith("EURUSD", 1.0800m, 1.0802m));
        var order = new Order("ord-1", "client-1", "EURUSD", OrderSide.Buy, 1_000_000m);

        var plan = strategy.Execute(order);

        Assert.Equal("ord-1", plan.OrderId);
        Assert.Equal(ExecutionStatus.Filled, plan.Status);
        Assert.Equal(1_000_000m, plan.ExecutedQty);
        Assert.Equal(1.0802m, plan.ExecutedPrice);
        Assert.Null(plan.RejectionReason);
    }

    [Fact]
    public void Execute_SellOrder_FillsAtBid()
    {
        var strategy = new TwapExecutionStrategy("twap-1", "1.0", PriceProviderWith("EURUSD", 1.0800m, 1.0802m));
        var order = new Order("ord-2", "client-1", "EURUSD", OrderSide.Sell, 500_000m);

        var plan = strategy.Execute(order);

        Assert.Equal(1.0800m, plan.ExecutedPrice);
    }

    [Fact]
    public void Execute_WithNoTickForInstrument_Throws()
    {
        var strategy = new TwapExecutionStrategy("twap-1", "1.0", new InMemoryLatestPriceProvider());
        var order = new Order("ord-3", "client-1", "EURUSD", OrderSide.Buy, 1_000_000m);

        Assert.Throws<InvalidOperationException>(() => strategy.Execute(order));
    }

    [Fact]
    public void Identity_ExposesConstructorValues()
    {
        var strategy = new TwapExecutionStrategy("twap-1", "1.0", new InMemoryLatestPriceProvider());

        Assert.Equal("twap-1", strategy.StrategyId);
        Assert.Equal("1.0", strategy.Version);
    }
}
