using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PersistenceManager : MonoBehaviour
{

    public static PersistenceManager Instance;
    public string playerName;

    public int highestScore;
    public string highScoreName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeName(string name)
    {
        playerName = name;
    }

    // Creates serializable save data object, so high score and 
    [System.Serializable]
    class SaveData
    {
        public int highScore;
        public string scorerName;
    }

    // Saves high score data between sessions
    public void SaveScore()
    {
        // Creates data object to save
        SaveData data = new SaveData();
        // Saves data meant for long-term storage in data package
        data.highScore = highestScore;
        data.scorerName = highScoreName;

        // Turns data into a json-friendly string
        string json = JsonUtility.ToJson(data);

        // Saves string to a file
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        // Creates variable for path to save file
        string path = Application.persistentDataPath + "/savefile.json";
        // Confirms save file exists before trying to load
        if (File.Exists(path))
        {
            // Reads content of save file into a string
            string json = File.ReadAllText(path);
            // Converts data from json-string back into a SaveData instance
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            // Sets color to the color in the save file.
            highestScore = data.highScore;
            highScoreName = data.scorerName;
        }
    }
}
