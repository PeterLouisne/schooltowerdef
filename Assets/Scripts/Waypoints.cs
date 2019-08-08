//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] waypoints;

    private void Awake() // when the game begins get all the child of waypoint group and put into points arrau
    {
        waypoints = new Transform[transform.childCount]; // to who ever hold the script count the cildren of the group
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = transform.GetChild(i); //set those game objects into the waypoint array so we can asscess for enemy
        }
    }

}
