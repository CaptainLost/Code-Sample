using UnityEngine;
using Zenject;

public class AgentSimulationCamera : MonoBehaviour
{
    [SerializeField]
    private Vector2 m_cameraSizeOffset;

    private AgentSimulationBoundary m_simulationBoundary;
    private Camera m_camera;

    [Inject]
    private void Construct(AgentSimulationBoundary simulationBoundary)
    {
        m_simulationBoundary = simulationBoundary;
    }

    // Do camera updates one time, simulation size isn't consider to change
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
        Vector2 cameraSimulationSize = m_simulationBoundary.SimulationSize + m_cameraSizeOffset;

        float ortoHeight = cameraSimulationSize.y * 0.5f;
        float ortoWidth = (cameraSimulationSize.x / m_camera.aspect) * 0.5f;

        m_camera.orthographicSize = Mathf.Max(ortoWidth, ortoHeight);
    }
}
