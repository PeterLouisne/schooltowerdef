using UnityEngine;

public class Defshop : MonoBehaviour
{
    BuildManager buildManager;
    public int horizontal_wall_cost = 0;
    public int vertical_wall_cost = 0;
    void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void purchasehorizontalwall()
    {
        Debug.Log("standard Turrent purchased");
        buildManager.SetTurrenttobuild(buildManager.Horizontalwallprefab,horizontal_wall_cost); // won't need to keep adding varaibles could also use arrays
    }

    public void purchaseverticalwall()
    {
        //Debug.Log("other Turrent has been purchased");
        buildManager.SetTurrenttobuild(buildManager.Verticalwallprefab,vertical_wall_cost);
    }
}
