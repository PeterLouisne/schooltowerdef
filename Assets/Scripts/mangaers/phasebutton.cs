using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phasebutton : MonoBehaviour
{
    public static phasebutton phase_instance;
    public GameObject ui;
    // Start is called before the first frame update
    void Awake()
    {
        if (phase_instance != null)
        {
            Debug.LogError("more than one phase manager");
            return;
        }
        phase_instance = this; // the static variable will equal this. so that each node doesn't need to contain it own build manager
    }
    void Start()
    {
        ui.SetActive(true);
    }
    public void Hide()
    {
        ui.SetActive(false); // hides the ui
    }
    public void Show()
    {
        ui.SetActive(true); // hides the ui
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
