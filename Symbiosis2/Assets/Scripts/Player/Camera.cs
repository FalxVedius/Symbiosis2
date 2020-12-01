/*
 File Name
Your Name Here
Date Last Edited
Version Number for the File
Very brief description of the file
*/

using UnityEngine;


/// <summary>
/// Author: Your Name Here
/// This is the class description.
/// </summary>
public class Camera : MonoBehaviour
{

    public Transform player;

    void Update()
    {
        transform.position = player.transform.position;
    }
}