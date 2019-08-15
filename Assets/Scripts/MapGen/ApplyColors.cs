using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyColors : MonoBehaviour
{

    public Material playerColor;
    public Material particleColor;
    public Material safezone;
    public Material killzone;

    // Use this for initialization
    void Start()
    {
        SetColor();
    }

    public void SetColor()
    {
        playerColor.color = Settings.playerSettings.playerColor;
        particleColor.color = Settings.playerSettings.particleColor;
        safezone.color = Settings.playerSettings.safezone;
        killzone.color = Settings.playerSettings.killzone;

    }

}