using UnityEngine;
using Zenject;

public class AgentSelection : ITickable
{
    private readonly SignalBus m_signalBus;

    private AgentSelectable m_currentSelectable;

    public AgentSelection(SignalBus signalBus)
    {
        m_signalBus = signalBus;
    }

    public void Tick()
    {
        CheckSelection();
    }

    public void Select(AgentSelectable selectable)
    {
        DeselectCurrent();

        m_currentSelectable = selectable;
        selectable.Select();

        m_signalBus.Fire(new AgentSelectedSignal(selectable.Agent));
    }

    public void DeselectCurrent()
    {
        if (m_currentSelectable == null)
            return;

        m_signalBus.Fire(new AgentDeselectedSignal(m_currentSelectable.Agent));

        m_currentSelectable.Deselect();
        m_currentSelectable = null;
    }

    // Old input system, no need for new
    private void CheckSelection()
    {
        if (!Input.GetMouseButtonDown(0))
            return;

        Vector3 mousePosition = Input.mousePosition;
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(mousePosition);

        RaycastHit2D raycastHit = Physics2D.Raycast(mouseWorld, Vector2.zero);

        if (raycastHit.collider == null)
            return;

        AgentSelectable agentSelectable = raycastHit.collider.GetComponent<AgentSelectable>();

        if (agentSelectable == null)
            return;

        if (agentSelectable == m_currentSelectable)
        {
            DeselectCurrent();

            return;
        }

        Select(agentSelectable);
    }
}
