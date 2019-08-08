using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    public int bullet_turrent_cost = 0; // cost to build the turrent
    public int laser_turrent_cost = 0;
    public int slow_turrent_cost = 0;
    void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void PurchasebulletTurrent()
    {
        Debug.Log("standard Turrent purchased");
        buildManager.SetTurrenttobuild(buildManager.bulletturrentprefab,bullet_turrent_cost); // won't need to keep adding varaibles could also use arrays
    }
    public void PurchaseTurrentmk2()
    {
        Debug.Log("Turrentmk2 purchased");
        buildManager.SetTurrenttobuild(buildManager.turrentmk2prefab, laser_turrent_cost); // won't need to keep adding varaibles could also use arrays
    }
    public void PurchaseSlow()
    {
        Debug.Log("slow purchased");
        buildManager.SetTurrenttobuild(buildManager.Slowturrentprefab, slow_turrent_cost); // won't need to keep adding varaibles could also use arrays
    }

}
