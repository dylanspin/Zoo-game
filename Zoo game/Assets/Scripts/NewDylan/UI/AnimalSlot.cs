using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalSlot : MonoBehaviour
{
    [Header("Set data")]
    [SerializeField] private Image animalImage;
    [SerializeField] private GameObject notUnlocked;

    [Header("Private data")]
    private int slotId;
    private BookController controllerScript;

    public void setData(int setId,Sprite setImage,bool unlocked,bool active,BookController newController)//gets called from book controller script
    {
        slotId = setId;
        animalImage.sprite = setImage;
        gameObject.SetActive(active);//for when there is no animal for that slot
        animalImage.gameObject.SetActive(unlocked);
        notUnlocked.SetActive(!unlocked);
        controllerScript = newController;
    }

    public void hoverAnimal(bool active)//when hovering 
    {
        controllerScript.hoverSet(slotId,active);
    }

    public void setAnimal()//when clicked
    {
        controllerScript.selectAnimal(slotId);//selects animal
    }
}