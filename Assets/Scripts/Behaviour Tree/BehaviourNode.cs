using System.Collections.Generic;

namespace AIBehaviourTree
{
    public class BehaviourNode
    {
        public readonly string Name;
        public readonly List<BehaviourNode> ChildrenList;

        protected int m_currentChild;

        public BehaviourNode(string name = "Node")
        {
            Name = name;

            ChildrenList = new List<BehaviourNode>();
        }

        public virtual void Reset()
        {
            m_currentChild = 0;

            foreach (BehaviourNode child in ChildrenList)
            {
                child.Reset();
            }
        }

        public virtual BehaviourStatus Process()
        {
            return ChildrenList[m_currentChild].Process();
        }

        public void AddChild(BehaviourNode node)
        {
            ChildrenList.Add(node);
        }
    }
}