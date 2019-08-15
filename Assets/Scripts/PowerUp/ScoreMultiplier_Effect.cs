using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMultiplier_Effect : MonoBehaviour
{

    public Player_Killer player;
    public bool isOn = false;
    public static int ScoreMultiplication = 1;

    public void ScoreMultiplier(float duration)
    {
        isOn = true;
        ScoreMultiplication *= 2;
        StartCoroutine(ScoreMultiplierEnd(duration));
    }

    IEnumerator ScoreMultiplierEnd(float duration)
    {
        yield return new WaitForSeconds(duration);
        ScoreMultiplication /= 2;
        isOn = false;
    }
}
