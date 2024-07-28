using UnityEngine;
using Zenject;

public class AgentSelectable : MonoBehaviour
{
    [SerializeField]
    private GameObject m_selectionVisualObject;

    public Agent Agent { get; private set; }

    [Inject]
    public void Construct(Agent agent)
    {
        Agent = agent;
    }

    private void Awake()
    {
        Deselect();
    }

    public void Select()
    {
        m_selectionVisualObject.SetActive(true);
    }

    public void Deselect()
    {
        m_selectionVisualObject.SetActive(false);
    }
}
