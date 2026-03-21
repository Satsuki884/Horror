using UnityEngine;

public enum EnemyType
{
    Sound, Visual, Follow
}
public interface IEnemy
{
    EnemyType Type { get; }

    void Initialize(Transform player);
    // void Tick(); // логіка кожен кадр
    void OnPlayerDetected();
}