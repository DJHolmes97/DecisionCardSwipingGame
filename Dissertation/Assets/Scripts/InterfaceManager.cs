using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This class was originally taken from this tutorial: https://www.youtube.com/watch?v=gs3kNq89Ym4
//but it has been changed significantly, i will note any pieces of code that have stayed the same.
public class InterfaceManager : MonoBehaviour
{

    [SerializeField]
    private Image health;
    [SerializeField]
    private Image attack;
    [SerializeField]
    private Image hunger;
    [SerializeField]
    private Image wealth;

    [SerializeField]
    private Image healthImpact;
    [SerializeField]
    private Image attackImpact;
    [SerializeField]
    private Image hungerImpact;
    [SerializeField]
    private Image wealthImpact;

    //This code is mostly taken from the above mentioned Youtube tutorial
    //I have made significant changes but the style mostly stayed the same
    public void SetFillAmounts(string direction, StatsManager stats, Scenario currentScenario)
    {
        health.fillAmount = stats.getHealthLevel();
        attack.fillAmount = stats.getAttackLevel();
        hunger.fillAmount = stats.getHungerLevel();
        wealth.fillAmount = stats.getWealthLevel();

        if (direction == "right" || direction == "left")
        {
            if (currentScenario.GetHealthLikely())
            {
                healthImpact.transform.localScale = new Vector3(1, 1, 0);
            }

            if (currentScenario.GetAttackLikely())
            {
                attackImpact.transform.localScale = new Vector3(1, 1, 0);
            }

            if (currentScenario.GetHungerLikely())
            {
                hungerImpact.transform.localScale = new Vector3(1, 1, 0);
            }

            if (currentScenario.GetWealthLikely())
            {
                wealthImpact.transform.localScale = new Vector3(1, 1, 0);
            }
        }

        else
        {

            healthImpact.transform.localScale = new Vector3(0, 0, 0);
            attackImpact.transform.localScale = new Vector3(0, 0, 0);
            hungerImpact.transform.localScale = new Vector3(0, 0, 0);
            wealthImpact.transform.localScale = new Vector3(0, 0, 0);



        }
    }



}
