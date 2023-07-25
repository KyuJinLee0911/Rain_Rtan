using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public GameObject rain;
    public Text scoreText;
    public Text timeText;
    public GameObject retryPanel;

    int totalScore = 0;
    float time = 30.0f;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

    }

    private void Start()
    {
        InvokeRepeating("MakeRain", 0, 0.5f);
        InitGame();
    }

    void InitGame()
    {
        Time.timeScale = 1.0f;
        totalScore = 0;
        time = 30.0f;

        Debug.Log(Time.timeScale);
    }

    private void Update() 
    {
        time -= Time.deltaTime;
        if(time < 0)
        {
            time = 0.0f;
            Time.timeScale = 0.0f;
            retryPanel.SetActive(true);
        }

        timeText.text = time.ToString("F2");
    }

    public static GameManager Instance()
    {
        if (!instance)
        {
            instance = FindObjectOfType(typeof(GameManager)) as GameManager;

            if (instance == null)
                Debug.Log("no singleton obj");
        }

        return instance;
    }


    void MakeRain()
    {
        Instantiate(rain);
    }

    public void AddScore(int score)
    {
        totalScore += score;
        scoreText.text = totalScore.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene("MainScene");
    }
}
