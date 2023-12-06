using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    EnemySpawner enemyspawner;
    WaveConfigSO waveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;

    void Awake()
    {
        enemyspawner = FindObjectOfType<EnemySpawner>();
    }

    void Start()
    {
        waveConfig = enemyspawner.GetCurrentWave();
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;


    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if(waypointIndex < waypoints.Count) 
        {
            Vector3 tragetPosition = waypoints[waypointIndex].position; 
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;   
            transform.position = Vector2.MoveTowards(transform.position, tragetPosition, delta); 
             
            if(transform.position == tragetPosition) 
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
