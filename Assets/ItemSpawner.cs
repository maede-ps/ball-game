using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnItem
{
    public GameObject prefab;
    public float weight = 1f;
}

public class ItemSpawner : MonoBehaviour
{
    public List<SpawnItem> items;
    public float minSpawnDelay = 1f;
    public float maxSpawnDelay = 3f;

    public Vector2 areaSize = new Vector2(5f, 3f);
    public Vector2 spawnOffset = Vector2.zero; // ✅ Offset جدید
    public float minDistanceBetweenItems = 1f;

    private List<Vector3> recentPositions = new List<Vector3>();



    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator<WaitForSeconds> SpawnRoutine()
    {
        while (true)
        {
            SpawnRandomItem();
            float delay = Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(delay);
        }
    }

    void SpawnRandomItem()
    {
        GameObject selectedPrefab = GetWeightedRandomItem();
        if (selectedPrefab == null) return;

        Vector3 spawnPos = GetValidSpawnPosition();

        if (spawnPos != Vector3.zero)
        {
            Instantiate(selectedPrefab, spawnPos, Quaternion.identity);
            recentPositions.Add(spawnPos);

            if (recentPositions.Count > 10)
                recentPositions.RemoveAt(0);
        }
    }

    GameObject GetWeightedRandomItem()
    {
        float totalWeight = 0f;
        foreach (var item in items)
            totalWeight += item.weight;

        float randomValue = Random.Range(0f, totalWeight);
        float currentWeight = 0f;

        foreach (var item in items)
        {
            currentWeight += item.weight;
            if (randomValue <= currentWeight)
                return item.prefab;
        }

        return null;
    }

    Vector3 GetValidSpawnPosition()
    {
        int tries = 20;
        while (tries-- > 0)
        {
            Vector3 randomPos = transform.position + new Vector3(
                Random.Range(-areaSize.x / 2, areaSize.x / 2) + spawnOffset.x,
                Random.Range(-areaSize.y / 2, areaSize.y / 2) + spawnOffset.y,
                0);

            bool tooClose = false;
            foreach (var pos in recentPositions)
            {
                if (Vector3.Distance(pos, randomPos) < minDistanceBetweenItems)
                {
                    tooClose = true;
                    break;
                }
            }

            if (!tooClose)
                return randomPos;
        }

        return Vector3.zero;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 center = transform.position + new Vector3(spawnOffset.x, spawnOffset.y, 0);
        Gizmos.DrawWireCube(center, new Vector3(areaSize.x, areaSize.y, 0.1f));
    }
}
