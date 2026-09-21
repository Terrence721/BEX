namespace BEX.StrategyEngine.Domain;

public interface IStrategyAssignmentRepository
{
    StrategyAssignment GetAssignment(string clientId, string instrumentClass);
}
