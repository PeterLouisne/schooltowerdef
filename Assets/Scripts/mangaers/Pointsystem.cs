using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pointsystem : MonoBehaviour
{
    public static int score; // static belongs to all instance of scoremangaer so all score mangers share same score use it thorugh type it self exist in one space


    Text text;


    void Awake()
    {
        text = GetComponent<Text>();  // getting the text component
        score = 500;
    }


    void Update()
    {
        text.text = "Points: " + score; // set the score to the new score
    }
}