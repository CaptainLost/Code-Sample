public class WanderingAgentData : IAgentData
{
    public WanderingAgentData()
    {
        AgentName = AgentNameGenerator.GetRandomName();
    }

    public string AgentName { get; private set; }
}
