using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public string playerName;
    public Text ScoreText;
    public Text bestScoreText;
    public GameObject GameOverText;
    
    private bool m_Started = false;
    private int m_Points;
    
    private bool m_GameOver = false;


    void Start()
    {
        // load best score and playername
        bestScoreText.text = "Best: " + DataManager.Instance.playerName1 + " " + DataManager.Instance.bestScore1;
        ScoreText.text = $"Score : {DataManager.Instance.currentPlayerName + " " + m_Points}";

        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {DataManager.Instance.currentPlayerName + " " + m_Points}";
    }

    public void GameOver()
    {
        // check best scores and save playername and score if needed
        CheckBestScores();

        //if (m_Points > DataManager.Instance.bestScore1) // works for single highscore
        //{
        //    bestScoreText.text = $"Score : {DataManager.Instance.currentPlayerName + " " + m_Points}";
        //    DataManager.Instance.playerName1 = DataManager.Instance.currentPlayerName;
        //    DataManager.Instance.bestScore1 = m_Points;
        //    DataManager.Instance.SaveScore();
        //}
        m_GameOver = true;
        GameOverText.SetActive(true);
    }

    public void MenuClicked()
    {
        SceneManager.LoadScene(1);
    }
    void CheckBestScores()
    {
        if (m_Points > DataManager.Instance.bestScore1) // new best score
        {
            bestScoreText.text = $"Score : {DataManager.Instance.currentPlayerName + " " + m_Points}";

            DataManager.Instance.playerName3 = DataManager.Instance.playerName2;
            DataManager.Instance.bestScore3 = DataManager.Instance.bestScore2;

            DataManager.Instance.playerName2 = DataManager.Instance.playerName1;
            DataManager.Instance.bestScore2 = DataManager.Instance.bestScore1;

            DataManager.Instance.playerName1 = DataManager.Instance.currentPlayerName;
            DataManager.Instance.bestScore1 = m_Points;
            DataManager.Instance.SaveScore();
            
            return;
        }
        else if (m_Points > DataManager.Instance.bestScore2) // new second best score
        {
            DataManager.Instance.playerName3 = DataManager.Instance.playerName2;
            DataManager.Instance.bestScore3 = DataManager.Instance.bestScore2;

            DataManager.Instance.playerName2 = DataManager.Instance.currentPlayerName;
            DataManager.Instance.bestScore2 = m_Points;
            DataManager.Instance.SaveScore();

            return;
        }
        else if (m_Points > DataManager.Instance.bestScore3) // new tirth best score
        {
            DataManager.Instance.playerName3 = DataManager.Instance.currentPlayerName;
            DataManager.Instance.bestScore3 = m_Points;
            DataManager.Instance.SaveScore();
        }

    }

}
