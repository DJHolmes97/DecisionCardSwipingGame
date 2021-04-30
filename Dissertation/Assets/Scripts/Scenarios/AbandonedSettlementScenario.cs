using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbandonedSettlementScenario : Scenario
{
    //You walk away from the spooky looking settlement
    //Always successful
    override public bool CalculateLeftSuccess(StatsManager stats)
    {
        InitialiseLikely();
        InitialiseStats();
        return true;

    }

    //The player searches the settlement for resources
    //If they are successful they may gain wealth and weapons
    //If they fail they will lose health
    override public bool CalculateRightSuccess(StatsManager stats)
    {
        InitialiseLikely();
        InitialiseStats();
        SetHealthLikely();
        SetAttackLikely();
        SetWealthLikely();
        if(RollDice(0,100) > scenarioLevel)
        {
            healthEffect = NewStat(false, stats);
            return false;
        } else
        {
            wealthEffect = NewStat(true, stats);
            attackEffect = NewStat(true, stats);
            return true;
        }
    }
}
