using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Load specified Scene
    public void LoadScene(string scene)
    {
        if (scene != "")
        {
            SceneManager.LoadScene(scene);
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
}
