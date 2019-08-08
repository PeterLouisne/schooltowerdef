using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 10f;

    private Transform target; // where enmies hate
    private int wavepointIndex = 0;

    void Start()
    {
        target = Waypoints.waypoints[wavepointIndex];   
    }
    void Update()
    {
        Vector3 dir = target.position - transform.position; // get the direction of the position of who holds the script to the point 
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World); // time.delta time is used is not depended on the frame rate but with the actual time.
        if (Vector3.Distance(transform.position, target.position) <= .2f) // if distance from waypoint is at least .2 units
        {
            GetNextWaypoint();
        }
    }
    void GetNextWaypoint()
    {
        if(wavepointIndex >= Waypoints.waypoints.Length -1)
        {
            Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        target = Waypoints.waypoints[wavepointIndex];
    }
}
