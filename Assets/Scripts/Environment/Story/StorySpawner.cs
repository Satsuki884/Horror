using System.Collections.Generic;
using UnityEngine;

public class StorySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _storiesPrefabs;
    [SerializeField] private List<StoryPoint> _spawnPoints;

    private void Start()
    {
        SpawnStories();
    }

    private void SpawnStories()
    {
        List<StoryPoint> availablePoints = new List<StoryPoint>(_spawnPoints);

        for (int i = 0; i < _storiesPrefabs.Count; i++)
        {
            if (availablePoints.Count == 0) return;

            int randomIndex = Random.Range(0, availablePoints.Count);
            StoryPoint point = availablePoints[randomIndex];

            Instantiate(_storiesPrefabs[i], point.transform.position, Quaternion.identity);

            point.SetOccupied(true);
            availablePoints.RemoveAt(randomIndex);
        }
    }
}