using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

//This class was originally taken from this tutorial: https://www.youtube.com/watch?v=gs3kNq89Ym4
//but it has been changed significantly, i will note any pieces of code that have stayed the same.
public class GameManager : MonoBehaviour
{
    [SerializeField] private StatsManager statsManager;
    [SerializeField] private ResourceManager resourceManager;
    [SerializeField] private InterfaceManager interfaceManager;
    [SerializeField] private CardController cardController;
    [SerializeField] private TMP_Text dayText;

    private int previousHighScore;


    void Start()
    {
        resourceManager.populateScenarios();
        previousHighScore = 0;
        LoadGame();
        cardController.Initialise(resourceManager, statsManager);
    }

    void Update()
    {
        cardController.UpdateDialogue(resourceManager , statsManager);

        cardController.MoveCard();

        cardController.CalculateScenarioSuccess(statsManager);

        UpdateDayText();

        interfaceManager.SetFillAmounts(cardController.GetDirection(), statsManager, cardController.GetCurrentScenario());

        if (statsManager.getHealth() < 1)
        {
            if (statsManager.getDay() > previousHighScore)
            {
                SaveScore();
            }
            GameOver();
        }

        if(cardController.GetScenarioCount() == 3)
        {
            statsManager.nextDay();
            cardController.ResetScenarioCount();
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene(2);
    }

    private Save CreateSaveGameObject()
    {
        Save save = new Save();
        save.setDays(statsManager.getDay());

        return save;
    }

    public void SaveScore()
    {
        Save save = CreateSaveGameObject();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();

        Debug.Log("Score Saved");
    }

    public void LoadGame()
    {
        // 1
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {

            // 2
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();
            previousHighScore = save.getDays();


        }
        else
        {

            Debug.Log("No game saved!");
        }
    }

    private void UpdateDayText()
    {
        dayText.text = "Day: " + statsManager.getDay();
    }


}
