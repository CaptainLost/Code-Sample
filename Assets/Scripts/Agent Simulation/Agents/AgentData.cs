public class AgentData : IAgentData
{
    public AgentData()
    {
        AgentName = AgentNameGenerator.GetRandomName();
    }

    public string AgentName { get; private set; }
}
