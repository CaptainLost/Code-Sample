using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSimulation
{
    private readonly AgentSimulationSettings m_settings;

    private List<IAgent> m_agentList;

    public AgentSimulation(AgentSimulationSettings settings)
    {
        m_settings = settings;

        m_agentList = new List<IAgent>();
    }
}
