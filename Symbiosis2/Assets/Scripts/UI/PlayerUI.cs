using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] GameObject winMenu;
    [SerializeField] GameObject pauseMenu;
    [SerializeField]
    bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = !isPaused;
        pauseMenu.SetActive(true);
        //DefaultPauseState();
        Debug.Log("Game Paused");
    }

    public void ResumeGame()
    {

        Time.timeScale = 1;
        isPaused = !isPaused;
        pauseMenu.SetActive(false);
        Debug.Log("Game Resumed");

    }
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
