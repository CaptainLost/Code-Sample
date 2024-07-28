using AIBehaviourTree;
using UnityEngine;

public class WanderStrategy : IBehaviourStrategy
{
    private readonly Transform m_transform;
    private readonly float m_moveSpeed;
    private readonly AgentSimulationBoundary m_simulationBoundary;

    private Vector2 m_moveDirection;

    public WanderStrategy(Transform transform, float moveSpeed, AgentSimulationBoundary simulationBoundary)
    {
        m_transform = transform;
        m_simulationBoundary = simulationBoundary;
        m_moveSpeed = moveSpeed;
    }

    // Infinite for now
    public BehaviourStatus Process()
    {
        CheckBounce();
        PerformMove();

        return BehaviourStatus.Running;
    }

    public void Reset()
    {
        
    }

    public void SetRandomMoveDirection()
    {
        m_moveDirection = Random.insideUnitCircle.normalized;
    }

    private void CheckBounce()
    {
        if (m_transform.position.x <= 0 || m_transform.position.x >= m_simulationBoundary.SimulationSize.x)
        {
            m_moveDirection.x *= -1f;
        }
        else if (m_transform.position.y <= 0 || m_transform.position.y >= m_simulationBoundary.SimulationSize.y)
        {
            m_moveDirection.y *= -1f;
        }
    }

    private void PerformMove()
    {
        m_transform.position += new Vector3(m_moveDirection.x * m_moveSpeed * Time.deltaTime, m_moveDirection.y * m_moveSpeed * Time.deltaTime);
    }
}
