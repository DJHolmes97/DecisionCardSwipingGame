using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    //Player Stat Effects
    [SerializeField] private int health;
    [SerializeField] private int day;
    [SerializeField] private int attack;
    [SerializeField] private int hunger;
    [SerializeField] private int wealth;
    [SerializeField] private static int maxValue;
    [SerializeField] private static int minValue;

    [SerializeField] private float healthLevel;
    [SerializeField] private float attackLevel;
    [SerializeField] private float hungerLevel;
    [SerializeField] private float wealthLevel;

    private void Start()
    {
        health = 100;
        day = 1;
        attack = 20;
        hunger = 100;
        wealth = 20;
        maxValue = 100;
        minValue = 0;
    }

    private void Update()
    {
        healthLevel = StatUpdate(health);
        attackLevel = StatUpdate(attack);
        hungerLevel = StatUpdate(hunger);
        wealthLevel = StatUpdate(wealth);
    }

    public float StatUpdate(int stat)
    {
        return 1 - (float)stat / maxValue;
    }

    public float getHealthLevel()
    {
        return healthLevel;
    }

    public int getDay()
    {
        return day;
    }

    public float getAttackLevel()
    {
        return attackLevel;
    }

    public float getHungerLevel()
    {
        return hungerLevel;
    }

    public float getWealthLevel()
    {
        return wealthLevel;
    }

    public int getHealth()
    {
        return health;
    }

    public int getAttack()
    {
        return attack;
    }
    public int getHunger()
    {
        return hunger;
    }

    public int getWealth()
    {
        return wealth;
    }

    public void changeHealth(int newHealth)
    {
        health += newHealth;
        if(health > maxValue)
        {
            health = maxValue;
        } else if(health < minValue)
        {
            health = minValue;
        }
    }

    public void nextDay()
    {
        day++;
        hunger -= 20;
        if (hunger < 1)
        {
            hunger = 0;
            health -= 20;
        } else if (hunger > 70)
        {
            health += 20;
        }
    }

    public void changeAttack(int newAttack)
    {
        attack += newAttack;

        if(attack > maxValue)
        {
            attack = maxValue;
        } else if(attack < minValue)
        {
            attack = minValue;
        }
    }

    public void changeHunger(int newHunger)
    {
        hunger += newHunger;

        if(hunger > maxValue)
        {
            hunger = maxValue;
        } else if(hunger < minValue)
        {
            hunger = minValue;
        }
    }

    public void changeWealth(int newWealth)
    {
        wealth += newWealth;

        if(wealth > maxValue)
        {
            wealth = maxValue;
        } else if(wealth < minValue)
        {
            wealth = minValue;
        }
    }

}
