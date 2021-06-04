using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Wave[] waves;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    float m_coutdown = 2f;

    public Text WaveCountdownText;

    public GameManager gameManager;

    int m_waveIndex = 0;



    void Awake()
    {
        EnemiesAlive = 0;
    }



    void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }

        if (m_waveIndex == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

        if (m_coutdown <= 0)
        {
            StartCoroutine(SpawnWave());
            m_coutdown = timeBetweenWaves;
            return;
        }

        m_coutdown -= Time.deltaTime;

        m_coutdown = Mathf.Clamp(m_coutdown, 0f, Mathf.Infinity);

        WaveCountdownText.text = string.Format("{0:00.00}", m_coutdown);
    }


    IEnumerator SpawnWave ()
    {
        PlayerStats.Rounds++;

        Wave wave = waves[m_waveIndex];

        EnemiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        m_waveIndex++;                
    }


    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);        
    }
}
