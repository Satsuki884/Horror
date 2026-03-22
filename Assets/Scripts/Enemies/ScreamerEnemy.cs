using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamerEnemy : BaseEnemy
{
    public override EnemyType Type => EnemyType.Sound;

    [SerializeField] private GameObject _screamerVisual;
    private Canvas _canvas;
    [SerializeField] private float _triggerDistance = 0.5f;
    [SerializeField] private float _mentalDamage = 5f;

    private GameObject _currentVisual;
    private bool _triggered = false;

    private void Start()
    {
        _canvas = FindAnyObjectByType<Canvas>();
    }

    public override void Tick()
    {
        if (_triggered || _player == null) return;

        float distance = Vector3.Distance(transform.position, _player.position);

        if (distance <= _triggerDistance)
        {
            TriggerScream();
        }
    }

    private void TriggerScream()
    {
        _triggered = true;

        if (_screamerVisual != null)
            _currentVisual = Instantiate(_screamerVisual, _canvas.transform);

        MentalStateSystem.Instance?.AddMental(_mentalDamage);

        Debug.Log("SCREAM!");
        Destroy(gameObject, 0.5f);
        Destroy(_currentVisual, 2f);
    }
}