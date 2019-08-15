using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killscreen_Manager : MonoBehaviour
{

    public Animator anim;
    public static bool KillscreenOn = false;

    // Use this for initialization
    void Start()
    {
        FindObjectOfType<Player_Killer>().OnRetryMap += MakeKillscreen;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (KillscreenOn)
        {
            anim.SetBool("isDead", true);
        }
        else
        {
            anim.SetBool("isDead", false);
        }
    }

    public static void MakeKillscreen()
    {
        KillscreenOn = !KillscreenOn;
    }

    void OnDisable()
    {
        FindObjectOfType<Player_Killer>().OnRetryMap -= MakeKillscreen;
    }
}
