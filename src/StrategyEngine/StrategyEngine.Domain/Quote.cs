namespace BEX.StrategyEngine.Domain;

public sealed record Quote(string InstrumentId, decimal Bid, decimal Offer, DateTimeOffset Timestamp);
