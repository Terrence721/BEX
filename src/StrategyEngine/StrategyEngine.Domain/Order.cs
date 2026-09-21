namespace BEX.StrategyEngine.Domain;

public sealed record Order(string OrderId, string ClientId, string InstrumentId, OrderSide Side, decimal Qty);
