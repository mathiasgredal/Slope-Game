using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApplyLeaderBoard : MonoBehaviour
{

    public Transform leaderboardParent;

    public void ApplyToTheLeaderboard()
    {
        for (int i = 0; i < LeaderBoardData.leaderboard.leaderBoardData.Count; i++)
        {
            leaderboardParent.GetChild(i).Find("Name").GetComponent<Text>().text = (LeaderBoardData.leaderboard.leaderBoardData[i].name == "" && LeaderBoardData.leaderboard.leaderBoardData[i].date != "") ? "Stefan" : LeaderBoardData.leaderboard.leaderBoardData[i].name;// name
            leaderboardParent.GetChild(i).Find("Score").GetComponent<Text>().text = (LeaderBoardData.leaderboard.leaderBoardData[i].score == 0 && LeaderBoardData.leaderboard.leaderBoardData[i].date == "") ? "" : LeaderBoardData.leaderboard.leaderBoardData[i].score.ToString();// score
            leaderboardParent.GetChild(i).Find("Date").GetComponent<Text>().text = LeaderBoardData.leaderboard.leaderBoardData[i].date;// date

        }
    }

    void Start()
    {
        ApplyToTheLeaderboard();
    }
}
