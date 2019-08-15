using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class LeaderBoardData : MonoBehaviour
{
    public static LeaderBoardData leaderboard;

    void Awake()
    {
        if (leaderboard == null)
        {
            DontDestroyOnLoad(gameObject);// make sure object is kept when switching scenes
            leaderboard = this;
        }
        else if (leaderboard != this)
        {
            Load();
            SetUsernameInputField();
            Destroy(this.gameObject);
        }

    }// Make singleton

    void Start()
    {
        Load();
    }

    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.T))
            LeaderBoardData.leaderboard.AddHighScoreAutonomus();
        if (Input.GetKeyDown(KeyCode.S))
            Save();
        if (Input.GetKeyDown(KeyCode.L))
            Load();
        if (Input.GetKeyDown(KeyCode.R))
            Reset();
        */
    }


    // variables
    public bool autoApplyToLeaderboard = false;

    public List<LeaderBoardContainer> leaderBoardData = new List<LeaderBoardContainer>();

    public List<LeaderBoardContainer> leaderBoardDataBase = new List<LeaderBoardContainer>();

    public string username;
    public int score;


    public static void AddHighScore(string name, int score)
    {
        for (int i = 0; i < leaderboard.leaderBoardData.Count; i++)
        {
            if (score >= leaderboard.leaderBoardData[i].score)
            {
                LeaderBoardContainer leaderboardToInsert = new LeaderBoardContainer();
                leaderboardToInsert.score = score;
                leaderboardToInsert.name = name;
                leaderboardToInsert.date = GetDate();
                leaderboard.leaderBoardData.Insert(i, leaderboardToInsert);
                leaderboard.leaderBoardData.RemoveAt(10);
                GameObject.Find("_SCRIPTS_").GetComponent<ApplyLeaderBoard>().ApplyToTheLeaderboard();
                LeaderBoardData.leaderboard.Save();
                return;
            }
        }
    }// adding the highscore into list and sorting

    public void AddHighScoreAutonomus()
    {
        AddHighScore(username, score);

    }// getting the scores and usernames autonomusly and the calling AddHighScore()


    // Get a bunch of variables
    public void GetAutoApply(bool auto)
    {
        autoApplyToLeaderboard = auto;
        Save();
    }// The UI is calling this and sending its state with it

    public static int GetScore()
    {
        return FindObjectOfType<MapGenerator>().playerPositionInMapPieces;
    }// getting score from mapgenerator

    public void SetScore()
    {
        score = GetScore();
    }


    public static string GetDate()
    {
        Date date = new Date();
        date.day = System.DateTime.Now.Date.Day;
        switch (System.DateTime.Now.Date.Month)
        {
            case 1:
                date.months = Date.Months.Jan;
                break;
            case 2:
                date.months = Date.Months.Feb;
                break;
            case 3:
                date.months = Date.Months.Mar;
                break;
            case 4:
                date.months = Date.Months.Apr;
                break;
            case 5:
                date.months = Date.Months.May;
                break;
            case 6:
                date.months = Date.Months.Jun;
                break;
            case 7:
                date.months = Date.Months.Jul;
                break;
            case 8:
                date.months = Date.Months.Aug;
                break;
            case 9:
                date.months = Date.Months.Sep;
                break;
            case 10:
                date.months = Date.Months.Okt;
                break;
            case 11:
                date.months = Date.Months.Nov;
                break;
            case 12:
                date.months = Date.Months.Dec;
                break;
        }
        date.year = System.DateTime.Now.Date.Year;
        return date.months + ". " + date.day + " " + date.year;
    }// Don't even look inside just returns the date


    // Set variables
    public void SetUsernameInputField()
    {
        InputField inputField = GameObject.FindWithTag("Input").GetComponent<InputField>();
        inputField.text = username;
    }// setting the username in the inputfield so you dont need to type it more than once


    // save methods
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/leaderboard" + Settings.textFormat);

        SavedLeaderBoard data = new SavedLeaderBoard();

        // insert vars to be saved

        data.leaderboard = leaderBoardData;
        data.autoApplyToLeaderboard = autoApplyToLeaderboard;
        data.username = username;

        // saving and closing file
        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/leaderboard" + Settings.textFormat))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/leaderboard" + Settings.textFormat, FileMode.Open);
            SavedLeaderBoard data = (SavedLeaderBoard)bf.Deserialize(file);
            file.Close();

            // choose vars to be loaded

            leaderBoardData = data.leaderboard;
            autoApplyToLeaderboard = data.autoApplyToLeaderboard;
            username = data.username;
        }
    }

    public void Reset()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/leaderboard" + Settings.textFormat);

        SavedLeaderBoard data = new SavedLeaderBoard();

        // choose vars to be default

        data.leaderboard = leaderBoardDataBase;
        data.username = "";

        // saving and closing file
        bf.Serialize(file, data);
        file.Close();
        Load();

    }
}

public class Date
{
    public int day;
    public enum Months { Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Okt, Nov, Dec }
    public Months months;
    public int year;
}

[System.Serializable]
public class LeaderBoardContainer
{
    public string name;
    public int score;
    public string date;
}

[Serializable]
class SavedLeaderBoard
{
    public bool autoApplyToLeaderboard;
    public string username;
    public List<LeaderBoardContainer> leaderboard;
}
