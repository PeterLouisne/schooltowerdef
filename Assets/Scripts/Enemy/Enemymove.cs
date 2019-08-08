using UnityEngine;
using System.Collections;

public class Enemymove : MonoBehaviour
{
    Transform player; // what the enemy will move towards
    Towerhealth towerhp;
    Enemyhealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;
    public bool slowed = false;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // on awake of game set target to player
        towerhp = player.GetComponent<Towerhealth>();
        enemyHealth = GetComponent<Enemyhealth>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>(); // set the nav
    }


    void Update() //  not keeping on time with physics so set to update if up with physics fixupdate
    {
        if (enemyHealth.currentHealth > 0 && towerhp.currentHealth > 0)
        {
            nav.SetDestination(player.position); // set the direction towards 
        }
        else
        {
            nav.enabled = false;
        }
    }
}