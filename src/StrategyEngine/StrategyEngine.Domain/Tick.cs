namespace BEX.StrategyEngine.Domain;

public sealed record Tick(string InstrumentId, decimal Bid, decimal Offer, DateTimeOffset Timestamp);
