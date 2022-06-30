using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameOverSceneMain : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScoreText, scoreText;
    private void Start()
    {
        scoreText.text = "SCORE :" + GameManager.GM.Score.ToString();
        highScoreText.text = "HIGH SCORE : " + GameManager.GM.HighScore.ToString();
    }

    public void ExitButton()
    {
        GameManager.GM.ExitGame();
    }

    public void RetryLevelB()
    {
        Debug.Log("basti");
        GameManager.GM.StartGame();
    }
}
