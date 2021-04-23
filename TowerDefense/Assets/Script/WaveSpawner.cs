using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Wave[] waves;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    float coutdown = 2f;

    public Text WaveCountdownText;

    public GameManager gameManager;

    int waveIndex = 0;

    private void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }

        if (waveIndex == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

        if (coutdown <= 0)
        {
            StartCoroutine(SpawnWave());
            coutdown = timeBetweenWaves;
            return;
        }

        coutdown -= Time.deltaTime;

        coutdown = Mathf.Clamp(coutdown, 0f, Mathf.Infinity);

        WaveCountdownText.text = string.Format("{0:00.00}", coutdown);
    }

    IEnumerator SpawnWave ()
    {
        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];

        EnemiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        waveIndex++;                
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);        
    }
}
