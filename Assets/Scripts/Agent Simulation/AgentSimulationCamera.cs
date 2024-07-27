using UnityEngine;
using Zenject;

public class AgentSimulationCamera : MonoBehaviour
{
    private AgentSimulationBoundary m_simulationBoundary;
    private Camera m_camera;

    [Inject]
    private void Construct(AgentSimulationBoundary simulationBoundary)
    {
        m_simulationBoundary = simulationBoundary;
    }

    private void Awake()
    {
        m_camera = GetComponent<Camera>();

        SetPositionToSimulationCenter();
        SetSizeToSimulationSize();
    }

    private void SetPositionToSimulationCenter()
    {
        Vector3 newPosition = transform.position;
        Vector3 simulationCenter = m_simulationBoundary.GetSimulationCenterPos();

        newPosition.x = simulationCenter.x;
        newPosition.y = simulationCenter.y;

        transform.position = newPosition;
    }

    private void SetSizeToSimulationSize()
    {
        float ortoHeight = m_simulationBoundary.SimulationSize.y * 0.5f;
        float ortoWidth = (m_simulationBoundary.SimulationSize.x / m_camera.aspect) * 0.5f;

        m_camera.orthographicSize = Mathf.Max(ortoWidth, ortoHeight);
    }
}
