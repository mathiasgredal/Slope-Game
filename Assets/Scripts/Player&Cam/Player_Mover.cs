using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Mover : MonoBehaviour
{


    Rigidbody rb;// the rigidbody

    public float speedMultiplierOverMappieces;
    public float gravityMultiplierOverMappieces;
    public float speedLerpTime;
    public float gravityLerpTime;
    public float introTime;
    public float originSpeed;// the speed of the ball
    public float speed;
    public float gravity;
    public float controlSpeed;// the turnspeed
    float startGravity;

    // runs on the first frame
    void Start()
    {
        startGravity = Physics.gravity.y;
        gravity = Physics.gravity.y;
        FindObjectOfType<Player_Killer>().OnRetryMap += StartMethods;
        rb = this.GetComponent<Rigidbody>();// getting the rigidbody component
        this.transform.position = new Vector3(0f, 4.3f, 0);// placing the player at the start location
        StartCoroutine(WaitToStart());

    }

    public void IncreaseSpeed()
    {
        speed = Mathf.Lerp(speed, speed + speedMultiplierOverMappieces, speedLerpTime);
        gravity = (Mathf.Abs(Mathf.Lerp(gravity, gravity + gravityMultiplierOverMappieces, gravityLerpTime)) - Mathf.Abs(gravity)) + gravity;
        Physics.gravity = new Vector3(Physics.gravity.x, gravity);
    }

    public void StartMethods()
    {
        //speed = originSpeed;
        StartCoroutine(WaitToStart());
    }

    IEnumerator WaitToStart()
    {
        gravity = startGravity;
        Physics.gravity = new Vector3(Physics.gravity.x, gravity);
        speed = 0;
        yield return new WaitForSecondsRealtime(introTime);
        speed = originSpeed;

    }

    // runs 50 times a second
    void FixedUpdate()
    {
        if (PauseMenuManager.isPauseMenuOn == true)
        {
            return;
        }
        else if (Player_Killer.fallenOutOfMap)
        {
            float horizontalMovement = Input.GetAxis("Horizontal") * controlSpeed;// finding out where we want to move
            rb.AddForce(Vector3.back * horizontalMovement);// adding the force in that direction
        }
        else
        {
            float horizontalMovement = Input.GetAxis("Horizontal") * controlSpeed;// finding out where we want to move

            rb.AddForce(Vector3.back * horizontalMovement, ForceMode.Force);// adding the force in that direction
            rb.AddForce(Vector3.right * speed);// applying the speed
        }

    }

    void OnDisable()
    {
        FindObjectOfType<Player_Killer>().OnRetryMap -= StartMethods;
    }
}
