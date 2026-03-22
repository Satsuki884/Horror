using System.Collections.Generic;
using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _keysPrefabs;
    [SerializeField] private List<KeyPoint> _spawnPoints;

    private void Start()
    {
        SpawnKeys();
    }

    private void SpawnKeys()
    {
        List<KeyPoint> availablePoints = new List<KeyPoint>(_spawnPoints);

        for (int i = 0; i < _keysPrefabs.Count; i++)
        {
            if (availablePoints.Count == 0) return;

            int randomIndex = Random.Range(0, availablePoints.Count);
            KeyPoint point = availablePoints[randomIndex];

            Instantiate(_keysPrefabs[i], point.transform.position, Quaternion.identity);

            point.SetOccupied(true);
            availablePoints.RemoveAt(randomIndex);
        }
    }
}