using UnityEngine;
using System.Collections;

public class ChangePlayerLayer : MonoBehaviour
{

    public int LayerOnEnter; // BallInHole
    public int LayerOnExit;  // BallOnTable

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            Debug.Log("hi");
            other.gameObject.layer = LayerOnEnter;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            Debug.Log("hi2");
            other.gameObject.layer = LayerOnEnter;
        }
    }
}