using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlates : MonoBehaviour
{
    public GameObject disabledObject;
    public bool holdPlate = false;

    public bool isMultiPlate;
    public GameObject MultiPlateManager;

    public bool IsLiquidTubeControl;
    public GameObject[] LiquidTubes;
    int TubeNumber = 0;


    private void OnTriggerEnter(Collider other)
    {
        //Activats conveyor belt system
        if (IsLiquidTubeControl == true)
        {
            SendLiquidTube();
            return;
        }

        //Increases the number of currently active pressure plates
        if(isMultiPlate == true)
        {
            MultiPlateManager.GetComponent<MultiPlateManager_Script>().ManagePlates(1);
            return;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        disabledObject.gameObject.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        if (holdPlate)
        {
            disabledObject.gameObject.SetActive(true);
        }

        //Decreases the number of currently active pressure plates
        if (isMultiPlate == true)
        {
            MultiPlateManager.GetComponent<MultiPlateManager_Script>().ManagePlates(-1);
            return;
        }

    }

    //Activats conveyor belt system
    private void SendLiquidTube()
    {
        LiquidTubes[TubeNumber].GetComponent<OverheadTrack_Script>().isMoving = true;
        TubeNumber++;
    }

}
