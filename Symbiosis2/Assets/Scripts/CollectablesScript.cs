using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectablesScript : MonoBehaviour
{
    public bool isPlantCollectable;
    public bool isDinoCollectable;

    GameObject UICanvas;

    private void Start()
    {
        UICanvas = GameObject.Find("PlayerUICanvas");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(isPlantCollectable == true && other.gameObject.tag == "Indi")
        {
            UICanvas.GetComponent<ScoreScript>().IncreasePlantCollectable();
            Destroy(gameObject);
        }

        if(isDinoCollectable == true && other.gameObject.tag == "Jebsee")
        {
            UICanvas.GetComponent<ScoreScript>().IncreaseDinoCollectable();
            Destroy(gameObject);
        }
    }

}
