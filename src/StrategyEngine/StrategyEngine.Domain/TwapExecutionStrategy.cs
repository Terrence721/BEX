namespace BEX.StrategyEngine.Domain;

public sealed class TwapExecutionStrategy : IExecutionStrategy
{
    private readonly ILatestPriceProvider _priceProvider;

    public TwapExecutionStrategy(string strategyId, string version, ILatestPriceProvider priceProvider)
    {
        StrategyId = strategyId;
        Version = version;
        _priceProvider = priceProvider;
    }

    public string StrategyId { get; }
    public string Version { get; }

    public ExecutionPlan Execute(Order order)
    {
        var tick = _priceProvider.GetLatestTick(order.InstrumentId);
        var price = order.Side == OrderSide.Buy ? tick.Offer : tick.Bid;
        return new ExecutionPlan(order.OrderId, ExecutionStatus.Filled, order.Qty, price, RejectionReason: null);
    }
}
