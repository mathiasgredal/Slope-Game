using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp_Manager : MonoBehaviour
{
    [Range(0, 1)]
    public float powerupSpawnFrequency = 0.05f;

    public PowerUp[] powerUps;

    // Use this for initialization
    void Start()
    {
        FindObjectOfType<Player_Killer>().OnRetryMap += ResetPowerUps;
    }

    // Update is called once per frame
    void Update()
    {
        CheckKey();
    }

    public void AddPowerUp(string powerup)
    {
        switch (powerup)
        {
            case "Slo-Mo":
                powerUps[0].amount += 1;
                powerUps[0].text.text = powerUps[0].amount.ToString();
                break;
            case "God Mode":
                powerUps[1].amount += 1;
                powerUps[1].text.text = powerUps[1].amount.ToString();
                break;
        }
    }

    void DrawUI()
    {

    }

    void ResetPowerUps()
    {
        foreach (PowerUp powerUp in powerUps)
        {
            powerUp.amount = 0;
            powerUp.text.text = powerUp.amount.ToString();
        }
    }

    void CheckKey()
    {
        if (Input.GetButtonDown("Slo-Mo") && !GetComponent<SloMo_Effect>().isOn && powerUps[0].amount > 0)
        {
            GetComponent<SloMo_Effect>().SlowMo(powerUps[0].duration);
            powerUps[0].circleLoad.StartLoading();
            powerUps[0].amount -= 1;
            powerUps[0].text.text = powerUps[0].amount.ToString();
        }
        if (Input.GetButtonDown("God Mode") && !GetComponent<GodMode_Effect>().isOn && powerUps[1].amount > 0)
        {
            GetComponent<GodMode_Effect>().GodMode(powerUps[1].duration);
            powerUps[1].circleLoad.StartLoading();
            powerUps[1].amount -= 1;
            powerUps[1].text.text = powerUps[1].amount.ToString();
        }
    }

    [System.Serializable]
    public class PowerUp
    {
        public string name;
        public int amount;
        public Text text;
        public GameObject powerUpObject;
        public float duration;
        public float spawnRate;
        public CircleLoad circleLoad;

        public PowerUp(string _name, int _amount)
        {
            name = _name;
            amount = _amount;
        }
    }

    void OnDisable()
    {
        FindObjectOfType<Player_Killer>().OnRetryMap -= ResetPowerUps;
    }

}
