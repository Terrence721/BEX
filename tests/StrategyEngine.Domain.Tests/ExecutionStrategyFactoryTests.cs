using BEX.StrategyEngine.Domain;

namespace BEX.StrategyEngine.Domain.Tests;

public class ExecutionStrategyFactoryTests
{
    [Fact]
    public void ResolveExecutionStrategy_WithRegisteredStrategyId_ReturnsTheRegisteredStrategy()
    {
        var assignment = new StrategyAssignment("client-1", "Spot", "twap-1", "1.0", DateTimeOffset.UtcNow);
        var expectedStrategy = new TwapExecutionStrategy("twap-1", "1.0", new InMemoryLatestPriceProvider());
        var registry = new Dictionary<string, Func<IExecutionStrategy>> { ["twap-1"] = () => expectedStrategy };
        var factory = new ExecutionStrategyFactory(new FakeStrategyAssignmentRepository(assignment), registry);

        var result = factory.ResolveExecutionStrategy("client-1", "Spot");

        Assert.Same(expectedStrategy, result);
    }

    [Fact]
    public void ResolveExecutionStrategy_WithUnregisteredStrategyId_Throws()
    {
        var assignment = new StrategyAssignment("client-1", "Spot", "unknown-strategy", "1.0", DateTimeOffset.UtcNow);
        var registry = new Dictionary<string, Func<IExecutionStrategy>>();
        var factory = new ExecutionStrategyFactory(new FakeStrategyAssignmentRepository(assignment), registry);

        var ex = Assert.Throws<InvalidOperationException>(
            () => factory.ResolveExecutionStrategy("client-1", "Spot"));
        Assert.Contains("unknown-strategy", ex.Message);
    }
}
