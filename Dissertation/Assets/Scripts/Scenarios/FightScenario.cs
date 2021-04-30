using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FightScenario : Scenario
{
   //attempt to run away from the fight
   //If you fail to escaape you lose health
   //Otherwise nothing happens
   override public bool CalculateLeftSuccess(StatsManager stats)
    {
        InitialiseLikely();
        InitialiseStats();
        SetHealthLikely();

        if (RollDice(0, stats.getHealth() * 2) > scenarioLevel)
        {
            return true;
        } else
        {
            healthEffect = NewStat(false, stats);
            return false;
        }
        
        

    }

    //decide to fight
    //If you fail you lose health
    //Otherwise you gain wealth and attack
    override public bool CalculateRightSuccess(StatsManager stats)
    {
        InitialiseLikely();
        SetHealthLikely();
        SetAttackLikely();
        SetWealthLikely();
        if(RollDice(0, stats.getAttack()) > scenarioLevel)
        {
            InitialiseStats();
            wealthEffect = NewStat(true, stats);
            attackEffect = NewStat(true, stats);
            return true;
        } else
        {
            InitialiseStats();
            healthEffect = NewStat(false, stats);
            return false;
        }
    }


}
