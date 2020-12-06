using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LavaPit : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        string scene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(scene);
        Debug.Log("Reloading " + scene);
    }
}
