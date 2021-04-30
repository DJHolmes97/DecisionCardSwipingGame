using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//This class was originally taken from this tutorial: https://www.youtube.com/watch?v=gs3kNq89Ym4
//but it has been changed significantly, i will note any pieces of code that have stayed the same.
public class CardController : MonoBehaviour
{
    [SerializeField] private GameObject cardGameObject;

    [SerializeField] private SpriteRenderer actionBackground;

    [SerializeField]private SpriteRenderer gameCardSpriteRenderer;

    [SerializeField] private Vector2 defaultCardPosition;

    [SerializeField] private Scenario currentScenario;

    ////The dialogue boxes that appear on the card
    [SerializeField]
    private TMP_Text dialogue;
    [SerializeField]
    private TMP_Text characterDialogue;

    //Controlled Colours for the dialogue and the background
    [SerializeField]
    private Color textColour;
    [SerializeField]
    private Color actionBackgroundColor;

    //The direction the card has been swiped
    private string direction;

    private string dialogueStr;
    private string rightQuote;
    private string leftQuote;
    private int stage;
    private int scenarioCount;
    private bool scenarioSuccess;
    private BoxCollider2D thisCard;

    //Keeps track on whether the card is being substituted
    private bool isSubstituting;

    private bool isMouseOver = false;

    private void Start()
    {
        direction = "none";
    }

    //This initialise the card before use
    public void Initialise(ResourceManager resourceManager, StatsManager statsManager)
    {
        int rollDice = Random.Range(0, resourceManager.GetScenarios().Count - 1);
        currentScenario = resourceManager.GetScenarios()[rollDice];
        LoadScenario(resourceManager, statsManager);
        scenarioCount = 0;
        defaultCardPosition = new Vector2(0, -0.05f);
        thisCard = gameObject.GetComponent<BoxCollider2D>();
        isSubstituting = false;
        stage = 1;
    }

    private void OnMouseOver()
    {
        isMouseOver = true;
    }

    private void OnMouseExit()
    {
        isMouseOver = false;
    }

    private bool GetMouseOver()
    {
        return isMouseOver;
    }

    //A large portion of this script is derived from the above mentioned Youtube tutorial
    //It controls how the dialogue appears on the card
    public void UpdateDialogue(ResourceManager resourceManager, StatsManager statsManager)
    {
        //Margins and trigger distances for card swipes
        float sideMargin = 0.05f;
        float sideTrigger = 0.15f;

        //Value for changing the intensity of the tranparency for the actionBackgroundColor
        int transparencyDivideValue = 6;

        //Display Text Script
        textColour.a = Mathf.Min(Mathf.Abs((cardGameObject.transform.position.x * 3) - sideMargin), 1);
        actionBackgroundColor.a = Mathf.Min(Mathf.Abs(cardGameObject.transform.position.x - sideMargin) / transparencyDivideValue, .7f);
        dialogue.color = textColour;
        if (cardGameObject.transform.position.x > sideTrigger)
        {
            direction = "right";

            if (Input.GetMouseButtonUp(0))
            {
                if (stage == 1)
                {
                    RightSwipe(statsManager);

                }

                NewScenario(resourceManager, statsManager);

            }
        }
        else if (cardGameObject.transform.position.x > sideMargin)
        {
            direction = "right";
        }
        else if (cardGameObject.transform.position.x > -sideMargin)
        {
            direction = "none";
            textColour.a = 0;
        }
        else if (cardGameObject.transform.position.x > -sideTrigger)
        {
            direction = "left";
        }
        else
        {
            direction = "left";
            if (Input.GetMouseButtonUp(0))
            {
                if (stage == 1)
                {
                    LeftSwipe(statsManager);

                }
                NewScenario(resourceManager, statsManager);


            }
        }

        dialogue.color = textColour;
        actionBackground.color = actionBackgroundColor;
        if (cardGameObject.transform.position.x > 0)
        {
            dialogue.text = rightQuote;
        }
        else
        {
            dialogue.text = leftQuote;
        }

        characterDialogue.text = dialogueStr;
    }

    //This creates a new Scenario after the last one has been completed
    //It gets the scenario from the list of scenarios
    private void NewScenario(ResourceManager resourceManager, StatsManager statsManager)
    {
        if (stage == 1)
        {
            NextStage();
        }
        else
        {
            int rollDice = Random.Range(0, resourceManager.GetScenarios().Count - 1);
            currentScenario = resourceManager.GetScenarios()[rollDice];
            LoadScenario(resourceManager, statsManager);
        }


    }

    //This loads the new scenario into the game
    public void LoadScenario(ResourceManager resourceManager, StatsManager statsManager)
    {
        Vector3 initRotation = new Vector3(0, -180, 0);
        gameCardSpriteRenderer.sprite = resourceManager.GetSprites()[(int)currentScenario.GetRandomSprite()];
        dialogueStr = currentScenario.GetRandomDialogue();
        rightQuote = currentScenario.GetRandomRightQuote();
        leftQuote = currentScenario.GetRandomLeftQuote();
        currentScenario.SetScenarioLevel(statsManager.getDay());

        cardGameObject.transform.position = defaultCardPosition;
        cardGameObject.transform.eulerAngles = new Vector3(0, 0, 0);

        isSubstituting = true;
        cardGameObject.transform.eulerAngles = initRotation;
        stage = 1;
        IncreaseScenarioCount();
    }

    //This controls moving to the second stage of a scenario
    private void NextStage()
    {
        Vector3 initRotation = new Vector3(0, -180, 0);

        cardGameObject.transform.position = defaultCardPosition;
        cardGameObject.transform.eulerAngles = new Vector3(0, 0, 0);

        isSubstituting = true;
        cardGameObject.transform.eulerAngles = initRotation;
        stage = 2;

    }

    //this script has been mostly taken from the above mentioned Youtube tutorial
    //There have been significant changes but large portions haven't been changed
    public void MoveCard()
    {
        //The speed that the card moves and the speed that it rotates as it's swiped
        float movementSpeed = 1f;
        float rotationSpeed = 2f;
        float fRotationCoefficient = -15;

        Vector3 cardRotation = new Vector3(0, 0, 0);

        //Card Movement Script
        if (Input.GetMouseButton(0) && GetMouseOver())
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cardGameObject.transform.position = pos;
            cardGameObject.transform.eulerAngles = new Vector3(0, 0, cardGameObject.transform.position.x * fRotationCoefficient);

        }
        else if (!isSubstituting)
        {
            cardGameObject.transform.position = Vector2.MoveTowards(cardGameObject.transform.position, defaultCardPosition, movementSpeed);
            cardGameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (isSubstituting)
        {
            cardGameObject.transform.eulerAngles = Vector3.MoveTowards(cardGameObject.transform.eulerAngles, cardRotation, rotationSpeed);

        }

        if (cardGameObject.transform.eulerAngles == cardRotation)
        {
            isSubstituting = false;
        }

    }

    //This controls what happens when the user swipes left
    private void LeftSwipe(StatsManager statsManager)
    {
        if (scenarioSuccess)
        {
            dialogueStr = currentScenario.GetRandomLeftSuccessDialogue();

        }
        else
        {
            dialogueStr = currentScenario.GetRandomLeftFailDialogue();
        }
        statsManager.changeHealth(currentScenario.GetHealthEffect());
        statsManager.changeHunger(currentScenario.GetHungerEffect());
        statsManager.changeAttack(currentScenario.GetAttackEffect());
        statsManager.changeWealth(currentScenario.GetWealthEffect());
        leftQuote = currentScenario.GetRandomGenericEndQuotes();
        rightQuote = currentScenario.GetRandomGenericEndQuotes();
        currentScenario.InitialiseLikely();


    }

    //This controls what happens when the user swipes right
    private void RightSwipe(StatsManager statsManager)
    {

        if (scenarioSuccess)
        {

            dialogueStr = currentScenario.GetRandomRightSuccessDialogue();
        }
        else
        {
            dialogueStr = currentScenario.GetRandomRightFailDialogue();
        }
        statsManager.changeHealth(currentScenario.GetHealthEffect());
        statsManager.changeHunger(currentScenario.GetHungerEffect());
        statsManager.changeAttack(currentScenario.GetAttackEffect());
        statsManager.changeWealth(currentScenario.GetWealthEffect());
        leftQuote = currentScenario.GetRandomGenericEndQuotes();
        rightQuote = currentScenario.GetRandomGenericEndQuotes();
        currentScenario.InitialiseLikely();

    }

    //This tracks how many scenarios you are on
    private void IncreaseScenarioCount()
    {
        scenarioCount++;

    }

    //This returns how many scenarios you are on
    public int GetScenarioCount()
    {
        return scenarioCount;
    }

    //This resets how many scenarios you are on
    public void ResetScenarioCount()
    {
        scenarioCount = 0;
    }

    //This works out if a swipe has been successful
    public void CalculateScenarioSuccess(StatsManager statsManager)
    {
        if (stage == 1)
        {
            if (GetDirection() == "left")
            {
                scenarioSuccess = currentScenario.CalculateLeftSuccess(statsManager);
            }
            else if (GetDirection() == "right")
            {
                scenarioSuccess = currentScenario.CalculateRightSuccess(statsManager);
            }
        }
    }

    //This returns the direction of the swipe
    public string GetDirection()
    {
        return direction;
    }

    //This returns the current scenario
    public Scenario GetCurrentScenario()
    {
        return currentScenario;
    }


}

