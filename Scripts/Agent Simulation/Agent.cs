using System;
using UnityEngine;
using Zenject;

public class Agent : MonoBehaviour, IAgent, IPoolable<IMemoryPool>, IDisposable
{
    private IMemoryPool m_memoryPool;

    public void OnSpawned(IMemoryPool memoryPool)
    {
        m_memoryPool = memoryPool;
    }

    public void OnDespawned()
    {
        
    }

    public void Dispose()
    {
        m_memoryPool.Despawn(this);
    }

    public class Factory : PlaceholderFactory<Agent>
    {

    }
}
