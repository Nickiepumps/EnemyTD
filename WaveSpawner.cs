using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemySpawnPoint;
    public Transform enemyPrefab;
    [SerializeField] float WaveTimerCountdown = 2f;
    [SerializeField] float CountdownTimer = 3f;
    [SerializeField] int waveTotal = 3;
    private int waveNumber = 0;

    private void Update()
    {
        CountdownTimer -= Time.deltaTime;
        if(CountdownTimer <= 0 && waveTotal > 0)
        {
            StartCoroutine(SpawnWave());
            CountdownTimer = WaveTimerCountdown;
        }

        if (waveTotal == 0)
        {
            Debug.Log("End of all Waves");
        }
    }

    IEnumerator SpawnWave()
    {
        waveNumber++;

        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            Debug.Log("Wave " + waveNumber);
            yield return new WaitForSeconds(0.2f);
           
        }

        waveTotal--;       
    }  
    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, enemySpawnPoint.position, enemySpawnPoint.rotation);
    }
}
