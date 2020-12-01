/*
Camera.cs
Jeremy Cates
Last Edited: 11/30/2020
Version #: 1.0
Adjust the Camera to the players Head Location
*/

using UnityEngine;


/// <summary>
/// Author: Jeremy Cates
/// Adjust the Camera to the players Head Location
/// </summary>
public class Camera : MonoBehaviour
{

    public Transform player;                                                    //The player character


    /// <summary>
    /// Author: Jeremy Cates
    /// Updates to the positon of the player
    /// </summary>
    void Update()
    {
        transform.position = player.transform.position;
    }
}