using UnityEngine;
using Zenject;

public class AgentCollision : MonoBehaviour
{
    [SerializeField]
    private float m_receivedDamage;

    private Agent m_agent;

    [Inject]
    public void Construct(Agent agent)
    {
        m_agent = agent;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IAgent otherAgent = collision.GetComponent<IAgent>();

        if (otherAgent == null)
            return;

        m_agent.Damagable.ReceiveDamage(m_receivedDamage);
    }
}
