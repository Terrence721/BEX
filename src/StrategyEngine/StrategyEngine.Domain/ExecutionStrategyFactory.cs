namespace BEX.StrategyEngine.Domain;

public sealed class ExecutionStrategyFactory : IExecutionStrategyFactory
{
    private readonly IStrategyAssignmentRepository _assignments;
    private readonly IReadOnlyDictionary<string, Func<IExecutionStrategy>> _registry;

    public ExecutionStrategyFactory(IStrategyAssignmentRepository assignments, IReadOnlyDictionary<string, Func<IExecutionStrategy>> registry)
    {
        _assignments = assignments;
        _registry = registry;
    }

    public IExecutionStrategy ResolveExecutionStrategy(string clientId, string instrumentClass)
    {
        var assignment = _assignments.GetAssignment(clientId, instrumentClass);
        if (!_registry.TryGetValue(assignment.StrategyId, out var factory))
            throw new InvalidOperationException($"No execution strategy registered for StrategyId '{assignment.StrategyId}'.");

        return factory();
    }
}
