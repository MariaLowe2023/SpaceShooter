using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefab;
    [SerializeField] Transform pathPrefab; //contains the waypoints made in Unity
    [SerializeField] float moveSpeed = 1f;

    [SerializeField] float timeBetweenEnemySpawns = 1f;
    [SerializeField] float spawnTimeVariance = 0f;
    [SerializeField] float minimumSpawnTime = 0.2f;

    public Transform GetStartingWaypoint() //the starting point of the path is the first child
    {
        // get thr first child from the pathPrefab that was created in Unity        
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWaypoints() //we want to get all of the waypoints
                                          //this creates a list of all the Transform's
    {
        List<Transform> waypoints = new List<Transform>(); //create a new List of Transforms
        foreach (Transform child in pathPrefab) //loop through all of the children
                                                //for each child in my pathprefab
                                                //add the child to the list created "waypoints" 
                                                //for EVERY child in the pathprefab we do this!!!
        {
            waypoints.Add(child); //we are going to add a child to the List created before "waypoints"
                                  //we add children instead of values for flexibility, 
        }
        return waypoints; //when thats all done and we've gone through all the children
                          //we're going to return our list == basically tell me whats in the list
    }

    public float GetMoveSpeed() //this exists so that we can script the movespeed in different scripts
    {
        return moveSpeed;
    }

    public int GetEnemyCount()
    {
        return enemyPrefab.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefab[index];
    }

    public float GetRandomSpawnTime()
    {
        float spawnTIme = Random.Range(timeBetweenEnemySpawns - spawnTimeVariance,
                                        timeBetweenEnemySpawns + spawnTimeVariance);
        return Mathf.Clamp(spawnTIme, minimumSpawnTime, float.MaxValue);
    }
}


