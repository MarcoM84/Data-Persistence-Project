using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BestScoresMenu : MonoBehaviour
{
    public TMP_Text name1;
    public TMP_Text score1;
    public TMP_Text name2;
    public TMP_Text score2;
    public TMP_Text name3;
    public TMP_Text score3;
    // Start is called before the first frame update
    void Start()
    {
        //write highscores
        name1.text = DataManager.Instance.playerName + " ";
        score1.text = DataManager.Instance.bestScore.ToString();
    }

    public void MenuClicked()
    {
        SceneManager.LoadScene(1);
    }
}
