using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDown_Effect : MonoBehaviour
{

    public Player_Mover player;
    public float SpeedDownEffect;
    public float SpeedDownDuration;
    public bool isOn = false;

    public void SpeedDown()
    {
        isOn = true;
        player.GetComponent<Player_Mover>().speed = Mathf.Lerp(player.GetComponent<Player_Mover>().speed, player.GetComponent<Player_Mover>().speed - SpeedDownEffect, SpeedDownDuration);
        isOn = false;
    }
}
