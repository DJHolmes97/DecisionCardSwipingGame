using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheftScenario : Scenario
{
    //You let the robber steal things from you
    //You lose wealth every time
    override public bool CalculateLeftSuccess(StatsManager stats)
    {

        InitialiseStats();
        InitialiseLikely();
        SetWealthLikely();

        wealthEffect = NewStat(false, stats);
        return true;

    }

    //You decide to fight the robber
    //If you are succesfull you lose nothing
    //If you are not succesful you lose attack and wealth
    override public bool CalculateRightSuccess(StatsManager stats)
    {
        InitialiseStats();
        InitialiseLikely();
        SetAttackLikely();
        SetWealthLikely();
        if (RollDice(0, stats.getAttack()) > scenarioLevel){
            return true;
        } else
        {
            attackEffect = NewStat(false, stats);
            wealthEffect = NewStat(false, stats);
            return false;
        }
    }
}
