﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TOM.Apps
{

    public class HomeController : MonoBehaviour
    {

        public void LoadTemplateScene()
        {
            loadScene("Template");
        }

        public void LoadRunningScene()
        {
            loadScene("Running");
        }

        public void LoadLearningScene()
        {
            loadScene("Learning");
        }

        public void LoadHomeScene()
        {
            loadScene("Template");
        }

        public void LoadFavoriteScene()
        {
            loadScene("Favorite");
        }


        public void LoadMartialArtScene()
        {
            loadScene("MartialArts");
        }

        public void LoadPandalensScene()
        {
            loadScene("PANDALens");
        }

        //ref: https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.LoadScene.html
        private void loadScene(string name, LoadSceneMode mode = LoadSceneMode.Single)
        {
            Debug.Log("Loading scene: " + name);
            if (SceneManager.GetActiveScene().name != name)
            {
                StartCoroutine(LoadNewScene(name, mode));
            }
        }

        private IEnumerator LoadNewScene(string sceneName, LoadSceneMode mode)
        {
            string lastSceneLoaded = SceneManager.GetActiveScene().name;

            Debug.Log($"Last scene name: {lastSceneLoaded}");

            // Load the new scene
            SceneManager.LoadSceneAsync(sceneName, mode);

            // Wait in case we don't want to switch scenes too abruptly 
            yield return new WaitForSeconds(0.25f);

            // Unload the last loaded scene
            SceneManager.UnloadSceneAsync(lastSceneLoaded);

        }

    }

}
