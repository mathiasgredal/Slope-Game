using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleLoad : MonoBehaviour
{
    float procent;
    float minNum = -3.14f;
    float maxNum = 3.14f;
    public int powerUpIndex;
    public float durationInSeconds = 0;
    Shader originalShader = new Shader();
    Material copyMat;
    public Color color;
    //[HideInInspector]
    public bool off = false;

    void Start()
    {
        procent = 0;
        durationInSeconds = FindObjectOfType<PowerUp_Manager>().powerUps[powerUpIndex].duration;
        originalShader = Shader.Find("Custom/CircleShader");
        copyMat = new Material(originalShader);
        copyMat.shader = originalShader;
        GetComponent<Image>().material = copyMat;
        copyMat.SetColor("_Color", color);
        copyMat.SetFloat("_Angle", (off == false) ? -3.14f : 3.14f);
    }

    public void SwitchOff()
    {
        copyMat.SetFloat("_Angle", (off == false) ? -3.14f : 3.14f);
    }

    public void StartLoading()
    {
        StartCoroutine(percentOverTime(durationInSeconds));
    }

    float percentToReal(float min, float max, float percent)
    {
        float difference = (min - max) * -1;
        float percenToRealRatio = 100 / difference;
        return (percent / percenToRealRatio - max);
    }

    IEnumerator percentOverTime(float duration)
    {
        for (int i = 0; i < 25; i++)
        {
            yield return new WaitForSecondsRealtime(duration / 25);
            procent += 4;
            copyMat.SetFloat("_Angle", percentToReal(minNum, maxNum, procent));
        }
        procent = 0;
        copyMat.SetFloat("_Angle", percentToReal(minNum, maxNum, procent));
    }
}
