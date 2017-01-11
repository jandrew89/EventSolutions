namespace Event.Core.States.Interfaces
{
    public interface IStatusState
    {
        IStatusState UpdateAssignment(IAssigner assigner);
        IStatusState UpdateUserAssignment(IAssigner assigner);
    }
}
