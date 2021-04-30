using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Scenario
{
    protected List<CardSprite> sprites;

    protected List<string> dialogues;
    protected List<string> rightQuotes;
    protected List<string> leftQuotes;
    protected List<string> rightSuccessDialogues;
    protected List<string> rightFailDialogues;
    protected List<string> leftSuccessDialogues;
    protected List<string> leftFailDialogues;
    protected List<string> genericEndQuotes;
    protected int scenarioLevel;
    protected int basicScenarioDifficulty;

    protected int healthEffect;
    protected int attackEffect;
    protected int hungerEffect;
    protected int wealthEffect;

    private bool healthLikley;
    private bool hungerLikely;
    private bool attackLikely;
    private bool wealthLikely;

    public Scenario()
    {
        sprites = new List<CardSprite>();
        dialogues = new List<string>();
        rightQuotes = new List<string>();
        leftQuotes = new List<string>();
        rightSuccessDialogues = new List<string>();
        rightFailDialogues = new List<string>();
        leftSuccessDialogues = new List<string>();
        leftFailDialogues = new List<string>();
        genericEndQuotes = new List<string>();

        healthEffect = 0;
        attackEffect = 0;
        hungerEffect = 0;
        wealthEffect = 0;


    }

    public void AddSprite(CardSprite sprite)
    {
        sprites.Add(sprite);
    }

    //Returns a random sprite to be used by the scenario
    public CardSprite GetRandomSprite()
    {
        return sprites[RollDice(0, sprites.Count)];
    }

    public void AddDialogue(string str)
    {
        dialogues.Add(str);
    }

    public void AddLeftQuote(string str)
    {
        leftQuotes.Add(str);
    }

    public void AddRightQuote(string str)
    {
        rightQuotes.Add(str);
    }

    public void AddLeftSuccessDialogue(string str)
    {
        leftSuccessDialogues.Add(str);
    }

    public void AddRightSuccessDialogue(string str)
    {
        rightSuccessDialogues.Add(str);
    }

    public void AddLeftFailDialogues(string str)
    {
        leftFailDialogues.Add(str);
    }

    public void AddRightFailDialogues(string str)
    {
        rightFailDialogues.Add(str);
    }

    public void AddGenericEndQuotes(string str)
    {
        genericEndQuotes.Add(str);
    }

    //Gets a random dialogue to be used by the sprite
    public string GetRandomDialogue()
    {
      return dialogues[RollDice(0, dialogues.Count - 1)];
    }

    //Gets a random quote to be used on a left swipe
    public string GetRandomLeftQuote()
    {
        return leftQuotes[RollDice(0, leftQuotes.Count - 1)];
    }

    //Gets a random quote to be used on a right swipe
    public string GetRandomRightQuote()
    {
        return rightQuotes[RollDice(0, rightQuotes.Count - 1)];
    }

    //If the left swipe is successful it returns this random dialogue
    public string GetRandomLeftSuccessDialogue()
    {
        return leftSuccessDialogues[RollDice(0, leftSuccessDialogues.Count - 1)];
    }

    //If the right swipe is successful it returns this random dialogue
    public string GetRandomRightSuccessDialogue()
    {
        return rightSuccessDialogues[RollDice(0, rightSuccessDialogues.Count - 1)];
    }

    //If the left swipe is a failure then it returns this random dialogue
    public string GetRandomLeftFailDialogue()
    {
        return leftFailDialogues[RollDice(0, leftFailDialogues.Count - 1)];
    }

    //If the right swipe is a failure then it returns this random dialogue
    public string GetRandomRightFailDialogue()
    {
        return rightFailDialogues[RollDice(0, rightFailDialogues.Count - 1)];
    }

    //These are just generice quotes that can appear on a left or right swipe
    //They will appear at the end of a scenario rgardless of outcome
    public string GetRandomGenericEndQuotes()
    {
        return genericEndQuotes[RollDice(0, rightFailDialogues.Count - 1)];
    }

    //This returns the new change to the health stat
    public int GetHealthEffect()
    {
        return healthEffect;
    }

    //This returns the new change to the hunger stat
    public int GetHungerEffect()
    {
        return hungerEffect;
    }

    //This retruns the new change to the attack stat
    public int GetAttackEffect()
    {
        return attackEffect;
    }

    //This returns the new change to the wealth stat
    public int GetWealthEffect()
    {
        return wealthEffect;
    }


    //Basic Scenario Difficulty should be a value of between 3, 5 or 10
    public void SetScenarioLevel(int day)
    {
        scenarioLevel = basicScenarioDifficulty + RollDice(1 * day, 5 * day);
        if(scenarioLevel < 1)
        {
            scenarioLevel = 1;
        }

        if (scenarioLevel > 100)
        {
            scenarioLevel = 100;
        }
    }

    //This returns the level difficulty of the scenario
    //This effects many of the games factors
    public int GetScenarioLevel()
    {
        return scenarioLevel;
    }

    //This can only be a value of 3, 5 or 10
    public void SetBasicScenarioDifficulty(int diff)
    {
        basicScenarioDifficulty = diff;
    }

    //returns the difficulty of the Scenario
    public int getBasicScenarioDifficulty()
    {
        return basicScenarioDifficulty;
    }

    //Abstract method that works out whether a left swipe is successful
    public abstract bool CalculateLeftSuccess(StatsManager stats);

    //Abstract method that works out whether a right swipe is successful
    public abstract bool CalculateRightSuccess(StatsManager stats);

    //Method that returns a random number between a range
    protected int RollDice(int lowerRange, int upperRange)
    {
        return Random.Range(lowerRange, upperRange);
    }

    //Works out what the new stat is, value can be positive or negative depending on changeType
    protected int NewStat(bool changeType, StatsManager stats)
    {
        int val = RollDice(10, 20);
        val += stats.getDay();

        if(val > 30)
        {
            val = 30;
        }

        if (!changeType)
        {
            val *= -1;
            
        }
 
     

        return val;
        
    }

    //Initialises all the stats between scenarios
    protected void InitialiseStats()
    {
        healthEffect = 0;
        hungerEffect = 0;
        attackEffect = 0;
        wealthEffect = 0;
    }

    //Initialises the likely markers between scenarios
    public void InitialiseLikely()
    {
        healthLikley = false;
        hungerLikely = false;
        attackLikely = false;
        wealthLikely = false;
    }

    //Sets health marker to likely
    protected void SetHealthLikely()
    {
        healthLikley = true;
    }

    //Sets hunger marker to likely
    protected void SetHungerLikely()
    {
        hungerLikely = true;
    }

    //Sets attack marker to likely
    protected void SetAttackLikely()
    {
        attackLikely = true;
    }

    //Sets wealth marker to likely
    protected void SetWealthLikely()
    {
        wealthLikely = true;
    }

    
    public bool GetHealthLikely()
    {
        return healthLikley;
    }

    public bool GetHungerLikely()
    {
        return hungerLikely;
    }

    public bool GetAttackLikely()
    {
        return attackLikely;
    }

    public bool GetWealthLikely()
    {
        return wealthLikely;
    }



}
