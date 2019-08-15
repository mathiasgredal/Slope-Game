using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenuButton : MonoBehaviour
{

    // Use this for initialization
    public void Back()
    {
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }

}
