using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Node : MonoBehaviour
{   // keeps track if we have something built overthat node and visually to build on it 
    // Start is called before the first frame update
    public Color hoverColor;
    public Color SelectedColor;
    public Vector3 positionoffset; // offset the position of the things being spawned
    public GameObject turrent;// type of object that can't put aka shop items

    public Renderer rend;
    public Color Startcolor;
    BuildManager buildManger;
    
    public string clicktag = "Clicker";
    public static Button buildbutton; // the build button shared with all nodes
    void Start()
    {
        rend = GetComponent<Renderer>();
        Startcolor = rend.material.color;
        buildManger = BuildManager.instance;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == clicktag)
        {
            if (turrent != null)
            {
                buildManger.changenodes(this);
                buildManger.Selectdefensehealth(turrent.GetComponent<Defensehealth>());
                return;
            }
            if (buildManger.GetTurrentToBuild() == null) // help stop if there will be an error so most select if you want to build
                return;
            else
            {
                if (turrent == null)
                    buildManger.selectbuildarea(this);
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
       /* if (other.gameObject.tag == clicktag)
        {
            if (turrent == null)
                rend.material.color = Startcolor;
        }*/
        
    }

    private void OnMouseDown()
    {
        if(turrent != null)
        {
            buildManger.Selectdefensehealth(turrent.GetComponent<Defensehealth>());
            return;
        }

        if (buildManger.GetTurrentToBuild() == null) // help stop if there will be an error so most select if you want to build
            return;

        //build a turrent
        GameObject turrenttobuild = buildManger.GetTurrentToBuild();
        int cost_to_build = buildManger.GetBuild_cost();
        //turrent = (GameObject)Instantiate(turrenttobuild, transform.position + positionoffset, transform.rotation);
        if (Pointsystem.score >= cost_to_build)
        {
            turrent = (GameObject)Instantiate(turrenttobuild, transform.position + positionoffset, turrenttobuild.transform.rotation);
            Pointsystem.score -= cost_to_build;
        }
    }
    void OnMouseEnter() // everytime the mouse passes by the collider and only once and change the color of the object
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (buildManger.GetTurrentToBuild() == null) // help stop if there will be an error so most select if you want to build
            return;
        rend.material.color = hoverColor;
    }
    void OnMouseExit()
    {
        rend.material.color = Startcolor;
    }
}
