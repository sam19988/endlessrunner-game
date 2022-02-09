using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public bool gameStarted;
    private int Score=0;
    private int HighScore;
    public Text scoreText;
    public Text HighScoreText;
    public List<GameObject> parts;

    float  timer = 2f;
    float temp;
    public void StartGame()
    {
        gameStarted = true;
    }

    private void Awake()
    {
      HighScoreText.text = "High Score: " + CheckHighScore().ToString();
      

        temp = timer;
    }

    public void EndGame()
    {
        SceneManager.LoadScene(0);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            StartGame();

        if (gameStarted)
        {
            temp -= Time.deltaTime;
            if (temp <= 0)
            {
                deleteParts();
                temp = timer;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
            PlayerPrefs.SetInt("HighScore", 0);
    }

    public void IncreaseScore()
    {
        Score++;
        scoreText.text = Score.ToString();
        if (Score > CheckHighScore())
        {
            PlayerPrefs.SetInt("HighScore", Score);
            HighScoreText.text = "High Score: " + Score.ToString();
        }
    }

    private int CheckHighScore()
    {
         int temp = PlayerPrefs.GetInt("HighScore");
        return temp;
    }

    private void deleteParts()
    {
        Destroy(parts[0]);
        parts.RemoveAt(0);
    }

}
