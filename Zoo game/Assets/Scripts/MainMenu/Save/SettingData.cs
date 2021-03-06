using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SettingData
{
    public bool soundOn = true;
    public bool musicOn = true;
    public bool tips = true;
    public int langues = 1;//0 = english 1 = dutch

    public SettingData(SettingsController oData)//saves data
    { 
        soundOn = oData.getSound();
        musicOn = oData.getMusic();
        tips = oData.getTips();
        langues = oData.getLang();
    }
}
