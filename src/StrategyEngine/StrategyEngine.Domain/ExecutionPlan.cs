namespace BEX.StrategyEngine.Domain;

public sealed record ExecutionPlan(
    string OrderId,
    ExecutionStatus Status,
    decimal ExecutedQty,
    decimal? ExecutedPrice,
    string? RejectionReason);
