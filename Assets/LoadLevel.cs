using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadLevel : MonoBehaviour{

    public GameObject loadingScreen;
    public Slider slider;

        void Start(){
        loadingScreen.SetActive(false);
    }

    public void LevelLoader (int sceneIndex){
        StartCoroutine(LoadAsyncronously(sceneIndex));
        Cursor.lockState = CursorLockMode.Locked;
    }

    IEnumerator LoadAsyncronously (int sceneIndex){
        AsyncOperation operation  = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while (!operation.isDone){
            float progressBar = Mathf.Clamp01(operation.progress / .9f);
            Debug.Log (progressBar);
            slider.value = progressBar;
            //waits a frame
            yield return null;
        }
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}