using System.Collections;
using System;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class Settings : MonoBehaviour
{

    public static Settings playerSettings;// object to reference when getting data ex. Settings.playerSettings.renderDst

    public static string textFormat = ".dat";

    // variables to save
    public bool useSettings;
    [Range(5, 100)]
    public int renderDst;
    [Range(5f, 15f)]
    public float speed;
    [Range(0.1f, 0.4f)]
    public float turnSpeed;

    public Color playerColor;
    public Color particleColor;
    public Color killzone;
    public Color safezone;

    // called when opening the script
    void Awake()
    {
        if (playerSettings == null)
        {
            DontDestroyOnLoad(gameObject);// make sure object is kept when switching scenes
            playerSettings = this;
        }
        else if (playerSettings != this)
        {
            Destroy(this.gameObject);
        }

    }

    void Start()// same as awake but called after
    {
        Load();
    }


    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerSettings" + textFormat);

        PlayerData data = new PlayerData();

        // insert vars to be saved
        data.useSettings = useSettings;

        data.renderDst = renderDst;
        data.speed = speed;
        data.turnSpeed = turnSpeed;

        data.playerColorR = playerColor.r;
        data.playerColorG = playerColor.g;
        data.playerColorB = playerColor.b;

        data.particleColorR = particleColor.r;
        data.particleColorG = particleColor.g;
        data.particleColorB = particleColor.b;

        data.killzoneR = killzone.r;
        data.killzoneG = killzone.g;
        data.killzoneB = killzone.b;

        data.safezoneR = safezone.r;
        data.safezoneG = safezone.g;
        data.safezoneB = safezone.b;

        // saving and closing file
        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerSettings" + textFormat))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerSettings" + textFormat, FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            // choose vars to be loaded
            useSettings = data.useSettings;
            renderDst = data.renderDst;
            speed = data.speed;
            turnSpeed = data.turnSpeed;

            playerColor.r = data.playerColorR;
            playerColor.g = data.playerColorG;
            playerColor.b = data.playerColorB;

            particleColor.r = data.particleColorR;
            particleColor.g = data.particleColorG;
            particleColor.b = data.particleColorB;

            killzone.r = data.killzoneR;
            killzone.g = data.killzoneG;
            killzone.b = data.killzoneB;

            safezone.r = data.safezoneR;
            safezone.g = data.safezoneG;
            safezone.b = data.safezoneB;
        }

        if (FindObjectOfType<ApplyColors>() != null)
            FindObjectOfType<ApplyColors>().SetColor();
    }

    public void Reset()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerSettings" + textFormat);

        PlayerData data = new PlayerData();

        // choose vars to be default
        data.useSettings = true;

        data.renderDst = 7;
        data.speed = 11;
        data.turnSpeed = 0.2f;

        data.playerColorR = Color.white.r;
        data.playerColorG = Color.white.g;
        data.playerColorB = Color.white.b;

        data.particleColorR = Color.red.r;
        data.particleColorG = Color.red.g;
        data.particleColorB = Color.red.b;

        data.killzoneR = Color.red.r;
        data.killzoneG = Color.red.g;
        data.killzoneB = Color.red.b;

        data.safezoneR = Color.white.r;
        data.safezoneG = Color.white.g;
        data.safezoneB = Color.white.b;

        // saving and closing file
        bf.Serialize(file, data);
        file.Close();

        Load();
        GameObject.Find("Render Dst Slide Value").GetComponent<SliderValueLabel>().ResetSliderLabel();
    }
}


[Serializable]
class PlayerData// class to save to file
{
    public bool useSettings;
    public int renderDst;
    public float speed;
    public float turnSpeed;

    public float playerColorR;
    public float playerColorG;
    public float playerColorB;

    public float particleColorR;
    public float particleColorG;
    public float particleColorB;

    public float killzoneR;
    public float killzoneG;
    public float killzoneB;

    public float safezoneR;
    public float safezoneG;
    public float safezoneB;
}