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

        Container.Bind<AgentSimulationBoundary>()
            .AsSingle();

        Container.Bind<AgentRegistry>()
            .AsSingle()
            .NonLazy();

        Container.BindInterfacesAndSelfTo<AgentSpawner>()
            .AsSingle()
            .NonLazy();

        Container.BindFactory<WanderingAgent, WanderingAgent.Factory>()
            .FromPoolableMemoryPool<WanderingAgent, AgentPool>(poolBinder => poolBinder
                .WithInitialSize(10)
                .FromComponentInNewPrefab(m_settings.AgentPrefab)
                .UnderTransformGroup("Agents"));

        Container.BindFactory<Explosion, Explosion.Factory>()
            .FromPoolableMemoryPool<Explosion, ExplosionPool>(poolBinder => poolBinder
            .WithInitialSize(5)
            .FromComponentInNewPrefab(m_settings.ExplosionPrefab)
            .UnderTransformGroup("Effects"));

        Container.BindInterfacesAndSelfTo<AgentSelection>()
            .AsSingle()
            .NonLazy();

        AgentSimulationSignalsInstaller.Install(Container);
    }

    class AgentPool : MonoPoolableMemoryPool<IMemoryPool, WanderingAgent>
    {

    }

    class ExplosionPool : MonoPoolableMemoryPool<IMemoryPool, Explosion>
    {

    }
}
