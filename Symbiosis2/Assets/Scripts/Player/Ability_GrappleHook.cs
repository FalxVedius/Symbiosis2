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
public class Ability_GrappleHook : MonoBehaviour
{

    private LineRenderer lineRenderer;
    private Vector3 contactPoint;
    public LayerMask grappleTerrain;
    public Transform gunTip, camera, player;
    private float maxDistance = 25f;
    private SpringJoint joint;
    private Vector3 currentGrapplePosition;


    /// <summary>
    /// Author: Your Name Here
    /// This is the function description.
    /// </summary>
    /// <param name="Para Name Here">Param Description Here</param>
    /// <returns>The data that this function returns</returns>
    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }


    /// <summary>
    /// Author: Your Name Here
    /// This is the function description.
    /// </summary>
    /// <param name="Para Name Here">Param Description Here</param>
    /// <returns>The data that this function returns</returns>
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
    /// Author: Your Name Here
    /// This is the function description.
    /// </summary>
    /// <param name="Para Name Here">Param Description Here</param>
    /// <returns>The data that this function returns</returns>
    void LateUpdate()
    {
        DrawRope();
    }


    /// <summary>
    /// Author: Your Name Here
    /// This is the function description.
    /// </summary>
    /// <param name="Para Name Here">Param Description Here</param>
    /// <returns>The data that this function returns</returns>
    void StartGrapple()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.position, camera.forward, out hit, maxDistance, grappleTerrain))
        {
            contactPoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = contactPoint;

            float distanceFromPoint = Vector3.Distance(player.position, contactPoint);

            //The distance grapple will try to keep from grapple point. 
            joint.maxDistance = distanceFromPoint * 0.2f;
            joint.minDistance = distanceFromPoint * 0.1f;

            //Adjust these values to fit your game.
            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;

            lineRenderer.positionCount = 2;
            currentGrapplePosition = gunTip.position;
        }
    }


    /// <summary>
    /// Author: Your Name Here
    /// This is the function description.
    /// </summary>
    /// <param name="Para Name Here">Param Description Here</param>
    /// <returns>The data that this function returns</returns>
    void StopGrapple()
    {
        lineRenderer.positionCount = 0;
        Destroy(joint);
    }



    /// <summary>
    /// Author: Your Name Here
    /// This is the function description.
    /// </summary>
    /// <param name="Para Name Here">Param Description Here</param>
    /// <returns>The data that this function returns</returns>
    void DrawRope()
    {
        //If not grappling, don't draw rope
        if (!joint) return;

        currentGrapplePosition = Vector3.Lerp(currentGrapplePosition, contactPoint, Time.deltaTime * 8f);

        lineRenderer.SetPosition(0, gunTip.position);
        lineRenderer.SetPosition(1, currentGrapplePosition);
    }


    /// <summary>
    /// Author: Your Name Here
    /// This is the function description.
    /// </summary>
    /// <param name="Para Name Here">Param Description Here</param>
    /// <returns>The data that this function returns</returns>
    public bool IsGrappling()
    {
        return joint != null;
    }


    /// <summary>
    /// Author: Your Name Here
    /// This is the function description.
    /// </summary>
    /// <param name="Para Name Here">Param Description Here</param>
    /// <returns>The data that this function returns</returns>
    public Vector3 GetcontactPoint()
    {
        return contactPoint;
    }
}