using AIBehaviourTree;
using UnityEngine;
using Zenject;

public class WanderingAgentInstaller : MonoInstaller
{
    [SerializeField]
    private WanderingAgentSettings m_settings;

    public override void InstallBindings()
    {
        Container.Bind<WanderingAgentSettings>()
            .FromInstance(m_settings)
            .AsSingle();

        Container.Bind(typeof(IAgent), typeof(WanderingAgent))
            .To(typeof(WanderingAgent))
            .FromComponentOnRoot()
            .AsSingle();

        Container.Bind<BehaviourTree>()
            .AsSingle()
            .WithArguments("Wandering Agent Tree");

        Container.Bind(typeof(IDeathHandler), typeof(WanderingAgentDeathHandler))
            .To(typeof(WanderingAgentDeathHandler))
            .AsSingle();

        Container.Bind<IDamagable>()
            .To<AgentDamagable>()
            .AsSingle();
    }
}
