namespace AIBehaviourTree
{
    public interface IBehaviourStrategy
    {
        BehaviourStatus Process();

        void Reset();
    }
}