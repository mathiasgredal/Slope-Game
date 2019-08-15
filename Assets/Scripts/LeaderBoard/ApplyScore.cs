using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApplyScore : MonoBehaviour
{
    public Text scoreText;

    public void SetScore()
    {
        if (LeaderBoardData.GetScore() > LeaderBoardData.leaderboard.leaderBoardData[0].score)
        {
            scoreText.text = "New Highscore: " + LeaderBoardData.GetScore();
        }
        else {
            scoreText.text = "New Score: " + LeaderBoardData.GetScore();
        }
    }
}
