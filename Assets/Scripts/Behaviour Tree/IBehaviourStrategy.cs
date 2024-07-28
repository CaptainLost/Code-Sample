namespace BehaviourTree
{
    public interface IBehaviourStrategy
    {
        BehaviourStatus Process();

        void Reset();
    }
}