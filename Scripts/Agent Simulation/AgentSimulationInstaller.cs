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
    }
}
