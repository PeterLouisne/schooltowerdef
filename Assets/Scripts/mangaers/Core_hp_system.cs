using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Core_hp_system : MonoBehaviour
{ // static belongs to all instance of scoremangaer so all score mangers share same score use it thorugh type it self exist in one space

    public Towerhealth Core_hp;
    Text text;


    void Awake()
    {
        text = GetComponent<Text>();  // getting the text component
    }


    void Update()
    {
        text.text = "core_Hp: " + Core_hp.currentHealth; // set the score to the new score
    }
}
