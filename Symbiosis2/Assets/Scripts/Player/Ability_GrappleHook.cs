/*
Ability_GrappleHook.cs
Jeremy Cates
Last Edited: 11/30/2020
Version #: 1.0
Allows the player fire off a graple hook and swing from it
*/

using UnityEngine;



/// <summary>
/// Author: Jeremy Cates
/// Allows the player fire off a graple hook and swing from it
/// </summary>
public class Ability_GrappleHook : MonoBehaviour
{

    private Vector3 contactPoint;                                            //Point of contact that the grapple hook makes with the terrain
    private LineRenderer lineRenderer;                                       //The Line that gets drawn from the grapple hook to the block
    public Transform grappleLaunchPos;                                       //The position where the grapple hook launches from
    public LayerMask grappleTerrain;                                         //Type of Terrain that the grapple hook can launch to
    public Transform player;                                                 //The player
    public Transform cameraForRaycast;                                       //The camera that is used for the raycast to see if the grapplehook will hit the block
    private float maxDistance = 25f;                                         //The Max distance that the hook can be fired out to hit things
    private Vector3 currGrapplePos;                                          //The curr position of the grappled hook
    private SpringJoint joint;                                               //The joint used to give rotation to the player in the air


    /// <summary>
    /// Author: Jeremy Cates
    /// Catches the Line Render component
    /// </summary>
    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }


    /// <summary>
    /// Author: Jeremy Cates
    /// This catches the input from the mouse and launches the proper function calls
    /// </summary>
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartGrapple();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopGrapple();
        }
    }


    /// <summary>
    /// Author: Jeremy Cates
    /// Drawing the rope later allows the rope to get all the positional updates first and then maintain the ability to make the line not lag behind
    /// </summary>
    void LateUpdate()
    {
        DrawRope();
    }


    /// <summary>
    /// Author: Jeremy Cates
    /// Fires off the grapple hook to the block as well as creates the joint and manipulates it
    /// </summary>
    void StartGrapple()
    {
        RaycastHit hit;
        if (Physics.Raycast(cameraForRaycast.position, cameraForRaycast.forward, out hit, maxDistance, grappleTerrain))
        {
            contactPoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = contactPoint;

            float distanceFromPoint = Vector3.Distance(player.position, contactPoint);

            joint.maxDistance = distanceFromPoint * 0.2f;
            joint.minDistance = distanceFromPoint * 0.1f;

            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;

            lineRenderer.positionCount = 2;
            currGrapplePos = grappleLaunchPos.position;
        }
    }


    /// <summary>
    /// Author: Jeremy Cates
    /// Stops the grapple hook when the mouse is let go
    /// </summary>
    void StopGrapple()
    {
        lineRenderer.positionCount = 0;
        Destroy(joint);
    }



    /// <summary>
    /// Author: Jeremy Cates
    /// Draws the line renderer to give the grapple hook launching and the rope connection
    /// </summary>
    void DrawRope()
    {
        if (!joint) return;

        currGrapplePos = Vector3.Lerp(currGrapplePos, contactPoint, Time.deltaTime * 8f);

        lineRenderer.SetPosition(0, grappleLaunchPos.position);
        lineRenderer.SetPosition(1, currGrapplePos);
    }


    /// <summary>
    /// Author: Jeremy Cates
    /// A Check to see if the grapple is currently connected to a grapple terrain
    /// </summary>
    /// <returns>Returns true if the grapple is connected to a terrain and false if not.</returns>
    public bool IsGrappling()
    {
        return joint != null;
    }


    /// <summary>
    /// Author: Jeremy Cates
    /// Gets the contact point made on the block when firing the grapple hook
    /// </summary>
    /// <returns>Returns the contact point from the hook on the block</returns>
    public Vector3 GetcontactPoint()
    {
        return contactPoint;
    }
}