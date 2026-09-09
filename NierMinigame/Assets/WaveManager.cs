using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField] private GameObject enemyPrefab;

    [Header("Spawn Points")]
    [SerializeField] private Transform[] spawnPoints;

    [Header("Wave Settings")]
    [SerializeField] private int wave1EnemyCount = 2;
    [SerializeField] private int wave2EnemyCount = 4;
    [SerializeField] private float timeBetweenWaves = 8f;

    [Header("Shield")]
    [SerializeField] private CoreShieldManager shieldManager;
    [SerializeField] private float shieldBreakTime = 15f;

    private void Start()
    {
        StartCoroutine(StartWaves());
        StartCoroutine(BreakShieldAfterTime());
    }

    private IEnumerator StartWaves()
    {
        // Wave 1
        SpawnEnemies(wave1EnemyCount);

        // Wait 8 seconds
        yield return new WaitForSeconds(timeBetweenWaves);

        // Wave 2
        SpawnEnemies(wave2EnemyCount);
    }

    private IEnumerator BreakShieldAfterTime()
    {
        // Wait 15 seconds
        yield return new WaitForSeconds(shieldBreakTime);

        // Break the shield
        if (shieldManager != null)
        {
            shieldManager.DestroyShield();
        }
    }

    private void SpawnEnemies(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Transform spawnPoint = spawnPoints[i % spawnPoints.Length];

            Instantiate(
                enemyPrefab,
                spawnPoint.position,
                Quaternion.identity
            );
        }
    }
}