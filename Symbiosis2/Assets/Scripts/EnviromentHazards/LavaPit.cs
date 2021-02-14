using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LavaPit : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<PlayerMovement>() != null)
        {
            string scene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(scene);
            Debug.Log("Reloading " + scene);
        }

    }
}
