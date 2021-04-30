using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;

//Taken from https://www.raywenderlich.com/418-how-to-save-and-load-a-game-in-unity
public class ScoreLoader : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private int score;

    public void Start()
    {
        LoadGame();
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
            score = save.getDays();
            scoreText.text = "You survived for " + score + " days.";

           
        }
        else
        {
            scoreText.text = "You survived for 0 days.";
            Debug.Log("No game saved!");
        }
    }

}
