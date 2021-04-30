using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraderScenario : Scenario
{
    //You try to sell resources to the trader
    //If you are successful you lose attack and gain wealth
    //If you fail nothing happens
    override public bool CalculateLeftSuccess(StatsManager stats)
    {
        InitialiseLikely();
        InitialiseStats();
        SetAttackLikely();
        SetWealthLikely();

        attackEffect = NewStat(false, stats);

        wealthEffect = NewStat(true, stats);

        if (stats.getAttack() + attackEffect > 0)
        {

            return true;
        } else
        {
            InitialiseStats();
            return false;
        }

    }

    //You try to buy resources from the trader
    //If you are successful you gain hunger and lose wealth
    //Otherwise nothing happens
    override public bool CalculateRightSuccess(StatsManager stats)
    {
        InitialiseLikely();
        InitialiseStats();
        SetWealthLikely();
        SetHungerLikely();

        wealthEffect = NewStat(false, stats);
        hungerEffect = NewStat(true, stats);
        if (stats.getWealth() + wealthEffect > 0)
        {

            return true;
        } else
        {
            InitialiseStats();
            return false;
        }
    }
}
