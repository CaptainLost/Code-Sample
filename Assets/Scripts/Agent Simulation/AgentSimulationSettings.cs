using System;
using UnityEngine;

[Serializable]
public class AgentSimulationSettings
{
    [field: SerializeField]
    public int StartAmountOfAgentsMin { get; private set; }
    [field: SerializeField]
    public int StartAmountOfAgentsMax { get; private set; }
    [field: SerializeField]
    public int MaxAmountOfAgents { get; private set; }
    [field: SerializeField]
    public float AgentSpawnDelayMin { get; private set; }
    [field: SerializeField]
    public float AgentSpawnDelayMax { get; private set; }
    [field: SerializeField]
    public Vector2 SimulationSize { get; private set; }
    [field: SerializeField]
    public WanderingAgent AgentPrefab { get; private set; }
    [field: SerializeField]
    public Explosion ExplosionPrefab { get; private set; }
}
