using Zenject;

public class AgentSimulationSignalsInstaller : Installer<AgentSimulationSignalsInstaller>
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);

        Container.DeclareSignal<AgentSelectedSignal>();
        Container.DeclareSignal<AgentDeselectedSignal>();
        Container.DeclareSignal<AgentDamagedSignal>();
        Container.DeclareSignal<AgentDeathSignal>();
    }
}
