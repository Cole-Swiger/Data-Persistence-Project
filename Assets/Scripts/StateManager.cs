using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StateManager : MonoBehaviour
{
    //persist data
    public static StateManager instance;
    public string playerName = "Player";
    public string bestPlayerName;
    public int bestScore;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [System.Serializable]
    class SaveData
    {
        public int bestScore;
        public string bestPlayerName;
    }

    public void SaveBestScore()
    {
        SaveData save = new SaveData();
        save.bestPlayerName = bestPlayerName;
        save.bestScore = bestScore;

        string saveJson = JsonUtility.ToJson(save);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", saveJson);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {   
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScore = data.bestScore;
            bestPlayerName = data.bestPlayerName;
        }
    }
}
