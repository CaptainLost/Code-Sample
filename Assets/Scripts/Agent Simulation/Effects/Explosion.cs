using UnityEngine;
using Zenject;

public class Explosion : MonoBehaviour, IPoolable<IMemoryPool>
{
    [SerializeField]
    private float m_playTime;
    [SerializeField]
    private ParticleSystem m_particleSystem;

    private IMemoryPool m_memoryPool;
    private float m_startTime;

    private void Update()
    {
        if (Time.time - m_startTime > m_playTime)
        {
            m_memoryPool.Despawn(this);
        }
    }

    public void OnSpawned(IMemoryPool memoryPool)
    {
        m_memoryPool = memoryPool;
        m_startTime = Time.time;

        m_particleSystem.Clear();
        m_particleSystem.Play();
    }

    public void OnDespawned()
    {
        
    }

    public class Factory : PlaceholderFactory<Explosion>
    {

    }
}
