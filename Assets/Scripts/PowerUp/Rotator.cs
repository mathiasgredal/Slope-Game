using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotateSpeed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, 1 * rotateSpeed * Time.deltaTime);
    }
}
