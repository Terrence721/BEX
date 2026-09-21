namespace BEX.StrategyEngine.Domain;

public sealed record RequestContext(string ClientId, string InstrumentId, decimal RequestedSize);
