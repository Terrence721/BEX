namespace BEX.StrategyEngine.Domain;

public sealed record StrategyAssignment(string ClientId, string InstrumentClass, string StrategyId, string Version, DateTimeOffset EffectiveFrom);
