using UnityEngine;
using Zenject;

public class AgentSimulationInstaller : MonoInstaller
{
    [SerializeField]
    private AgentSimulationSettings m_settings;

    public override void InstallBindings()
    {
        Container.Bind<AgentSimulationSettings>()
            .FromInstance(m_settings)
            .AsSingle();

        Container.Bind<AgentSimulation>()
            .AsSingle()
            .NonLazy();

        Container.BindInterfacesAndSelfTo<AgentSpawner>()
            .AsSingle()
            .NonLazy();

        Container.BindFactory<Agent, Agent.Factory>()
            .FromPoolableMemoryPool<Agent, AgentPool>(poolBinder => poolBinder
                .FromComponentInNewPrefab(m_settings.AgentPrefab));
    }

    class AgentPool : MonoPoolableMemoryPool<IMemoryPool, Agent>
    {

    }
}
