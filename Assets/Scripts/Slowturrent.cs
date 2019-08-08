using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slowturrent : MonoBehaviour
{
    public Transform target; // target to shoot;
    public string enemyTag = "Enemy";
    public float turrentrotation_speed = 10f;
    public Transform parttorotate;

    // May things about turrent
    [Header("turrent attributes")]
    public float range = 15f; // range of the turrents
    public float fireRate = 1f;
    private float fireCountdown = 0f; // time inbetween shooting like fix update but no
    public int points_to_build = 50;
    BuildManager buildManger;
    UnityEngine.AI.NavMeshAgent nav;
    Enemymove target_enem;

    public int upgrade_dmg = 30;
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, .5f);
        buildManger = BuildManager.instance;
    }
    void UpdateTarget() // gonna find the close target and if is in range set target to that target every set of time seconds not frames so not taxing
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity; // if no enemy we have infinte distance to the enemy
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            nav = enemy.GetComponent<UnityEngine.AI.NavMeshAgent>();
            target_enem = enemy.GetComponent<Enemymove>();
            if (distanceToEnemy <= range) //basically find the shortest distance for that enemy
            {
                if (!target_enem.slowed)
                {
                    nav.speed = nav.speed / 2;
                    target_enem.slowed = true;
                }

            }
            if (target_enem.slowed == true && distanceToEnemy > range)
            {
                nav.speed = nav.speed * 2;
                target_enem.slowed = false;
            }
        }
    }
    void Update()
    {
        if (target == null)
            return;
        if (fireCountdown <= 0f)
        {
           
            fireCountdown = 1f / fireRate; // set cound to equal 1/ fire rate 
        }
        fireCountdown -= Time.deltaTime;
    }


    private void OnDrawGizmosSelected() // idea for the range of the turrents of that time .
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
