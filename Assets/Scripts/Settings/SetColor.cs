using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using uCPf;

public class SetColor : MonoBehaviour
{
    public enum WhichColor { PlayerColor, ParticleColor, Safezone, Killzone };
    public WhichColor whichColor;

    public void SetTheColor(Color colorInMenu)
    {
        switch (whichColor)
        {
            case WhichColor.PlayerColor:
                if (Settings.playerSettings.useSettings)
                {
                    Settings.playerSettings.playerColor = colorInMenu;
                    SaveLabel.SetToSave();
                }
                break;

            case WhichColor.ParticleColor:
                if (Settings.playerSettings.useSettings)
                {
                    Settings.playerSettings.particleColor = colorInMenu;
                    SaveLabel.SetToSave();
                }
                break;

            case WhichColor.Safezone:
                if (Settings.playerSettings.useSettings)
                {
                    Settings.playerSettings.safezone = colorInMenu;
                    SaveLabel.SetToSave();
                }
                break;

            case WhichColor.Killzone:
                if (Settings.playerSettings.useSettings)
                {
                    Settings.playerSettings.killzone = colorInMenu;
                    SaveLabel.SetToSave();
                }
                break;
        }


    }

}
