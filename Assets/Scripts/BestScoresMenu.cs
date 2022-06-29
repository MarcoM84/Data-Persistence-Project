using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BestScoresMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //write highscores
    }

    public void MenuClicked()
    {
        SceneManager.LoadScene(1);
    }
}
