using UnityEngine;
using UnityEngine.SceneManagement;
public class Gameovermanager : MonoBehaviour
{
    public Towerhealth playerHealth;
    public float restartDelay = 5f;

    //Animator anim;
    float restartTimer;

    void Awake()
    {
        //anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            //anim.SetTrigger("GameOver");

            restartTimer += Time.deltaTime;

            if (restartTimer >= restartDelay)
            {
                //Application.LoadLevel(Application.loadedLevel); // loading exact same scene can use this or Application.LoadLevel("level01"); name of scene
                SceneManager.LoadScene("Level1");
            }
        }
    }
}