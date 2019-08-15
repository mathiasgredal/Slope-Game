using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodMode_Effect : MonoBehaviour
{
    public Material killzoneMat;
    Color startColor;
    public Color[] colorEffect;
    int currentIndex = 0;
    int nextIndex;
    public float changeColorTime = 2;
    float lastChange;
    float timer;

    public Player_Killer player;
    public bool isOn = false;

    public void GodMode(float duration)
    {
        startColor = killzoneMat.color;
        isOn = true;
        player.godMode = true;
        StartCoroutine(GodModeEnd(duration));
    }

    IEnumerator GodModeEnd(float duration)
    {
        yield return new WaitForSecondsRealtime(duration);
        Player_Killer.hitKillzone = false;
        player.godMode = false;
        isOn = false;
        killzoneMat.color = Color.Lerp(killzoneMat.color, startColor, timer / changeColorTime);
        yield return new WaitForSecondsRealtime(timer / changeColorTime);
        killzoneMat.color = startColor;
    }

    void Start()
    {
        if (colorEffect == null || colorEffect.Length < 2)
            Debug.Log("Need to setup colors array in inspector");

        nextIndex = (currentIndex + 1) % colorEffect.Length;
    }

    void Update()
    {
        if (isOn)
        {
            timer += Time.deltaTime;

            if (timer > changeColorTime)
            {
                currentIndex = (currentIndex + 1) % colorEffect.Length;
                nextIndex = (currentIndex + 1) % colorEffect.Length;
                timer = 0.0f;

            }
            killzoneMat.color = Color.Lerp(colorEffect[currentIndex], colorEffect[nextIndex], timer / changeColorTime);
        }

    }

}
