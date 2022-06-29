using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class MainMenu : MonoBehaviour
{
    public TMP_Text bestScore;
    public TMP_Text playerName;

    void Start()
    {
        // get the score from data
        bestScore.text = "Best: " + DataManager.Instance.playerName1 + " " + DataManager.Instance.bestScore1;
    }
    public void SetPlayerName()
    {
        // store the name on data
        DataManager.Instance.currentPlayerName = playerName.text;
        DataManager.Instance.currentScore = 0;
    }

    public void StartClicked()
    {
        SceneManager.LoadScene(1);
    }
    public void SettingsClicked()
    {
        SceneManager.LoadScene(2);
    }
    public void ScoresClicked()
    {
        SceneManager.LoadScene(3);
    }
    public void QuitClicked()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
                Application.Quit(); // original code to quit Unity player
#endif
    }
}
