using UnityEngine;
using Zenject;

public class AgentSimulationBoundary
{
    private AgentSimulationSettings m_simulationSettings;
    private Vector2 m_simulationSize;

    [Inject]
    public void Construct(AgentSimulationSettings simulationSettings)
    {
        m_simulationSettings = simulationSettings;
        m_simulationSize = simulationSettings.SimulationSize;
    }

    public Vector3 GetRandomSimulationPos()
    {
        float randomX = Random.Range(0f, m_simulationSize.x);
        float randomY = Random.Range(0f, m_simulationSize.y);

        return new Vector3(randomX, randomY, 0f);
    }
}
