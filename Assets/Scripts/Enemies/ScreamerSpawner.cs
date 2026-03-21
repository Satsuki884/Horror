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

    private void Start()
    {
        if (_autoStart)
        {
            StartSpawning();
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
            Debug.Log("Too many screamers on scene");
            return;
        }

        MentalStateSystem.Instance.SpawnScreamer();
        // Debug.Log("Spawned Screamer");
    }

    private int CountScreamersOnScene()
    {
        return FindObjectsByType<ScreamerEnemy>(FindObjectsSortMode.None).Length;
    }
}