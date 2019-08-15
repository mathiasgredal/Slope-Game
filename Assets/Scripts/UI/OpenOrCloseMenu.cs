using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenOrCloseMenu : MonoBehaviour
{

    public Animator animMainMenu;

    void OpenOrCloseMainMenu()
    {
        animMainMenu.SetTrigger("MainMenuTrans");
    }
}
