using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValueLabel : MonoBehaviour
{

    public Slider slider;
    public enum WhichSlider { RenderDst, Speed, TurnSpeed };
    public WhichSlider whichSlider;
    Text label;

    void Start()
    {
        label = GetComponent<Text>();
        switch (whichSlider)
        {
            case WhichSlider.RenderDst:
                slider.value = (float)Settings.playerSettings.renderDst;
                label.text = Settings.playerSettings.renderDst.ToString();
                break;
            case WhichSlider.Speed:
                slider.value = (float)Settings.playerSettings.speed;
                label.text = Settings.playerSettings.speed.ToString();
                break;
            case WhichSlider.TurnSpeed:
                slider.value = (float)Settings.playerSettings.turnSpeed;
                label.text = Settings.playerSettings.turnSpeed.ToString();
                break;
        }

    }

    public void SetSliderLabel()
    {
        label.text = slider.value.ToString();
        if (Settings.playerSettings.useSettings)
        {
            switch (whichSlider)
            {
                case WhichSlider.RenderDst:
                    Settings.playerSettings.renderDst = (int)slider.value;
                    break;
                case WhichSlider.Speed:
                    Settings.playerSettings.speed = (float)slider.value;
                    break;
                case WhichSlider.TurnSpeed:
                    Settings.playerSettings.turnSpeed = (float)slider.value;
                    break;
            }

            SaveLabel.SetToSave();
        }

    }



    public void ResetSliderLabel()
    {
        switch (whichSlider)
        {
            case WhichSlider.RenderDst:
                slider.value = (float)Settings.playerSettings.renderDst;
                label.text = slider.value.ToString();
                SaveLabel.SetToSave();
                break;
            case WhichSlider.Speed:
                print("hi");
                slider.value = (float)Settings.playerSettings.speed;
                label.text = slider.value.ToString();
                SaveLabel.SetToSave();
                break;
            case WhichSlider.TurnSpeed:
                slider.value = (float)Settings.playerSettings.turnSpeed;
                label.text = slider.value.ToString();
                SaveLabel.SetToSave();
                break;
        }



    }

}
