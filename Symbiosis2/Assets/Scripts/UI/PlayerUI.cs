using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public static PlayerUI instance;
    [SerializeField] GameObject winMenu;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject optionsMenu;
    [SerializeField] GameObject playerReticle;
    [SerializeField] Image avatarImage;
    [SerializeField] Sprite jebAvatar;
    [SerializeField] Sprite indiAvatar;
    bool isPaused;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        AudioManager.instance.PlaySound("Music_Gameplay");
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
        playerReticle.SetActive(false);
        pauseMenu.SetActive(true);
        //DefaultPauseState();
        Debug.Log("Game Paused");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        AudioManager.instance.PauseSound("Music_Gameplay");
    }

    public void ResumeGame()
    {

        Time.timeScale = 1;
        isPaused = !isPaused;
        playerReticle.SetActive(true);
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        Debug.Log("Game Resumed");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        AudioManager.instance.ResumeSound("Music_Gameplay");
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

    public void DisplayIndi()
    {
        avatarImage.sprite = indiAvatar;
    }

    public void DisplayJebsee()
    {
        avatarImage.sprite = jebAvatar;
    }
}
