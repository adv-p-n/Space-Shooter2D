using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject 
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefab;               //The required "path" added in this Field
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float spawnTime = 1f;
    [SerializeField] float timeVariation= 0f;
    [SerializeField] float minTime= 0.2f;

    public float GetMoveSpeed()                          // To get the speed outside of the SO
    {
        return moveSpeed;
    }

    public Transform GetFirstWaypoint()                   // Reference to get the starting Waypoint Outside of SO
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWaypoints()                  // We create a list of Transform and add all the waypoints in the path to it 
    {                                                      // Now we have a reference to all the waypoints in the path. 
        List<Transform> waypoint = new List<Transform>() ; // New List variable of type transform to store all the waypoints 
        foreach (Transform child in pathPrefab)              
        {
            waypoint.Add(child);
        }
        return waypoint;
    }
    
    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }

    public float GetRandomSpawnTime()
    {
        float randomSpawnTime = Random.Range( spawnTime-timeVariation,spawnTime+timeVariation);
        return Mathf.Clamp(randomSpawnTime,minTime,float.MaxValue);
        
    }
}

