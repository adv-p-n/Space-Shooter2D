using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves=0f;
    WaveConfigSO currentWave;
    bool isLooping = true;
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        do
        {
            foreach( WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;
                for(int i=0; i  < currentWave.GetEnemyCount() ; i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(0),                        //Which object to spawn
                                currentWave.GetFirstWaypoint().position,              //Where to spawn
                                Quaternion.Euler(0,0,180),                                 //rotation also has to be passed which is of type Quaternion so we use quaternion.identity to set zero rotation
                                transform);                                          // Transform of parent noew all the spawned objects will be Children of EnemySpawner object
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
            }yield return new WaitForSeconds(timeBetweenWaves);
        }
        while (isLooping);
        
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

}
