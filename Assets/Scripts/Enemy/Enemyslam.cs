using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyslam : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;
    public string killableTag = "Defense"; // all the defenseitems with tag
    GameObject player;
    Towerhealth towerhp; // enemy ref to player health script or class
    Enemyhealth enemyHealth; // has to exist on the enmey
    Defensehealth defhealth; // health of the defense person
    bool playerInRange; // see range for enemy to attack player
    bool attackInRange;
    float timer; // timing for the attack so not fast

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        towerhp = player.GetComponent<Towerhealth>();
        enemyHealth = GetComponent<Enemyhealth>(); // get info from attack component
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player) // calls if trigger collider colides with player
        {
            playerInRange = true;
        }
        if (other.gameObject.tag == killableTag) // calls if trigger collider colides with player
        {
            attackInRange = true;
            defhealth = other.gameObject.GetComponent<Defensehealth>();
            //Debug.Log("killableobject has enter the field");
        }
    }
    

    void OnTriggerExit(Collider other) // 
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }

        if (other.gameObject.tag == killableTag) // calls if trigger collider colides with player
        {
            attackInRange = false;
           // Debug.Log("killableobjectleft");
        }
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
            Attacktower(); // if timer is greater than time between attacks attack and player in range and health is greater than 0
        }
        else
        {
            if (timer >= timeBetweenAttacks && attackInRange && defhealth.currentHealth > 0)
            {
                Attackobject(); // if timer is greater than time between attacks attack and player in range and health is greater than 0
            }
        }
        
    }
    void Attackobject()
    {
        timer = 0f; // reset timer

        if (defhealth.currentHealth > 0) // call playerhealth takedamge
        {
            defhealth.TakeDamage(attackDamage);
        }
    }
    void Attacktower()
    {
        timer = 0f; // reset timer

        if (towerhp.currentHealth > 0) // call playerhealth takedamge
        {
            towerhp.TakeDamage(attackDamage);
        }
    }


}
