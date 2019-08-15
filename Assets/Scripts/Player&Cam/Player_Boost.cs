using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Boost : MonoBehaviour
{

    public bool isBoosting;

    TrailRenderer trail;

    void Start()
    {
        trail = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo;
        Ray ray = new Ray(transform.position, Vector3.up);

        if (Physics.Raycast(ray, out hitInfo, 50))
        {
            if (hitInfo.collider.gameObject.CompareTag("BoostZone"))
            {
                isBoosting = true;
            }
        }
        else
        {
            isBoosting = false;
        }

        if (isBoosting)
        {
            trail.enabled = true;
        }
        else
        {
            trail.enabled = false;
        }
    }
}
