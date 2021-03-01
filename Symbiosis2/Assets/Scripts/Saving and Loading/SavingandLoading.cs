using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingandLoading : MonoBehaviour
{

    public CheckpointManager checkPointManager;
    public void Save()
    {
        GameObject[] listOfObjects = GameObject.FindObjectsOfType<GameObject>();

        checkPointManager = GameObject.FindGameObjectWithTag("Global").GetComponent<CheckpointManager>();

        foreach (GameObject gO in listOfObjects)
        {
            PlayerPrefs.SetFloat(gO.name +"X", gO.transform.position.x);
            PlayerPrefs.SetFloat(gO.name + "Y", gO.transform.position.y);
            PlayerPrefs.SetFloat(gO.name + "Z", gO.transform.position.z);

            PlayerPrefs.SetFloat(gO.name + "rX", gO.transform.rotation.x);
            PlayerPrefs.SetFloat(gO.name + "rY", gO.transform.rotation.y);
            PlayerPrefs.SetFloat(gO.name + "rZ", gO.transform.rotation.z);
        }

        PlayerPrefs.SetString("CurrCheckpoint", checkPointManager.currCheckpoint.name);
    }


    public void Load()
    {
        GameObject[] listOfObjects = GameObject.FindObjectsOfType<GameObject>();

        checkPointManager = GameObject.FindGameObjectWithTag("Global").GetComponent<CheckpointManager>();

        foreach (GameObject gO in listOfObjects)
        {

            gO.transform.position = new Vector3(PlayerPrefs.GetFloat(gO.name + "X"), PlayerPrefs.GetFloat(gO.name + "Y"), PlayerPrefs.GetFloat(gO.name + "Z"));
            //gO.transform.rotation = new Quaternion(PlayerPrefs.GetFloat(gO.name + "rX"), PlayerPrefs.GetFloat(gO.name + "rY"), PlayerPrefs.GetFloat(gO.name + "rZ"), 1);

        }

        PlayerPrefs.SetString("CurrCheckpoint", checkPointManager.currCheckpoint.name);
        checkPointManager.SetCurrentCheckpoint(PlayerPrefs.GetString("CurrCheckpoint"));
    }
}
