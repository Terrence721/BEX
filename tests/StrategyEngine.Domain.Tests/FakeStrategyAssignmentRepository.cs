namespace BEX.StrategyEngine.Domain.Tests;

public sealed class FakeStrategyAssignmentRepository : IStrategyAssignmentRepository
{
    private readonly StrategyAssignment _assignment;

    public FakeStrategyAssignmentRepository(StrategyAssignment assignment) => _assignment = assignment;

    public StrategyAssignment GetAssignment(string clientId, string instrumentClass) => _assignment;
}
