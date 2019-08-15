using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SloMo_Effect : MonoBehaviour
{
    public CanvasGroup HUD;
    public Player_Mover player;
    public float Slownes;
    public bool isOn = false;

    float currentTime = 0f;
    float timeToLerp = 1f;
    bool startFX = false;
    bool stopFX = false;

    void Update()
    {
        if (startFX == true)
        {
            if (currentTime <= timeToLerp)
            {
                currentTime += Time.deltaTime;
                HUD.alpha = Mathf.Lerp(0f, 1f, currentTime / timeToLerp);
            }
            else
            {
                currentTime = 0f;
                startFX = false;
            }
        }
        else if (stopFX == true)
        {
            if (currentTime <= timeToLerp)
            {
                currentTime += Time.deltaTime;
                HUD.alpha = Mathf.Lerp(1f, 0f, currentTime / timeToLerp);
            }
            else
            {
                HUD.alpha = 0;
                currentTime = 0f;
                stopFX = false;
            }
        }
    }

    public void SlowMo(float duration)
    {
        isOn = true;
        startFX = true;
        Time.timeScale = Slownes;
        player.controlSpeed /= Slownes;
        StartCoroutine(SlowMoEnd(duration));
    }

    IEnumerator SlowMoEnd(float duration)
    {
        yield return new WaitForSecondsRealtime(duration);
        stopFX = true;
        Time.timeScale = 1;
        player.controlSpeed *= Slownes;
        isOn = false;
    }
}
