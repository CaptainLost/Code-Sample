public struct AgentSelectedSignal
{
    public readonly IAgent Agent;
    
    public AgentSelectedSignal(IAgent agent)
    {
        Agent = agent;
    }
}

public struct AgentDeselectedSignal
{
    public readonly IAgent Agent;

    public AgentDeselectedSignal(IAgent agent)
    {
        Agent = agent;
    }
}

public struct AgentDamagedSignal
{
    public readonly IAgent Agent;

    public AgentDamagedSignal(IAgent agent)
    {
        Agent = agent;
    }
}

public struct AgentDeathSignal
{
    public readonly IAgent Agent;

    public AgentDeathSignal(IAgent agent)
    {
        Agent = agent;
    }
}