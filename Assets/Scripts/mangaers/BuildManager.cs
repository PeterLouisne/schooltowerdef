using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    // make it only one build manager and easy to ref
    public static BuildManager instance; // stores the build manager in the manager so can ref it self

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("more than one build manager");
            return;
        }
        instance = this; // the static variable will equal this. so that each node doesn't need to contain it own build manager
        
    }
    public GameObject turrentmk2prefab;
    public GameObject bulletturrentprefab;
    public GameObject Slowturrentprefab;
    public GameObject Horizontalwallprefab;
    public GameObject Verticalwallprefab;
    public NodeUI nodeui;
    // Start is called before the first frame update

    private GameObject TurrentToBuild; // equal to nothing until we determine what turrent we want to build

    private Node selectedNode = null;
    private Node selectbuildnode = null;
    private Turrent selectedturrent;
    private Defensehealth selectedDef;
    private int build_cost;

    public GameObject GetTurrentToBuild()
    {
        return TurrentToBuild;
    }
    public int GetBuild_cost()
    {
        return build_cost;
    }
    public void setuioff()
    {
        nodeui.Hide();
    }
    public void changenodes(Node target_node)
    {
        if (selectedNode != null)
        {
            selectedNode.rend.material.color = selectedNode.Startcolor;
            selectedNode = target_node;
            selectedNode.rend.material.color = selectedNode.SelectedColor;
        }
        else
        {
            selectedNode = target_node;
            selectedNode.rend.material.color = selectedNode.SelectedColor;
        }
    }
    public void selectbuildarea(Node target_node)
    {
        if (selectbuildnode != null)
        {
            selectbuildnode.rend.material.color = selectbuildnode.Startcolor;
            selectbuildnode = target_node;
            selectbuildnode.rend.material.color = selectbuildnode.hoverColor;
        }
        else
        {
            selectbuildnode = target_node;
            selectbuildnode.rend.material.color = selectbuildnode.hoverColor;
        }
    }
    public void build_here()
    {
        if (GetTurrentToBuild() == null) // help stop if there will be an error so most select if you want to build
            return;

        //build a turrent
        GameObject turrenttobuild = GetTurrentToBuild();
        int cost_to_build = GetBuild_cost();
        //turrent = (GameObject)Instantiate(turrenttobuild, transform.position + positionoffset, transform.rotation);
        if (Pointsystem.score >= cost_to_build)
        {
            selectbuildnode.turrent = (GameObject)Instantiate(turrenttobuild, selectbuildnode.transform.position + selectbuildnode.positionoffset, turrenttobuild.transform.rotation);
            Pointsystem.score -= cost_to_build;
        }
        //selectbuildnode = null;
        return;
    }
    public void Selectdefensehealth(Defensehealth target_defense)
    {
        selectedDef = target_defense;
        nodeui.SetDef(selectedDef);
        //TurrentToBuild = null;
    }
    public void SetTurrenttobuild(GameObject turrent, int to_build)
    {
        TurrentToBuild = turrent;
        build_cost = to_build;
        //selectedturrent = null;
        //selectedDef = null;
        nodeui.Hide();
    }
}
