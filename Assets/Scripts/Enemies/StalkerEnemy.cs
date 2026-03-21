using UnityEngine;

public class StalkerEnemy : BaseEnemy
{
    public override EnemyType Type => EnemyType.Visual;

    [SerializeField] private float _spawnDistance = 3f;
    [SerializeField] private float _followSpeed = 2f;

    private bool _spawned = false;

    public override void Tick()
    {
        if (_player == null) return;

        if (!_spawned)
        {
            SpawnBehindPlayer();
        }
        else
        {
            FollowPlayer();
        }
    }

    private void SpawnBehindPlayer()
    {
        Vector3 behind = -_player.forward * _spawnDistance;
        transform.position = _player.position + behind;

        _spawned = true;
    }

    private void FollowPlayer()
    {
        Vector3 direction = (_player.position - transform.position).normalized;
        transform.position += direction * _followSpeed * Time.deltaTime;
    }
}