using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public List<GameObject> listOfCheckpoints;

    private GameObject currCheckpoint;

    public Vector3 GetCurrentCheckpoint()
    {
        for (int i = 0; i < listOfCheckpoints.Count; i++)
        {
            if (listOfCheckpoints[i].GetComponent<Checkpoints>().isActive)
            {
                currCheckpoint = listOfCheckpoints[i];
            }
            else
            {
                break;
            }
        }
        return currCheckpoint.transform.position;
    }
}
