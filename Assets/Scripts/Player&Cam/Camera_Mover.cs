using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Mover : MonoBehaviour
{
    public Transform player;// this is the transform of the player
    public Vector3 offset = new Vector3(0.6f, 3.5f, 0);// what offset we want to have from the camera to the player
    Quaternion camRot;

    //runs on the first frame
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;// finding the player object
        camRot = transform.rotation;
    }

    // runs on each fram
    void Update()
    {
        if (!Player_Killer.fallenOutOfMap && !Killscreen_Manager.KillscreenOn)
        {
            this.transform.rotation = camRot;
            transform.position = player.transform.position;// giving the camera the same position as the player
            transform.position += offset;// we apply the offset
        }
        else
        {
            transform.LookAt(player);
        }

    }
}
