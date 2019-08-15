using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapPiece5BoxMover : MonoBehaviour
{

    float initPosY = 1.767002f;

    [Range(1.767002f, 10)]
    public float height;

    [Range(0, 1)]
    public float startHeightPercent;
    float startHeight;
    public float speed;

    public bool goUp;

    // Use this for initialization
    void Start()
    {
        goUp = true;
        startHeight = Mathf.Lerp(1.767002f, height, startHeightPercent);
        transform.localPosition = new Vector3(transform.localPosition.x, startHeight, transform.localPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.y > height && goUp == true)
        {
            //transform.Translate(Vector3.forward * speed * Time.deltaTime);
            goUp = false;
        }
        else if (transform.localPosition.y < initPosY && goUp == false)
        {
            //transform.Translate(Vector3.back * speed * Time.deltaTime);
            goUp = true;
        }

        if (goUp == true)
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        else if (goUp == false)
            transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
}
