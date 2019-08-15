using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLabel : MonoBehaviour
{


    public void Save()
    {
        Text saveLabel = GetComponentInChildren<Text>();
        saveLabel.text = "Saved";
        print("saved");
    }


    public static void SetToSave()
    {
        Text saveLabel = GameObject.Find("SaveButtonText").GetComponent<Text>(); ;
        saveLabel.text = "Save";
        //print("save");
    }
}
