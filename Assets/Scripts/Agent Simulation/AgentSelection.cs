using UnityEngine;
using Zenject;

public class AgentSelection : ITickable
{
    public void Tick()
    {
        CheckSelection();
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
        agentSelectable.Select();
    }
}
