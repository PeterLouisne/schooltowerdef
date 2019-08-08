using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyhealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public int scoreValue = 10;// put a score in the game from character
                               // Start is called before the first frame update
                               //CapsuleCollider capsuleCollider;
    BoxCollider boxcolide;
    bool isDead;
    //Enemymanager enemymanager;
    void Awake()
    {
        //capsuleCollider = GetComponent<CapsuleCollider>(); // get the collider that is a capsul collider
        // don't need to get the sphere collider since it is the trigger collider
        boxcolide = GetComponent<BoxCollider>();
        currentHealth = startingHealth;
        //enemymanager = Enemymanager.instance;
    }

    public void TakeDamage(int amount)  // how much damge it get hit and where for the partical effect
    {
        if (isDead)
            return; // if dead just exit

        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Death();
        }
    }


    void Death()
    {
        isDead = true;

        //capsuleCollider.isTrigger = true; // set collider to trigger and since you can't hit triggers the dead body won't become obstacle
        boxcolide.isTrigger = true;
        //anim.SetTrigger("Dead"); // dead animation and play the death clip 
        // in the dead animation for the bunny giving it calls the start sinking function for own game may not be doing this and just play is normaly
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            Pointsystem.score += scoreValue;
            Enemymanager.enemyleft--;
            Destroy(gameObject);
            return;
        }
    }
}
