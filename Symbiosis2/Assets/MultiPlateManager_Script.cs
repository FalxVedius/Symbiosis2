using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiPlateManager_Script : MonoBehaviour
{
    public int TotalPlates;
    int CurrentPlates = 0;

    public GameObject ActivationObject;

    public void ManagePlates(int PlateValue)
    {
        CurrentPlates += PlateValue;

        if(CurrentPlates >= TotalPlates)
        {
            ActivationObject.SetActive(true);
        }
    }


}
