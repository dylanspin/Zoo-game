using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translate : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private BookController bookScript;
    [SerializeField] private LevelControllerUi levelScript;
    [SerializeField] private unlockedAnimal unlockScript;
    [SerializeField] private TypeEffect typeScript;


    [Header("Set Data")]
    [SerializeField] private TMPro.TextMeshProUGUI[] translateText;
    [SerializeField] private string[] dutch;
    [SerializeField] private string[] english;

    public void setLangues(int newLangues)
    {
        if(bookScript)//if main ui
        {
            bookScript.setLangues(newLangues);
            levelScript.setLangues(newLangues);
            unlockScript.setLang(newLangues);
        }
        
        if(typeScript)//for the intro in the game 
        {
            if(newLangues == 0)
            {
                typeScript.setLangText(english[0]);
            }
            else
            {
                typeScript.setLangText(dutch[0]);
            }
        }

        for(int i=0; i<translateText.Length; i++)// setLangues
        {
            if(translateText[i])
            {
                if(newLangues == 0)
                {
                    translateText[i].text = english[i];
                }
                else
                {
                    translateText[i].text = dutch[i];
                }
            }
        }
    }
}
