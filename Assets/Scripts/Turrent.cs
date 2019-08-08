using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Turrent : MonoBehaviour
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
    public int turrentdmg = 20;
    public int points_to_build = 50;
    BuildManager buildManger;
    public GameObject bulletPrefab; // what the bullet looks like
    public Transform firePoint; // poistion of where the bullet is spawned



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
            if (distanceToEnemy < shortestDistance) //basically find the shortest distance for that enemy
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range) // if enemy found in tange
        {
            target = nearestEnemy.transform;
        }
        else {
            target = null;
        }
    }
    void Update()
    {
        if (target == null)
            return;
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir); // way to rotate unity uses uller angles
        // lerp for quaterion to adjest the rotation for move between targets to be more smothed from part rotation to new rotation over a certain amount of time
    
        Vector3 rotation = Quaternion.Lerp(parttorotate.rotation,lookRotation,Time.deltaTime * turrentrotation_speed).eulerAngles; // convert the quaternion to the angles
        parttorotate.rotation = Quaternion.Euler(0f, rotation.y, 0f); //rotate only through the y direction

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate; // set cound to equal 1/ fire rate 
        }
        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        // set the clone bullet to a game object that we needed to cast
       GameObject bulletGo = (GameObject) Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); // gets the object in the bullet prefab and clones it at this position and rotation;
        Bullet bullet = bulletGo.GetComponent<Bullet>();
        bullet.attackdmg = turrentdmg; // create the bullet with 20 dmg for the default
        if (bullet != null)
            bullet.Seek(target); // call the to seek the target
    }
    /*
    private void OnMouseDown()
    {
        Debug.Log("turrent has been selected");
        buildManger.Selectturrent(this);
    }*/
    private void OnDrawGizmosSelected() // idea for the range of the turrents of that time .
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
