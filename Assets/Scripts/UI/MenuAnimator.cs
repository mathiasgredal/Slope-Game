using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimator : MonoBehaviour
{

    public Animator animSettings;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
            OpenOrCloseSettings();
    }

    public void OpenOrCloseSettings()
    {
        animSettings.SetTrigger("OpenSettings");
    }


}
