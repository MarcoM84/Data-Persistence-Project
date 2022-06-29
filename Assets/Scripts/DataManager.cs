using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public float maxBallSpeed = 3.0f;
    public float paddleSpeed = 2.0f;

    public string currentPlayerName = "NoName";
    public int currentScore = 0;

    public string playerName1;
    public int bestScore1;
    public string playerName2;
    public int bestScore2;
    public string playerName3;
    public int bestScore3;

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

    private void Start()
    {
              
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            LoadData();
        }
        else
        {
            maxBallSpeed = 3.0f;
            paddleSpeed = 2.0f;
            playerName1 = "AAA";
            bestScore1 = 0;
            playerName2 = "BBB";
            bestScore2 = 0;
            playerName3 = "CCC";
            bestScore3 = 0;
            SaveData();
        }
    }


    [System.Serializable]
    class SaveDataClass
    {
        public float maxBallSpeed;
        public float paddleSpeed;

        public string playerName1;
        public int bestScore1;
        public string playerName2;
        public int bestScore2;
        public string playerName3;
        public int bestScore3;
    }

    public void SaveData()
    {
        SaveDataClass data = new SaveDataClass();
        data.maxBallSpeed = maxBallSpeed;
        data.paddleSpeed = paddleSpeed;

        data.playerName1 = playerName1;
        data.bestScore1 = bestScore1;
        data.playerName2 = playerName2;
        data.bestScore2 = bestScore2;
        data.playerName3 = playerName3;
        data.bestScore3 = bestScore3;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveDataClass data = JsonUtility.FromJson<SaveDataClass>(json);
            maxBallSpeed = data.maxBallSpeed;
            paddleSpeed = data.paddleSpeed;

            playerName1 = data.playerName1;
            bestScore1 = data.bestScore1;
            playerName2 = data.playerName2;
            bestScore2 = data.bestScore2;
            playerName3 = data.playerName3;
            bestScore3 = data.bestScore3;
        }
    }

}
