using UnityEngine;

public class WaveSpawn : MonoBehaviour
{
    public int[] waves = new int[5] { 1, 2, 4, 8, 8 };
    public float timeBetweenWaves = 4f, timeBetweenEnemies = 0.5f;
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public static float enemiesAmount = 0;

    private float countdown = 2f;
    private bool inProgress = false;
    private int wavesIndex = 0, enemyIndex = 0, currentWaveMax = 0;

    void Awake()
    {
        for(int i = 0; i < waves.Length; i++)
        {
            enemiesAmount += waves[i];
        }
    }
 
    void Update()
    {
        if(countdown <= 0f && !inProgress)
        {
            SpawnWave();
        }

        if (enemyIndex >= currentWaveMax && inProgress)
        {
            CancelInvoke("SpawnEnemy");
            enemyIndex = 0;
            inProgress = !inProgress;
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }

    private void SpawnWave()
    {
        if (wavesIndex >= waves.Length) Destroy(gameObject);
        else
        {
            currentWaveMax = waves[wavesIndex];
            inProgress = !inProgress;
            InvokeRepeating("SpawnEnemy", 0.01f, timeBetweenEnemies);
            wavesIndex++;
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        enemyIndex++;
    }
}
