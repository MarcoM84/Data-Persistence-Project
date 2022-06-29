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
        name1.text = DataManager.Instance.playerName1 + " ";
        score1.text = DataManager.Instance.bestScore1.ToString();
        name2.text = DataManager.Instance.playerName2 + " ";
        score2.text = DataManager.Instance.bestScore2.ToString();
        name3.text = DataManager.Instance.playerName3 + " ";
        score3.text = DataManager.Instance.bestScore3.ToString();
    }

    public void MenuClicked()
    {
        SceneManager.LoadScene(0);
    }
}
