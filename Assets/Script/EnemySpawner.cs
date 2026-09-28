using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    public GameObject enemyPrefab;
    [Header("Spawn Settings")]
    public float firstSpawnDelay = 2f;
    public float spawnInterval = 4f;
    [Header("Spawn Area")]
    public float spawnAreaWidth = 8f;
    public float spawnAreaHeight = 1f;


    void Start()
    {
        SpawnEnemy(new Vector3(0,5,0));
    }
    public void SpawnEnemy(Vector3 posisi)
    {
        if (enemyPrefab == null)
        {
            Debug.LogWarning("Enemy prefab is not assigned.");
            return;
        }
        Instantiate(enemyPrefab, posisi, Quaternion.identity);
    }
}
