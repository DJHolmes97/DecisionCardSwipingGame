using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettlementScenario : Scenario
{
    //Where you decide to attack the settlement
    //If you are successful you gain attack and food
    //If you fail you lose health
    override public bool CalculateLeftSuccess(StatsManager stats)
    {
        InitialiseLikely();
        SetHealthLikely();
        SetAttackLikely();
        SetHungerLikely();

        if (RollDice(0, stats.getAttack()) > scenarioLevel)
        {
            InitialiseStats();
            attackEffect = NewStat(true, stats);
            hungerEffect = NewStat(true, stats);

            return true;
        }
        else
        {
            InitialiseStats();
            healthEffect = NewStat(false, stats);
            return false;
        }


    }

    //Where you decide to do a quest for the settlement
    //If you are successful you gain wealth
    //If you fail you lose health
    override public bool CalculateRightSuccess(StatsManager stats)
    {
        InitialiseLikely();
        SetHealthLikely();
        SetWealthLikely();
        if (RollDice(0,stats.getAttack()) > scenarioLevel)
        {
            InitialiseStats();
            wealthEffect = NewStat(true, stats);
            return true;
        }
        else
        {
            InitialiseStats();
            healthEffect = NewStat(false, stats);
            return false;
        }
    }
}
