namespace BEX.StrategyEngine.Domain;

public interface IExecutionStrategy : IStrategyIdentity
{
    ExecutionPlan Execute(Order order);
}
