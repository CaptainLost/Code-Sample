using System;
using UnityEngine;

[Serializable]
public class AgentSimulationSettings
{
    [field: SerializeField]
    public int StartAmountAgentsMin { get; private set; }
    [field: SerializeField]
    public int StartAmountAgentsMax { get; private set; }
    [field: SerializeField]
    public int MaxAmountOfAgents { get; private set; }
}
