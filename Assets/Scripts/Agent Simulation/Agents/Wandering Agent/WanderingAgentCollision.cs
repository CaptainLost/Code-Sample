using UnityEngine;
using Zenject;

public class WanderingAgentCollision : MonoBehaviour
{
    [SerializeField]
    private float m_receivedDamage;

    private WanderingAgent m_agent;

    [Inject]
    public void Construct(WanderingAgent agent)
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
