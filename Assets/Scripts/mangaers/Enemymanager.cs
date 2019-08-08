using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Enemymanager : MonoBehaviour
{
    public static Enemymanager instance;
    public Towerhealth playerHealth;
    public GameObject enemy; // ref to enemy we want to spawn
    public float spawnTime = 3f; // spawn time 
    public Transform[] spawnPoints;
    public int counter = 0;
    public static int enemyleft = 0;
    public int[] enemyperwave = new int[] { 10,25,30,40,50};
    public static bool buildphase = true;
    public int[] wave_reward = new int[] { 100, 150, 250, 300, 0 };
    public int[] enemy_health_increase = new int[] { 50, 100, 150, 250, 350 };
    public GameObject sub_enemy;
    public Enemyhealth sub_health;
    phasebutton phasemanager;
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
        phasemanager = phasebutton.phase_instance;
        // call spawn function with the time to start and wait to do it
    }
    public void change_phase()
    {
        if(buildphase)
        {
            buildphase = false;
            counter = enemyperwave[Wavesystem.wave_on];
            enemyleft = enemyperwave[Wavesystem.wave_on];
            phasemanager.Hide();
        }
        else
        {
            buildphase = true;
            phasemanager.Show();
        }
    }
    void Spawn()
    {
        if(counter <= 0 && enemyleft <= 0 && buildphase == false )
        {
            buildphase = true;
            Pointsystem.score += wave_reward[Wavesystem.wave_on];
            if (Wavesystem.wave_on < 4)
            {
                Wavesystem.wave_on++;
            }
            phasemanager.Show();
        }
        if (buildphase)
        {
            return;
        }
        if (playerHealth.currentHealth <= 0f || counter <= 0 )
        {
            return;
        }

        int spawnPointIndex = Random.Range(0, spawnPoints.Length); //spawnpoint index random mize the index

        sub_enemy = (GameObject)Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation); // (enemy,position and rotation)
        sub_health = sub_enemy.GetComponent<Enemyhealth>();
        sub_health.currentHealth = sub_health.currentHealth + enemy_health_increase[Wavesystem.wave_on];
        counter--;
    }
}
