using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laserturrent : MonoBehaviour
{
    public Transform target; // target to shoot;
    public string enemyTag = "Enemy";
    public float turrentrotation_speed = 10f;
    public Transform parttorotate;

    // May things about turrent
    [Header("turrent attributes")]
    public float range = 50f; // range of the turrents
    public float fireRate = 1f;
    private float fireCountdown = 0f; // time inbetween shooting like fix update but no
    public int turrentdmg = 50;
    public int points_to_build = 100;
    BuildManager buildManger;
    public GameObject bulletPrefab; // what the bullet looks like
    public Transform firePoint; // poistion of where the bullet is spawned
    RaycastHit shootHit;
    int shootableMask;
    Ray shootRay = new Ray();
    LineRenderer gunLine;
    Light gunLight;
    public GameObject holder;
    public int upgrade_dmg = 30;
    void Start()
    {
        shootableMask = LayerMask.GetMask("shootable");
        InvokeRepeating("UpdateTarget", 0f, .5f);
        buildManger = BuildManager.instance;
        gunLine = holder.GetComponent<LineRenderer>();
        gunLight = holder.GetComponent<Light>();
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
        else
        {
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

        Vector3 rotation = Quaternion.Lerp(parttorotate.rotation, lookRotation, Time.deltaTime * turrentrotation_speed).eulerAngles; // convert the quaternion to the angles
        parttorotate.rotation = Quaternion.Euler(0f, rotation.y, 0f); //rotate only through the y direction

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate; // set cound to equal 1/ fire rate 
        }
        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {/*
        gunLine.enabled = true; //turn on the line render aka the bullet 
        // first end of line barrel of the gun aka end of the gun where the first position is 
        gunLine.SetPosition(0, transform.position);

        // foward in z axis as foward  away from player direction
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask)) // raycast function (pass ray, pass return of what we hit,range,shootable mask and only hit things we can))
        {
            Enemyhealth enemyHealth = shootHit.collider.GetComponent<Enemyhealth>(); // if we hit something save the enemyhealth script of the object we hit
            if (enemyHealth != null) // if it was null than it wasn't an enemy so we did nothing. we can do it for different things.
            {
                enemyHealth.TakeDamage(turrentdmg); // shoothit.point is point we hit
            }
            gunLine.SetPosition(1, shootHit.point); // no matter what we hit we got the line
        }
        else
        {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range); // if we didnot hit something where ray starts + direction * range
        }*/

         // set the clone bullet to a game object that we needed to cast
         GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); // gets the object in the bullet prefab and clones it at this position and rotation;
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
