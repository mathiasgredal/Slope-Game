using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessSettingsMethods : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Settings.playerSettings.Load();
    }

}
