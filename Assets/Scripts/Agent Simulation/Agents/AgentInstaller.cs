using UnityEngine;
using Zenject;

public class AgentInstaller : MonoInstaller
{
    [SerializeField]
    private AgentSettings m_settings;

    public override void InstallBindings()
    {
        Container.Bind<AgentSettings>()
            .AsSingle();

        Container.Bind<IDamagable>()
            .To<AgentDamagable>()
            .AsSingle();
    }
}
