using UnityEngine;
using UnityEngine.SceneManagement;

public class Playbutton : MonoBehaviour
{

    // Use this for initialization
    public void Play()
    {
        SceneManager.LoadScene("_Scene_", LoadSceneMode.Single);
        LeaderBoardData.leaderboard.SetUsernameInputField();
    }

}
