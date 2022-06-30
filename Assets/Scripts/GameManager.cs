using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState { Menu, Playing, GameOver };
public class GameManager : MonoBehaviour
{
    #region GameManager Singleton
    static private GameManager gm;
    static public GameManager GM { get { return gm; } }

    void CheckGameManagerIsInScene()
    {
        if (gm == null)
        {
            gm = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);
    }
    #endregion

    [SerializeField] static public int highScore = 0;
    public int HighScore { get { return highScore; } set { highScore = value; } }

    static public int score;
    public int Score { get { return score; } set { score = value; } }//access to static variable score [get/set methods]

    [Header("SCENE SETTINGS")]
    public string startScene;
    public string gameOverScene;
    public string[] gameLevels; //names of levels
    [HideInInspector]
    public int gameLevelsCount; //what level we are on

    public static string currentSceneName;

    void Awake()
    {
        CheckGameManagerIsInScene();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(gameLevels[0]);
        Score = 0;
        Mover.gameSpeed = 5f;
    }

    public void GameOver()
    {
        SceneManager.LoadScene(gameOverScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void UpdateScore(int point = 0)
    {
        score += point;
        if (score > GetHighScore())
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore); //set the playerPref for the high score
        }
    }

    int GetHighScore()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore"); //set the high score to the saved high score
        }
        return highScore;
    }
}