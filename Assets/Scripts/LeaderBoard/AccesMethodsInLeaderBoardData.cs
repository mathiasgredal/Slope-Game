using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccesMethodsInLeaderBoardData : MonoBehaviour
{

    public void GetUsername(string usernameInput)
    {
        LeaderBoardData.leaderboard.username = usernameInput;
    }// inputfield is calling this and sending its text with it

    public void AddScoreToLeaderboard()
    {
        LeaderBoardData.leaderboard.AddHighScoreAutonomus();
    }

    public void GetAutoApply(bool auto)
    {
        LeaderBoardData.leaderboard.GetAutoApply(auto);
    }

    public void LoadSettings()
    {
        Settings.playerSettings.Load();
    }
}
