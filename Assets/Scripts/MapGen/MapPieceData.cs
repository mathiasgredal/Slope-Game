using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class MapPieceData : ScriptableObject
{

    public string mapPieceName;

    public float lenghtToBack;
    public float lengthToFront;

    public float sideMovement;

    public Vector3 pos;
    public Vector3 powerUpPos;

    /*
    public MapPieceData(string _mapPieceName, float _lengthToBack, float _lengthToFront, float _sideMovement, Vector3 _pos)
    {
        mapPieceName = _mapPieceName;
        lenghtToBack = _lengthToBack;
        lengthToFront = _lengthToFront;
        sideMovement = _sideMovement;
        pos = _pos;
    }
    */
}
