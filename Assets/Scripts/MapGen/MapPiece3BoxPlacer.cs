using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPiece3BoxPlacer : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        float XPos = Random.Range(-1.00f, 4.00f);
        float ZPos = Random.Range(-1.02f, 1.02f);
        float YPos = XPos * -0.08f + 1.27f;
        transform.localPosition = new Vector3(XPos, YPos, ZPos);
    }

}
