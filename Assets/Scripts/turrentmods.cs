using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turrentmods : MonoBehaviour
{
    BuildManager buildManager;
    public int horizontal_wall_cost = 0;
    public int vertical_wall_cost = 0;
    void Start()
    {
        buildManager = BuildManager.instance;
    }

}
