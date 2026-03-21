using UnityEngine;

public class ChaserEnemy : BaseEnemy
{
    public override EnemyType Type => EnemyType.Follow;

    [SerializeField] private float _speed = 4f;
    [SerializeField] private float _visionDistance = 10f;
    [SerializeField] private float _visionAngle = 60f;

    private bool _isChasing = false;

    public override void Tick()
    {
        if (_player == null) return;

        if (CanSeePlayer())
        {
            _isChasing = true;
            OnPlayerDetected();
        }
        else
        {
            _isChasing = false;
            OnPlayerLost();
        }

        if (_isChasing)
        {
            Chase();
        }
    }

    private bool CanSeePlayer()
    {
        Vector3 dirToPlayer = (_player.position - transform.position).normalized;

        float angle = Vector3.Angle(transform.forward, dirToPlayer);
        float distance = Vector3.Distance(transform.position, _player.position);

        return angle < _visionAngle && distance < _visionDistance;
    }

    private void Chase()
    {
        Vector3 dir = (_player.position - transform.position).normalized;
        transform.position += dir * _speed * Time.deltaTime;
    }

    public override void OnPlayerDetected()
    {
        Debug.Log("Player detected!");
    }

    public override void OnPlayerLost()
    {
        Debug.Log("Lost player");
    }
}