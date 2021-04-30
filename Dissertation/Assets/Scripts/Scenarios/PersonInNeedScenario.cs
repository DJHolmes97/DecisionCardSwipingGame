using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonInNeedScenario : Scenario
{
    //Where the user decides not to help the person
    //Always successful
    override public bool CalculateLeftSuccess(StatsManager stats)
    {
        InitialiseStats();
        InitialiseLikely();
        return true;


    }

    //Where the user decides to help the person
    //Can only do it if you have food to give
    //Otherwise nothing happens.
    override public bool CalculateRightSuccess(StatsManager stats)
    {
        InitialiseStats();
        InitialiseLikely();
        SetHungerLikely();

        hungerEffect = NewStat(false, stats);

        if (stats.getHunger() + hungerEffect > 0)
        { 
            return true;
        } else
        {
            InitialiseStats();
            return false;
        }

    }
}
