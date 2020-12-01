using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
