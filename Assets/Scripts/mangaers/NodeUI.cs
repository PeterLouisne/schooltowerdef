using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    private Turrent target_turrent;
    private Defensehealth target_defense;
    private GameObject selected_object;
    public void SetDef(Defensehealth one_Def)
    {
        target_defense = one_Def;

       // transform.position = target_defense.transform.position;
        ui.SetActive(true);
    }
    void Start()
    {
        Hide();
    }
    public void Hide()
    {
        ui.SetActive(false); // hides the ui
    }
    public void upgradesentry()
    {if (Pointsystem.score >= target_defense.upgrade_cost)
        {
            if (target_defense.upgrade_count < target_defense.upgrade_max)
            {
                target_defense.upgrade_count++;
                target_defense.currentHealth = target_defense.startingHealth + target_defense.upgrade_health_increase * target_defense.upgrade_count;
                if (target_defense.gameObject.GetComponent<Turrent>())
                {
                    target_turrent = target_defense.gameObject.GetComponent<Turrent>();
                    target_turrent.turrentdmg += target_turrent.upgrade_dmg;
                }
                Pointsystem.score -= target_defense.upgrade_cost;

            }
        }
    }
    public void sell_item()
    {
        Pointsystem.score += target_defense.upgrade_cost * target_defense.upgrade_count + target_defense.currentHealth / 2;
        Destroy(target_defense.gameObject);
        
    }
}
