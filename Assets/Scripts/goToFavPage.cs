using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class goToFavPage : MonoBehaviour
{
    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
    [Header("Loading Tab")]
    [SerializeField] private GameObject loadingTab;
    [Header("Slider")]
    [SerializeField] private Slider loadingSlider; 
    public void LoadScene(string sceneName) 
    {
        // SceneManager.LoadScene(sceneName);
        loadingTab.SetActive(true);
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        while (!operation.isDone)
        {
            // Add loading UI feedback here if needed
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            loadingSlider.value = progressValue;
            yield return null;
        }
    }
}
