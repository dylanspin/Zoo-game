using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen; 
    [SerializeField] private Slider slider; 
    [SerializeField] private Text progressText; 
    
    public void LoadLevel (int sceneIndex) 
    { 
        StartCoroutine(LoadAsynchronously(sceneIndex)); 
    } 

    IEnumerator LoadAsynchronously (int sceneIndex) 
    { 
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex); 

        loadingScreen.SetActive(true); 

        while (!operation.isDone) 
        { 
            float progress = Mathf.Clamp01(operation.progress / .9f); 
            
            slider.value = progress; 
            progressText.text = progress * 100f + "%"; 

            yield return null; 
        } 
    } 
}
