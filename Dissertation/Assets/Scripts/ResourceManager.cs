using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class was originally taken from this tutorial: https://www.youtube.com/watch?v=gs3kNq89Ym4
//but it has been changed significantly, i will note any pieces of code that have stayed the same.
public class ResourceManager: MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private List<Scenario> scenarios = new List<Scenario>();

    public void populateScenarios()
    {
        FightScenario psycho1 = new FightScenario();
        psycho1.SetBasicScenarioDifficulty(5);
        psycho1.AddSprite(CardSprite.PSYCHO1);
        psycho1.AddSprite(CardSprite.PSYCHO2);
        psycho1.AddSprite(CardSprite.PSYCHO3);

        psycho1.AddDialogue("You were attacked by a raider!");
        psycho1.AddDialogue("A crazy looking person is running towards you!");
        psycho1.AddDialogue("Someone with whacky face paint approaches!");

        psycho1.AddLeftQuote("Ahh they are crazy, run! (Run Away)");
        psycho1.AddLeftQuote("Nope, i'm out! (Run Away)");
        psycho1.AddLeftQuote("Absolutely not! (Run Away)");

        psycho1.AddRightQuote("Try to kick them in the groin (Attack)");
        psycho1.AddRightQuote("Try to laserbeam their head off (Attack)");
        psycho1.AddRightQuote("Attempt a flying jump kick (Attack)");

        psycho1.AddLeftSuccessDialogue("You just managed to escape.");
        psycho1.AddLeftSuccessDialogue("You ran so hard your legs nearly fell off");
        psycho1.AddLeftSuccessDialogue("You hopped, skipped and jumped out of there");

        psycho1.AddLeftFailDialogues("You almost escaped...");
        psycho1.AddLeftFailDialogues("You got shot in the back trying to run.");
        psycho1.AddLeftFailDialogues("You must of forgotten you are terrible at running");

        psycho1.AddRightSuccessDialogue("You managed to overcome your enemy");
        psycho1.AddRightSuccessDialogue("You hit them so hard their legs fell off");
        psycho1.AddRightSuccessDialogue("Boom, someone sniped them... ummm... I should move");

        psycho1.AddRightFailDialogues("There was no chance of you winning...loser");
        psycho1.AddRightFailDialogues("You got absolutely pummeled");
        psycho1.AddRightFailDialogues("BOOM. Ouch they had a shotgun");

        psycho1.AddGenericEndQuotes("Great.");
        psycho1.AddGenericEndQuotes("Ok.");
        psycho1.AddGenericEndQuotes("Couldn't have gone better.");

        scenarios.Add(psycho1);

        PersonInNeedScenario beggar = new PersonInNeedScenario();
        beggar.SetBasicScenarioDifficulty(2);
        beggar.AddSprite(CardSprite.PEASANT1);
        beggar.AddSprite(CardSprite.PEASANT2);
        beggar.AddSprite(CardSprite.PEASANT3);
        beggar.AddSprite(CardSprite.PEASANT4);
        beggar.AddSprite(CardSprite.PEASANT5);
        beggar.AddSprite(CardSprite.PEASANT6);


        beggar.AddDialogue("You come across a weak looking beggar");
        beggar.AddDialogue("You find someone dying in the road, they have been attacked");
        beggar.AddDialogue("As you are walking you trip on something, oops it's a person");

        beggar.AddLeftQuote("Leave the person to die (Leave)");
        beggar.AddLeftQuote("Walk away as if you didn't see them (Leave)");
        beggar.AddLeftQuote("Ew they smell awful, better get out of here (Leave)");

        beggar.AddRightQuote("Try to help them (Give Resources)");
        beggar.AddRightQuote("Fine. Guess I will be good (Give Resources)");
        beggar.AddRightQuote("Maybe they will pay me if I help. (Give Resources)");

        beggar.AddLeftSuccessDialogue("You walked away");
        beggar.AddLeftSuccessDialogue("You managed to leave just before they noticed you");
        beggar.AddLeftSuccessDialogue("You left before it became your problem");

        beggar.AddRightFailDialogues("You had nothing to give");
        beggar.AddRightFailDialogues("You couldn't even save them");
        beggar.AddRightFailDialogues("They died right in front of you");

        beggar.AddLeftFailDialogues("This literally shouldn't be possibe (Error)");

        beggar.AddRightSuccessDialogue("You managed to save them");
        beggar.AddRightSuccessDialogue("You gave what you had to help");
        beggar.AddRightSuccessDialogue("I guess you helped...");

        beggar.AddGenericEndQuotes("Great.");
        beggar.AddGenericEndQuotes("Ok.");
        beggar.AddGenericEndQuotes("Couldn't have gone better.");

        scenarios.Add(beggar);

        AbandonedSettlementScenario emptySettlement = new AbandonedSettlementScenario();
        emptySettlement.SetBasicScenarioDifficulty(5);
        emptySettlement.AddSprite(CardSprite.ABANDONED1);
        emptySettlement.AddSprite(CardSprite.ABANDONED2);
        emptySettlement.AddSprite(CardSprite.ABANDONED3);

        emptySettlement.AddDialogue("You come across a settlement, it looks empty.");
        emptySettlement.AddDialogue("You stumble into an empty settlement.");
        emptySettlement.AddDialogue("Woah this area has been destroyed, wonder if anyones here?");

        emptySettlement.AddLeftQuote("Just walk away it looks dangerous (leave)");
        emptySettlement.AddLeftQuote("Leave before something gets you (leave)");
        emptySettlement.AddLeftQuote("It's definitely time to move on (leave)");

        emptySettlement.AddRightQuote("Search for some loot (Loot)");
        emptySettlement.AddRightQuote("You bet theres some good stuff here (Loot)");
        emptySettlement.AddRightQuote("I need resources (Loot)");

        emptySettlement.AddLeftSuccessDialogue("You leave before raiders find you.");
        emptySettlement.AddLeftSuccessDialogue("You leave before you get eaten by giant bugs or something");
        emptySettlement.AddLeftSuccessDialogue("The risk definitely didn't seem worth it");

        emptySettlement.AddRightSuccessDialogue("You managed to find some good loot!");
        emptySettlement.AddRightSuccessDialogue("You took anything you could find.");
        emptySettlement.AddRightSuccessDialogue("You found a load of crap.");

        emptySettlement.AddRightFailDialogues("You got attacked by a band of raiders");
        emptySettlement.AddRightFailDialogues("You were ambushed by a bunch of giant scorpions");
        emptySettlement.AddRightFailDialogues("You tripped whilst searching and smacked your head");

        emptySettlement.AddLeftFailDialogues("This shouldn't have happened (Error)");


        emptySettlement.AddGenericEndQuotes("Great.");
        emptySettlement.AddGenericEndQuotes("Ok.");
        emptySettlement.AddGenericEndQuotes("Couldn't have gone better.");

        scenarios.Add(emptySettlement);

        SettlementScenario settlement = new SettlementScenario();
        settlement.SetBasicScenarioDifficulty(5);
        settlement.AddSprite(CardSprite.SETTLEMENT1);
        settlement.AddSprite(CardSprite.SETTLEMENT2);
        settlement.AddSprite(CardSprite.SETTLEMENT3);


        settlement.AddDialogue("You come across a bustling settlement.");
        settlement.AddDialogue("You go to the local trading post");
        settlement.AddDialogue("Damn this settlement has people in it.");

        settlement.AddLeftQuote("You decide to kill them all and take their stuff.");
        settlement.AddLeftQuote("You decide that you need the stuff they have");
        settlement.AddLeftQuote("Hmmm, I haven't killed in a while...");

        settlement.AddRightQuote("I guess I could sort some problems out for these people");
        settlement.AddRightQuote("Sure, I will sort your giant scorpion infestation");
        settlement.AddRightQuote("This sounds like a job for super me!");

        settlement.AddLeftSuccessDialogue("You killed the entire settlement and took their stuff");
        settlement.AddLeftSuccessDialogue("You killed everyone you psycho.");
        settlement.AddLeftSuccessDialogue("You ran round screaming whilst chopping heads off.");

        settlement.AddRightSuccessDialogue("You managed to complete the job with ease");
        settlement.AddRightSuccessDialogue("You did that thing they asked you to");
        settlement.AddRightSuccessDialogue("You did it but eh... not very well");

        settlement.AddRightFailDialogues("You got your ass kicked.");
        settlement.AddRightFailDialogues("You failed the quest and failed to help.");
        settlement.AddRightFailDialogues("Better luck next time.");

        settlement.AddLeftFailDialogues("You got overhwelmed by the settlement.");
        settlement.AddLeftFailDialogues("They absolutely destroyed you.");
        settlement.AddLeftFailDialogues("You didn't stand a chance.");

        settlement.AddGenericEndQuotes("Great.");
        settlement.AddGenericEndQuotes("Ok.");
        settlement.AddGenericEndQuotes("Couldn't have gone better.");

        scenarios.Add(settlement);

        TraderScenario trader = new TraderScenario();
        trader.SetBasicScenarioDifficulty(5);
        trader.AddSprite(CardSprite.TRADER1);
        trader.AddSprite(CardSprite.TRADER2);
        trader.AddSprite(CardSprite.TRADER3);

        trader.AddDialogue("You come across a trader.");
        trader.AddDialogue("They look like they have stuff to sell");
        trader.AddDialogue("A random person pops up and offers you resources for money");

        trader.AddLeftQuote("Try to sell resources to them");
        trader.AddLeftQuote("Sell resources for money?");
        trader.AddLeftQuote("Maybe they can spare some change?");

        trader.AddRightQuote("Try to buy resources");
        trader.AddRightQuote("Try to by some stuff");
        trader.AddRightQuote("Buy resources for money");

        trader.AddLeftSuccessDialogue("You manage to make some money");
        trader.AddLeftSuccessDialogue("You made a bit of money");
        trader.AddLeftSuccessDialogue("You got some cash.");

        trader.AddRightSuccessDialogue("You managed to buy some resources");
        trader.AddRightSuccessDialogue("Well ya managed to spend money");
        trader.AddRightSuccessDialogue("Good deal I guess");

        trader.AddRightFailDialogues("You couldn't afford it");
        trader.AddRightFailDialogues("You had no money to spend");
        trader.AddRightFailDialogues("You wasted the traders time");

        trader.AddLeftFailDialogues("You had no resources to give");
        trader.AddLeftFailDialogues("You had nothing they wanted to buy");
        trader.AddLeftFailDialogues("They scoffed in your face, guess no trade then");

        trader.AddGenericEndQuotes("Great.");
        trader.AddGenericEndQuotes("Ok.");
        trader.AddGenericEndQuotes("Couldn't have gone better.");

        scenarios.Add(trader);

        TheftScenario thief = new TheftScenario();
        thief.SetBasicScenarioDifficulty(5);
        thief.AddSprite(CardSprite.THIEF1);
        thief.AddSprite(CardSprite.THIEF2);
        thief.AddSprite(CardSprite.THIEF3);


        thief.AddDialogue("Someone attempts to rob you.");
        thief.AddDialogue("Stick em up! You are being robbed.");
        thief.AddDialogue("Give me everything you have.");

        thief.AddLeftQuote("Take it just don't hurt me");
        thief.AddLeftQuote("You can have it");
        thief.AddLeftQuote("Ahhhh please don't hurt me");

        thief.AddRightQuote("Nah you aren't having my stuff");
        thief.AddRightQuote("No way Jose!");
        thief.AddRightQuote("Over my dead body.");

        thief.AddLeftSuccessDialogue("You get robbed blind");
        thief.AddLeftSuccessDialogue("You let them take your stuff");
        thief.AddLeftSuccessDialogue("Better than dying i guess");

        thief.AddRightSuccessDialogue("You beat the robber up");
        thief.AddRightSuccessDialogue("You kicked their head in");
        thief.AddRightSuccessDialogue("They aren't stealing from anyone ever again");

        thief.AddRightFailDialogues("You got robbed anyway");
        thief.AddRightFailDialogues("You weren't stronger than them");
        thief.AddRightFailDialogues("Well at least you tried");

        thief.AddLeftFailDialogues("This shouldn't happen (Error)");

        thief.AddGenericEndQuotes("Great.");
        thief.AddGenericEndQuotes("Ok.");
        thief.AddGenericEndQuotes("Couldn't have gone better.");

        scenarios.Add(thief);


    }

    public List<Scenario> GetScenarios()
    {
        return scenarios;
    }

    public Sprite[] GetSprites()
    {
        return sprites;
    }

}

public enum CardSprite
{
    ABANDONED1,
    ABANDONED2,
    ABANDONED3,
    PEASANT1,
    PEASANT2,
    PEASANT3,
    PEASANT4,
    PEASANT5,
    PEASANT6,
    PSYCHO1,
    PSYCHO2,
    PSYCHO3,
    SETTLEMENT1,
    SETTLEMENT2,
    SETTLEMENT3,
    THIEF1,
    THIEF2,
    THIEF3,
    TRADER1,
    TRADER2,
    TRADER3

}
