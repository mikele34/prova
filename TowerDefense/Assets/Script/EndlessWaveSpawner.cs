using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndlessWaveSpawner : MonoBehaviour
{
    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    float coutdown = 2f;

    public Text WaveCountdownText;

    public GameManager gameManager;



    void Update()
    {

        coutdown -= Time.deltaTime;

        coutdown = Mathf.Clamp(coutdown, 0f, Mathf.Infinity);

        WaveCountdownText.text = string.Format("{0:00.00}", coutdown);
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
