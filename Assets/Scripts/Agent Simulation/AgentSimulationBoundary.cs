using UnityEngine;
using Zenject;

public class AgentSimulationBoundary
{
    private AgentSimulationSettings m_simulationSettings;

    public Vector2 SimulationSize => m_simulationSettings.SimulationSize;

    [Inject]
    public void Construct(AgentSimulationSettings simulationSettings)
    {
        m_simulationSettings = simulationSettings;
    }

    public Vector3 GetRandomSimulationPos()
    {
        float randomX = Random.Range(0f, SimulationSize.x);
        float randomY = Random.Range(0f, SimulationSize.y);

        return new Vector3(randomX, randomY, 0f);
    }

    public Vector3 GetSimulationCenterPos()
    {
        return (Vector3)SimulationSize * 0.5f;
    }
}
