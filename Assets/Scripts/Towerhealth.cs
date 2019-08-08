using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Towerhealth : MonoBehaviour
{ // health of most important subject
    public int startingHealth = 100;
    public int currentHealth;
   // public Slider healthSlider;
    bool isDead;
    bool damaged;
    // Start is called before the first frame update
    private void Awake()
    {
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            Destroy(gameObject);
            return;
        }
        /*
        if (damaged)
        {
            damageImage.color = flashColour; // if damage set image to flash color
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime); // if not damaged fade it back to transparaent(current color, color like to change, speed takes to change)
        }
        damaged = false;*/
    }

    public void TakeDamage(int amount)// called in other script reason it is public// amount is amount damegeing to player
    {
        damaged = true;

        currentHealth -= amount;

        //healthSlider.value = currentHealth;

        //playerAudio.Play();

        if (currentHealth <= 0 && !isDead) // if health less than zero and not dead
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;

        //playerShooting.DisableEffects(); // shooting effect is also disable
    }


    public void RestartLevel()
    {
        Enemymanager.buildphase = true;
        SceneManager.LoadScene(0);
    }
}
