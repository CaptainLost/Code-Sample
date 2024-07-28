using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class AgentSelectionUI : MonoBehaviour
{
    [SerializeField]
    private GameObject m_agentSelectionUI;
    [SerializeField]
    private TextMeshProUGUI m_agentNameText;
    [SerializeField]
    private TextMeshProUGUI m_healthText;
    [SerializeField]
    private Slider m_healthSlider;

    private SignalBus m_signalBus;
    private IAgent m_displayedAgent;

    [Inject]
    public void Construct(SignalBus signalBus)
    {
        m_signalBus = signalBus;
    }

    private void OnEnable()
    {
        m_signalBus.Subscribe<AgentSelectedSignal>(OnAgentSelected);
        m_signalBus.Subscribe<AgentDeselectedSignal>(OnAgentDeselected);
        m_signalBus.Subscribe<AgentDamagedSignal>(OnAgentDamaged);
        m_signalBus.Subscribe<AgentDeathSignal>(OnAgentDeath);
    }

    private void OnDisable()
    {
        m_signalBus.Unsubscribe<AgentSelectedSignal>(OnAgentSelected);
        m_signalBus.Unsubscribe<AgentDeselectedSignal>(OnAgentDeselected);
        m_signalBus.Unsubscribe<AgentDamagedSignal>(OnAgentDamaged);
        m_signalBus.Unsubscribe<AgentDeathSignal>(OnAgentDeath);
    }

    public void Open()
    {
        m_agentSelectionUI.SetActive(true);
    }

    public void Close()
    {
        m_agentSelectionUI.SetActive(false);
    }

    private void OnAgentSelected(AgentSelectedSignal busEvent)
    {
        m_displayedAgent = busEvent.Agent;

        Open();
        RefreshUI();
    }

    private void OnAgentDeselected(AgentDeselectedSignal busEvent)
    {
        m_displayedAgent = null;

        Close();
    }

    private void OnAgentDamaged(AgentDamagedSignal busEvent)
    {
        if (m_displayedAgent == null)
            return;

        if (m_displayedAgent != busEvent.Agent)
            return;

        RefreshUI();
    }

    private void OnAgentDeath(AgentDeathSignal busEvent)
    {
        if (m_displayedAgent == null)
            return;

        if (m_displayedAgent != busEvent.Agent)
            return;

        Close();
    }

    private void RefreshUI()
    {
        m_agentNameText.text = m_displayedAgent.AgentData.AgentName;
        m_healthText.text = m_displayedAgent.Damagable.CurrentHealth.ToString() + "/" + m_displayedAgent.Damagable.MaxHealth.ToString();

        float maxHealth = m_displayedAgent.Damagable.MaxHealth != 0f ? m_displayedAgent.Damagable.MaxHealth : 1f;
        m_healthSlider.value = m_displayedAgent.Damagable.CurrentHealth / maxHealth;
    }
}
