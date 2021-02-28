using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndDoor : MonoBehaviour
{
    public GameObject winPanel;
    public bool finalLevel;

    private void OnTriggerEnter(Collider other)
    {
        if (finalLevel)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
       // winPanel.gameObject.SetActive(true);
        //Time.timeScale = 0;
    }
}
