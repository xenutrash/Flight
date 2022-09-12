using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreMaster : MonoBehaviour
{



    private int Score = 0;
    public Text ScoreText;


    public void UpdateScore(int ScoreToAdd)
    {
        Score += ScoreToAdd;
        UpdateScoreText();
    }

    public int GetScore() => Score;

    public void SetScore(int NewScore)
    {
        Score = NewScore;
        UpdateScoreText();
    }

    public void ResetScore()
    {
        try
        {
            Score = 0;
        }
        catch
        {
            Debug.LogError("Reset faild");
        }

    }
    public void AddScore(int ScoreToAdd)
    {

        Score += ScoreToAdd;
        UpdateScoreText();
    }

    public void UpdateScoreText() => ScoreText.text = Score.ToString();


    private void Awake()
    {
        ResetScore();
    }
}
