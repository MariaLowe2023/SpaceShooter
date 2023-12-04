using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    EnemySpawner enemyspawner;
    WaveConfigSO waveConfig; //this creates a reference to the wave config
    List<Transform> waypoints; //we're bringing the list from the wavconfigSO scrip
    int waypointIndex = 0; //create an Index to start with 0

    void Awake()
    {
        enemyspawner = FindObjectOfType<EnemySpawner>();
    }

    void Start()
    {
        waveConfig = enemyspawner.GetCurrentWave();
        waypoints = waveConfig.GetWaypoints(); //reference the script in start so unity knows where to get it from
        transform.position = waypoints[waypointIndex].position; //move enemy to the first waypoint in the path
    }


    void Update()
    {
        FollowPath(); //in Update, every frame,
                      //we want to have the enemy move closer to the next waypoint in the list
    }

    void FollowPath()
    {
        if(waypointIndex < waypoints.Count) //if the Index of waypoint is smaller
                                            //than the number of waypoints there are
                                            //so basically if we're not at the last waypoint

                                            //then we want to move to the next waypoint in the list
                                            //we need to know:
                                            //where we are
                                            //                  -> we know this in start method
                                            //                  -> line 15
                                            //where we are going
                                            //and how fast were going
        {
            Vector3 tragetPosition = waypoints[waypointIndex].position; //create a new vector(targetposition) which determines where we want to go
                                                                        //this is defined by the list "waypoints" Index's position

            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;   // this determines the distance that we move each frame
                                                                        // from waveconfig get the move speed
                                                                        // and multiply it to be indepentent from framerate

            transform.position = Vector2.MoveTowards(transform.position, tragetPosition, delta); 
            //to actually move we need to set the position to be equall to a new value/vector                                                                              
            //so create a new vector -> movetowards(currentposition, targetposition, delta)
 
            if(transform.position == tragetPosition) //checks the current position of the gameobject this script is one
                                                     //if its position is the same as the targetposition defined earlier
                                                     //then add 1 to the Index 
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
