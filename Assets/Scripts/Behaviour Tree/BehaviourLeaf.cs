namespace AIBehaviourTree
{
    public class BehaviourLeaf : BehaviourNode
    {
        private readonly IBehaviourStrategy m_strategy;

        public BehaviourLeaf(string name, IBehaviourStrategy strategy)
            : base(name)
        {
            m_strategy = strategy;
        }

        public override BehaviourStatus Process()
        {
            return m_strategy.Process();
        }

        public override void Reset()
        {
            m_strategy.Reset();
        }
    }
}