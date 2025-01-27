using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> minionPrefabs;
    [SerializeField] private List<Transform> spawnPoints;
    private float spawnTimer;
    [SerializeField] float spawnInterval = 1f;
    void Start()
    {
        spawnPoints = new List<Transform>();
        GameObject[] spawnPointObjects = GameObject.FindGameObjectsWithTag("SpawnPoint");

        foreach (GameObject spawnPointObject in spawnPointObjects)
        {
            spawnPoints.Add(spawnPointObject.transform);
        }
        if (spawnPoints.Count == 0)
        {
            Debug.LogWarning("No spawn points found with the tag 'SpawnPoint'.");
        }

        minionPrefabs = new List<GameObject>();
        Object[] loadedPrefabs = Resources.LoadAll("Minions", typeof(GameObject));

        foreach (Object prefab in loadedPrefabs)
        {
            minionPrefabs.Add((GameObject) prefab);
        }
        if (minionPrefabs.Count == 0)
        {
            Debug.LogWarning("No minion prefabs found in Resources/Minions folder.");
        }
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            SpawnMinion();
            spawnTimer = 0f;
        }
    }
    void SpawnMinion()
    {
        if (minionPrefabs.Count > 0 && spawnPoints != null)
        {
            int randomMinionIndex = Random.Range(0, minionPrefabs.Count);
            int randomSpawnIndex = Random.Range(0, spawnPoints.Count);

            Instantiate(minionPrefabs[randomMinionIndex], spawnPoints[randomSpawnIndex].position, spawnPoints[randomSpawnIndex].rotation);
        }
    }
}
