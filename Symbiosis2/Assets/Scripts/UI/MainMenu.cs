using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public GameObject loadingScreen;
    public ProgressBar bar;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;


    }
    //Load specified Scene
    public void LoadScene(string scene)
    {
        if (scene != "")
        {
            loadingScreen.gameObject.SetActive(true);

            AsyncOperation loadingScene = SceneManager.LoadSceneAsync(scene);

            StartCoroutine(GetSceneLoadProgress(loadingScene));

            Debug.Log("Loading " + scene);
        }
        else
            Debug.Log("No Scene Specified");
    }

    //Quit Application
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting Game");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }


    public IEnumerator GetSceneLoadProgress(AsyncOperation _sceneloading)
    {
        if(!_sceneloading.isDone)
        {
            float currProgress = _sceneloading.progress * 100f;
            bar.curr = Mathf.RoundToInt(currProgress);

            yield return null;
        }

        yield return new WaitForSecondsRealtime(2.0f);

        loadingScreen.gameObject.SetActive(false);
        bar.curr = 0;
    }

}
