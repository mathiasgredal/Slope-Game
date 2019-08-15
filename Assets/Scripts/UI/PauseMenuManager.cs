using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{

    public static bool isPauseMenuOn = false;

    Animator anim;

    Vector3 velocity;
    Vector3 angularMomentum;

    Rigidbody playerRb;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        playerRb = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();
        isPauseMenuOn = true;
        CloseOrOpenMenu();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            CloseOrOpenMenu();
        }

        if (isPauseMenuOn)
        {
            anim.SetBool("isOn", true);

        }
        if (!isPauseMenuOn)
        {
            anim.SetBool("isOn", false);

        }
    }

    public void CloseOrOpenMenu()
    {
        if (!isPauseMenuOn)
        {
            velocity = playerRb.velocity;
            angularMomentum = playerRb.angularVelocity;
            playerRb.isKinematic = true;
        }
        if (isPauseMenuOn)
        {
            playerRb.isKinematic = false;
            playerRb.velocity = velocity;
            playerRb.angularVelocity = angularMomentum;
        }

        isPauseMenuOn = !isPauseMenuOn;

        if (isPauseMenuOn)
        {
            anim.SetBool("isOn", true);

        }
        if (!isPauseMenuOn)
        {
            anim.SetBool("isOn", false);

        }
    }
}


