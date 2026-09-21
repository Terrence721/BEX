namespace BEX.StrategyEngine.Domain;

public sealed class QuotingStrategyFactory : IQuotingStrategyFactory
{
    private readonly IStrategyAssignmentRepository _assignments;
    private readonly IReadOnlyDictionary<string, Func<IQuotingStrategy>> _registry;

    public QuotingStrategyFactory(IStrategyAssignmentRepository assignments, IReadOnlyDictionary<string, Func<IQuotingStrategy>> registry)
    {
        _assignments = assignments;
        _registry = registry;
    }

    public IQuotingStrategy ResolveQuotingStrategy(string clientId, string instrumentClass)
    {
        var assignment = _assignments.GetAssignment(clientId, instrumentClass);
        if (!_registry.TryGetValue(assignment.StrategyId, out var factory))
            throw new InvalidOperationException($"No quoting strategy registered for StrategyId '{assignment.StrategyId}'.");

        return factory();
    }
}
