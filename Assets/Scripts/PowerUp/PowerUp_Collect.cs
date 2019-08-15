using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Collect : MonoBehaviour
{
    public string whatToCollect;

    void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<PowerUp_Manager>().AddPowerUp(whatToCollect);
        Destroy(this.gameObject);
    }
}
