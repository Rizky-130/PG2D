using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteSpawner : MonoBehaviour
{
    [SerializeField] WasteItem[] wastePrefabs;
    [SerializeField] float interval = 1f;
    [SerializeField] float spawnY = 6f;
    [SerializeField] float xRange = 7f;
    float timer = 0f;
    void Update()
    {
        if (wastePrefabs == null || wastePrefabs.Length == 0) return;
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            timer = 0f;
            int i = Random.Range(0, wastePrefabs.Length);
            Vector3 pos = new Vector3(Random.Range(-xRange, xRange), spawnY, 0f);
            Instantiate(wastePrefabs[i], pos, Quaternion.identity);
        }
    }
}
