namespace AIBehaviourTree
{
    public class BehaviourTree : BehaviourNode
    {
        public BehaviourTree(string name)
            : base(name)
        {

        }

        public override BehaviourStatus Process()
        {
            while (m_currentChild < ChildrenList.Count)
            {
                BehaviourStatus status = ChildrenList[m_currentChild].Process();

                if (status != BehaviourStatus.Success)
                {
                    return status;
                }

                m_currentChild++;
            }

            return BehaviourStatus.Success;
        }
    }
}