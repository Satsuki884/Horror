using System.Collections.Generic;
using UnityEngine;

public class AmuletSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _amuletsPrefabs;
    [SerializeField] private List<AmuletPoint> _spawnPoints;

    private void Start()
    {
        SpawnAmulets();
    }

    private void SpawnAmulets()
    {
        List<AmuletPoint> availablePoints = new List<AmuletPoint>(_spawnPoints);

        for (int i = 0; i < _amuletsPrefabs.Count; i++)
        {
            if (availablePoints.Count == 0) return;

            int randomIndex = Random.Range(0, availablePoints.Count);
            AmuletPoint point = availablePoints[randomIndex];

            Instantiate(_amuletsPrefabs[i], point.transform.position, Quaternion.identity);

            point.SetOccupied(true);
            availablePoints.RemoveAt(randomIndex);
        }
    }
}