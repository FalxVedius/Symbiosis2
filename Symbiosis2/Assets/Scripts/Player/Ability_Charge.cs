using UnityEngine;

public class Ability_Charge : MonoBehaviour
{
    public Transform jebseeOrientation;
    public Rigidbody rigidBod;

    private float chargeSpeed = 200.0f;
    private float chargeTime = 0.5f;

    private float currTime = 0.0f;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && currTime <= 0.0f)
        {
            currTime = chargeTime;
        }

        if(currTime > 0.0f)
        {
            currTime -= Time.deltaTime;

            rigidBod.velocity = (-1*jebseeOrientation.forward) * chargeSpeed;
        }
    }
}
