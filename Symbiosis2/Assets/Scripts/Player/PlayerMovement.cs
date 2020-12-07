/*
PlayerMovement.cs
Jeremy Cates
Last Edited: 11/30/2020
Version #: 1.0
Controls the players movement entirely
*/

using System;
using UnityEngine;


/// <summary>
/// Author: Jeremy Cates
/// Controls the players movement entirely
/// </summary>
public class PlayerMovement : MonoBehaviour
{

    public Transform playerCam;                                                                     //
    public Transform orientation;                                                                   //
    private Rigidbody rb;                                                                           //
    private float xRotation;                                                                        //
    private float sensitivity = 50f;                                                                //
    private float sensMultiplier = 1f;                                                              //
    public float moveSpeed = 4500;                                                                  //
    public float maxSpeed = 20;                                                                     //
    public bool grounded;                                                                           //
    public LayerMask whatIsGround;                                                                  //
    public float counterMovement = 0.175f;                                                          //
    private float threshold = 0.01f;                                                                //
    public float maxSlopeAngle = 35f;                                                               //
    private Vector3 crouchScale = new Vector3(1, 0.5f, 1);                                          //
    private Vector3 playerScale;                                                                    //
    public float slideForce = 400;                                                                  //
    public float slideCounterMovement = 0.2f;                                                       //
    private bool readyToJump = true;                                                                //
    private float jumpCooldown = 0.25f;                                                             //
    public float jumpForce = 550f;                                                                  //
    float x, y;                                                                                     //
    bool jumping;                                                                                   //
    bool sprinting;                                                                                 //
    bool crouching;                                                                                 //
    private Vector3 normalVector = Vector3.up;                                                      //
    private Vector3 wallNormalVector;                                                               //
    private bool cancellingGrounded;                                                                //
    private float desiredX;                                                                         //


    public bool Enabled = true;


    /// <summary>
    /// Author: Your Name Here
    /// This is the function description.
    /// </summary>
    /// <param name="Para Name Here">Param Description Here</param>
    /// <returns>The data that this function returns</returns>
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    /// <summary>
    /// Author: Your Name Here
    /// This is the function description.
    /// </summary>
    /// <param name="Para Name Here">Param Description Here</param>
    /// <returns>The data that this function returns</returns>
    void Start()
    {
        playerScale = transform.localScale;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    /// <summary>
    /// Author: Your Name Here
    /// This is the function description.
    /// </summary>
    /// <param name="Para Name Here">Param Description Here</param>
    /// <returns>The data that this function returns</returns>
    private void FixedUpdate()
    {
        if (Enabled == true)
        {
            rb.AddForce(Vector3.down * Time.deltaTime * 10);

            Vector2 mag = FindVelRelativeToLook();
            float xMag = mag.x, yMag = mag.y;

            CounterMovement(x, y, mag);

            if (readyToJump && jumping) Jump();

            //Set max speed
            float maxSpeed = this.maxSpeed;

            if (crouching && grounded && readyToJump)
            {
                rb.AddForce(Vector3.down * Time.deltaTime * 3000);
                return;
            }

            if (x > 0 && xMag > maxSpeed) x = 0;
            if (x < 0 && xMag < -maxSpeed) x = 0;
            if (y > 0 && yMag > maxSpeed) y = 0;
            if (y < 0 && yMag < -maxSpeed) y = 0;

            float multiplier = 1f, multiplierV = 1f;

            if (!grounded)
            {
                multiplier = 0.5f;
                multiplierV = 0.5f;
            }

            if (grounded && crouching) multiplierV = 0f;

            rb.AddForce(orientation.transform.forward * y * moveSpeed * Time.deltaTime * multiplier * multiplierV);
            rb.AddForce(orientation.transform.right * x * moveSpeed * Time.deltaTime * multiplier);
        }
    }


    /// <summary>
    /// Author: Jeremy Cates
    /// Catches player input and operates the movement
    /// </summary>
    private void Update()
    {
        if (Enabled == true)
        {
            x = Input.GetAxisRaw("Horizontal");
            y = Input.GetAxisRaw("Vertical");
            jumping = Input.GetButton("Jump");

            float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.fixedDeltaTime * sensMultiplier;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.fixedDeltaTime * sensMultiplier;

            Vector3 rot = playerCam.transform.localRotation.eulerAngles;
            desiredX = rot.y + mouseX;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            playerCam.transform.localRotation = Quaternion.Euler(xRotation, desiredX, 0);
            orientation.transform.localRotation = Quaternion.Euler(0, desiredX, 0);
        }
    }


    /// <summary>
    /// Author: Your Name Here
    /// This is the function description.
    /// </summary>
    /// <param name="Para Name Here">Param Description Here</param>
    /// <returns>The data that this function returns</returns>
    private void Jump()
    {
        if (grounded && readyToJump && Enabled)
        {
            readyToJump = false;

            //Add jump forces
            rb.AddForce(Vector2.up * jumpForce * 1.5f);
            rb.AddForce(normalVector * jumpForce * 0.5f);

            //If jumping while falling, reset y velocity.
            Vector3 vel = rb.velocity;
            if (rb.velocity.y < 0.5f)
                rb.velocity = new Vector3(vel.x, 0, vel.z);
            else if (rb.velocity.y > 0)
                rb.velocity = new Vector3(vel.x, vel.y / 2, vel.z);

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }


    /// <summary>
    /// Author: Your Name Here
    /// This is the function description.
    /// </summary>
    /// <param name="Para Name Here">Param Description Here</param>
    /// <returns>The data that this function returns</returns>
    private void ResetJump()
    {
        readyToJump = true;
    }


    /// <summary>
    /// Author: Your Name Here
    /// This is the function description.
    /// </summary>
    /// <param name="Para Name Here">Param Description Here</param>
    /// <returns>The data that this function returns</returns>
    private void CounterMovement(float x, float y, Vector2 mag)
    {
        if (!grounded || jumping) return;

        //Counter movement
        if (Math.Abs(mag.x) > threshold && Math.Abs(x) < 0.05f || (mag.x < -threshold && x > 0) || (mag.x > threshold && x < 0))
        {
            rb.AddForce(moveSpeed * orientation.transform.right * Time.deltaTime * -mag.x * counterMovement);
        }
        if (Math.Abs(mag.y) > threshold && Math.Abs(y) < 0.05f || (mag.y < -threshold && y > 0) || (mag.y > threshold && y < 0))
        {
            rb.AddForce(moveSpeed * orientation.transform.forward * Time.deltaTime * -mag.y * counterMovement);
        }

        //Limit diagonal running. This will also cause a full stop if sliding fast and un-crouching, so not optimal.
        if (Mathf.Sqrt((Mathf.Pow(rb.velocity.x, 2) + Mathf.Pow(rb.velocity.z, 2))) > maxSpeed)
        {
            float fallspeed = rb.velocity.y;
            Vector3 n = rb.velocity.normalized * maxSpeed;
            rb.velocity = new Vector3(n.x, fallspeed, n.z);
        }
    }


    /// <summary>
    /// Author: Your Name Here
    /// This is the function description.
    /// </summary>
    /// <param name="Para Name Here">Param Description Here</param>
    /// <returns>The data that this function returns</returns>
    public Vector2 FindVelRelativeToLook()
    {
        float lookAngle = orientation.transform.eulerAngles.y;
        float moveAngle = Mathf.Atan2(rb.velocity.x, rb.velocity.z) * Mathf.Rad2Deg;

        float u = Mathf.DeltaAngle(lookAngle, moveAngle);
        float v = 90 - u;

        float magnitue = rb.velocity.magnitude;
        float yMag = magnitue * Mathf.Cos(u * Mathf.Deg2Rad);
        float xMag = magnitue * Mathf.Cos(v * Mathf.Deg2Rad);

        return new Vector2(xMag, yMag);
    }


    /// <summary>
    /// Author: Your Name Here
    /// This is the function description.
    /// </summary>
    /// <param name="Para Name Here">Param Description Here</param>
    /// <returns>The data that this function returns</returns>
    private bool IsFloor(Vector3 v)
    {
        float angle = Vector3.Angle(Vector3.up, v);
        return angle < maxSlopeAngle;
    }


    /// <summary>
    /// Author: Your Name Here
    /// This is the function description.
    /// </summary>
    /// <param name="Para Name Here">Param Description Here</param>
    /// <returns>The data that this function returns</returns>
    private void OnCollisionStay(Collision other)
    {
        if (Enabled == true)
        {
            //Make sure we are only checking for walkable layers
            int layer = other.gameObject.layer;
            if (whatIsGround != (whatIsGround | (1 << layer))) return;

            //Iterate through every collision in a physics update
            for (int i = 0; i < other.contactCount; i++)
            {
                Vector3 normal = other.contacts[i].normal;
                //FLOOR
                if (IsFloor(normal))
                {
                    grounded = true;
                    cancellingGrounded = false;
                    normalVector = normal;
                    CancelInvoke(nameof(StopGrounded));
                }
            }

            //Invoke ground/wall cancel, since we can't check normals with CollisionExit
            float delay = 3f;
            if (!cancellingGrounded)
            {
                cancellingGrounded = true;
                Invoke(nameof(StopGrounded), Time.deltaTime * delay);
            }
        }
    }


    /// <summary>
    /// Author: Your Name Here
    /// This is the function description.
    /// </summary>
    /// <param name="Para Name Here">Param Description Here</param>
    /// <returns>The data that this function returns</returns>
    private void StopGrounded()
    {
        grounded = false;
    }

}