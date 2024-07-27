using UnityEngine;
using Zenject;

public class AgentInstaller : MonoInstaller
{
    [SerializeField]
    private AgentSettings m_settings;

    public override void InstallBindings()
    {
        Container.Bind<AgentSettings>()
            .FromInstance(m_settings)
            .AsSingle();

        Container.Bind<Agent>()
            .FromComponentOnRoot()
            .AsSingle();

        Container.Bind<AgentDeathHandler>()
            .AsSingle();

        Container.Bind<IDamagable>()
            .To<AgentDamagable>()
            .AsSingle();
    }
}
