using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Slider ballSpeed;
    public Slider paddleSpeed;

    // Start is called before the first frame update
    void Start()
    {
        ballSpeed.value = DataManager.Instance.maxBallSpeed;
        paddleSpeed.value = DataManager.Instance.paddleSpeed;
    }
    public void MenuClicked()
    {
        SceneManager.LoadScene(0);
    }
    public void SetBallSpeed()
    {
        DataManager.Instance.maxBallSpeed = ballSpeed.value;
    }
    public void SetPaddleSpeed()
    {
        DataManager.Instance.paddleSpeed = paddleSpeed.value;
    }
    public void SaveSettings()
    {
        DataManager.Instance.SaveData();
    }
    public void DefaultSettings()
    {
        DataManager.Instance.paddleSpeed = 2.0f;
        DataManager.Instance.maxBallSpeed = 3.0f;
        ballSpeed.value = DataManager.Instance.maxBallSpeed;
        paddleSpeed.value = DataManager.Instance.paddleSpeed;
        DataManager.Instance.SaveData();
    }
}
