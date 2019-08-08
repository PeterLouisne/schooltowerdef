using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defensehealth : MonoBehaviour
{ // the health for the defense models
    public int startingHealth = 100;
    public int currentHealth;
    public int upgrade_cost = 100;

    public int upgrade_max = 2;
    public int upgrade_health_increase = 50;
    public int upgrade_count = 0;
    bool isDead;
    bool damaged;
    BuildManager buildManger;
    // Start is called before the first frame update
    private void Awake()
    {
        currentHealth = startingHealth;
        buildManger = BuildManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            Destroy(gameObject);
            return;
        }
    }

    public void TakeDamage(int amount)// called in other script reason it is public// amount is amount damegeing to player
    {
        damaged = true;

        currentHealth -= amount;

        if (currentHealth <= 0 && !isDead) // if health less than zero and not dead
        {
            Death();
        }
    }
    private void OnMouseDown()
    {
        Debug.Log("wall has been selected");
        buildManger.Selectdefensehealth(this);
    }
    void Death()
    {
        isDead = true;
    }
}
