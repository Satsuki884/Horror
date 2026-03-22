using System.Collections;
using UnityEngine;

public class ScreamerSpawner : MonoBehaviour
{
    [Header("Spawn Time")]
    [SerializeField] private float _minDelay = 10f;
    [SerializeField] private float _maxDelay = 30f;

    [Header("Control")]
    [SerializeField] private bool _autoStart = true;
    [SerializeField] private int _maxSpawnsOnScene = 3;

    private Coroutine _spawnRoutine;

    [Header("Cleanup Settings")]
    [SerializeField] private float _stuckTime = 30f; // сколько ждать
    [SerializeField] private float _cleanupInterval = 5f; // как часто удалять

    private float _maxReachedTimer = 0f;
    private float _cleanupTimer = 0f;


    private void Start()
    {
        if (_autoStart)
        {
            StartSpawning();
        }
    }

    private void Update()
    {
        int current = CountScreamersOnScene();

        if (current >= _maxSpawnsOnScene)
        {
            _maxReachedTimer += Time.deltaTime;

            if (_maxReachedTimer >= _stuckTime)
            {
                _cleanupTimer += Time.deltaTime;

                if (_cleanupTimer >= _cleanupInterval)
                {
                    _cleanupTimer = 0f;

                    ScreamerEnemy[] screamers = FindObjectsByType<ScreamerEnemy>(FindObjectsSortMode.None);

                    if (screamers.Length > 0)
                    {
                        Destroy(screamers[0].gameObject);
                    }
                }
            }
        }
        else
        {
            _maxReachedTimer = 0f;
            _cleanupTimer = 0f;
        }
    }

    public void StartSpawning()
    {
        if (_spawnRoutine == null)
            _spawnRoutine = StartCoroutine(SpawnLoop());
    }

    public void StopSpawning()
    {
        if (_spawnRoutine != null)
        {
            StopCoroutine(_spawnRoutine);
            _spawnRoutine = null;
        }
    }

    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            float delay = Random.Range(_minDelay, _maxDelay);
            yield return new WaitForSeconds(delay);

            TrySpawn();
        }
    }

    private void TrySpawn()
    {
        if (MentalStateSystem.Instance == null) return;

        int current = CountScreamersOnScene();

        if (current >= _maxSpawnsOnScene)
        {
            // просто не спавним
            return;
        }

        MentalStateSystem.Instance.SpawnScreamer();

    }

    private int CountScreamersOnScene()
    {
        return FindObjectsByType<ScreamerEnemy>(FindObjectsSortMode.None).Length;
    }
}