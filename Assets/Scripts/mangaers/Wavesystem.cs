using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wavesystem : MonoBehaviour
{
    public static int wave_on; // static belongs to all instance of scoremangaer so all score mangers share same score use it thorugh type it self exist in one space


    Text text;


    void Awake()
    {
        text = GetComponent<Text>();  // getting the text component
        wave_on = 0; ;
    }


    void Update()
    {
        text.text = "Wave " + (wave_on + 1) + "/5"; // set the score to the new score
    }
}
