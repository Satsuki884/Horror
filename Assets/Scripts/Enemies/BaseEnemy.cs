using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour, IEnemy
{
    public abstract EnemyType Type { get; }

    protected Transform _player;
    public virtual void Tick() { }
    public virtual void Initialize(Transform player)
    {
        _player = player;
    }

    public virtual void OnPlayerDetected() { }

    public virtual void OnPlayerLost() { }

    protected virtual void Update()
    {
        Tick();
    }
}