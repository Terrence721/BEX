using BEX.StrategyEngine.Domain;

namespace BEX.StrategyEngine.Domain.Tests;

public class QuotingStrategyFactoryTests
{
    [Fact]
    public void ResolveQuotingStrategy_WithRegisteredStrategyId_ReturnsTheRegisteredStrategy()
    {
        var assignment = new StrategyAssignment("client-1", "Spot", "mm-1", "1.0", DateTimeOffset.UtcNow);
        var expectedStrategy = new MarketMakingStrategy("mm-1", "1.0", 0.0004m, new InMemoryLatestPriceProvider());
        var registry = new Dictionary<string, Func<IQuotingStrategy>> { ["mm-1"] = () => expectedStrategy };
        var factory = new QuotingStrategyFactory(new FakeStrategyAssignmentRepository(assignment), registry);

        var result = factory.ResolveQuotingStrategy("client-1", "Spot");

        Assert.Same(expectedStrategy, result);
    }

    [Fact]
    public void ResolveQuotingStrategy_WithUnregisteredStrategyId_Throws()
    {
        var assignment = new StrategyAssignment("client-1", "Spot", "unknown-strategy", "1.0", DateTimeOffset.UtcNow);
        var registry = new Dictionary<string, Func<IQuotingStrategy>>();
        var factory = new QuotingStrategyFactory(new FakeStrategyAssignmentRepository(assignment), registry);

        var ex = Assert.Throws<InvalidOperationException>(
            () => factory.ResolveQuotingStrategy("client-1", "Spot"));
        Assert.Contains("unknown-strategy", ex.Message);
    }
}
