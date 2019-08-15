using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapPiece5BoxPlacer : MonoBehaviour
{
    [Range(-3, 0)]
    public float spawnDstRangeStart;

    [Range(0, 2)]
    public float spawnDstRangeEnd;

    // Use this for initialization
    void Start()
    {
        float XPos = Random.Range(spawnDstRangeStart, spawnDstRangeEnd);
        float Ypos = XPos * -0.07333f;
        transform.localPosition = new Vector3(XPos, Ypos);
    }


}
