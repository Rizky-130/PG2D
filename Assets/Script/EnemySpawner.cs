using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    public GameObject enemyPrefab;
    [Header("Spawn Settings")]
    public float firstSpawnDelay = 2f;
    public float spawnInterval = 4f;
    [Header("Spawn Points")]
    public Transform[] spawnPoints;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        if (enemyPrefab == null)
        {
            Debug.LogWarning("Enemy prefab is not assigned.");
            yield break;
        }

        if (spawnPoints == null || spawnPoints.Length == 0)
        {
            Debug.LogWarning("No spawn points are assigned.");
            yield break;
        }

        yield return new WaitForSeconds(firstSpawnDelay);

        while (true)
        {
            Transform spawnPoint = GetRandomSpawnPoint();
            if (spawnPoint == null)
            {
                Debug.LogWarning("No valid spawn points are assigned.");
                yield break;
            }

            SpawnEnemy(spawnPoint.position);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private Transform GetRandomSpawnPoint()
    {
        int validPointCount = 0;
        foreach (Transform point in spawnPoints)
        {
            if (point != null)
            {
                validPointCount++;
            }
        }

        if (validPointCount == 0)
        {
            return null;
        }

        int selectedPoint = Random.Range(0, validPointCount);
        foreach (Transform point in spawnPoints)
        {
            if (point != null && selectedPoint-- == 0)
            {
                return point;
            }
        }

        return null;
    }

    public void SpawnEnemy(Vector3 spawnPosition)
    {
        if (enemyPrefab == null)
        {
            Debug.LogWarning("Enemy prefab is not assigned.");
            return;
        }

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
